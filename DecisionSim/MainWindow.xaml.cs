using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DecisionSim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainChoicesListViewViewModel GroupsVM;

        private readonly Dictionary<string, Func<double>> pdfs = new Dictionary<string, Func<double>>()
            {
                { "~N(0,1)", NormalDistribution.RandomDraw },
                { "~U(0,1)", UniformDistribution.RandomDraw },
                { "BiModal", BiModalDistribution.RandomDraw }
            };

        // temporary groupnames - want to allow user to specify group names later, but also keep default A, B, C, etc.
        readonly List<string> grpnames = new List<string>() { "A", "B", "C", "D", "E" };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            GroupsVM = MainChoicesListViewViewModel.CreateViewModel();

            if (!int.TryParse(NumPeople.Text, out int numpeopleValue) || numpeopleValue <= 0)
            {
                MessageBox.Show("Number of people must be a positive integer.");
                return;
            }
            if (!int.TryParse(NumChoices.Text, out int numchoicesValue) || numchoicesValue <= 0 || numchoicesValue > grpnames.Count)
            {
                MessageBox.Show("Number of choices must be a positive integer between one and five.");
                return;
            }

            string PrefDistSelected = ((ComboBoxItem)PreferenceDistribution.SelectedItem).Content.ToString();

            for (int idx = 0; idx < numchoicesValue; ++idx)
                GroupsVM.AddNewChoiceGroup(grpnames[idx]);

            List<Person> people = new List<Person>();
            for (int idx = 0; idx < numpeopleValue; ++idx)
                people.Add(Person.CreatePerson(numchoicesValue, pdfs[PrefDistSelected]));

            foreach (Person p in people)
                GroupsVM.Items[p.PreferenceList.ListOfPrefs.IndexOf(p.PreferenceList.ListOfPrefs.Max())].IncrementPopulation();

            MainChoicesListView.ItemsSource = GroupsVM.Items;
        }

        private void RunSimButton_Click(object sender, RoutedEventArgs e)
        {

        }

        //private List<int> GetChoiceCounts(List<Person> people)
        //{
        //    int numPeople = people.Count;
        //}
    }
}
