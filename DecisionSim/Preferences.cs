using System.Collections.Generic;
using System.Linq;

namespace DecisionSim
{
    public class Preferences
    {
        public int NumChoices { set; get; }
        public List<double> ListOfPrefs { get; set; }
  
        private Preferences() { }

        public static Preferences CreatePreferencesObject(int n)
        {
            return new Preferences
            {
                NumChoices = n
            };
        }

        public static Preferences CreatePreferencesObject(int n, List<double> prefs)
        {
            Preferences retobj = new Preferences
            {
                NumChoices = n,
                ListOfPrefs = prefs
            };
            retobj.NormalizePreferences();
            return retobj;
        }

        public void UpdatePreferencesList(List<double> prefs)
        {
            ListOfPrefs = prefs;
            NormalizePreferences();
            return;
        }

        private void NormalizePreferences()
        {
            double sumOfPrefs = ListOfPrefs.Sum();
            for (int idx = 0; idx < ListOfPrefs.Count; ++idx)
                ListOfPrefs[idx] /= sumOfPrefs;
        }
    }
}