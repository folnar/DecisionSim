using System.Collections.ObjectModel;

namespace DecisionSim
{
    public class MainChoicesListViewViewModel
    {
        public ObservableCollection<ChoiceGroup> Items;

        private MainChoicesListViewViewModel() { }

        public static MainChoicesListViewViewModel CreateViewModel()
        {
            return new MainChoicesListViewViewModel
            {
                Items = new ObservableCollection<ChoiceGroup>()
            };
        }

        internal void AddNewChoiceGroup(string v1, int v2 = 0)
        {
            Items.Add(ChoiceGroup.CreateChoiceGroup(v1, v2));
        }

        internal void ClearGroups()
        {
            Items.Clear();
        }
    }
}
