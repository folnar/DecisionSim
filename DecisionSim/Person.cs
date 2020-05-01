using System;
using System.Collections.Generic;

namespace DecisionSim
{
    class Person
    {
        public Preferences PreferenceList { get; set; }
        public double Charisma { get; set; }
        public double Susceptibility { get; set; }

        private Person() { }

        internal static Person CreatePerson(int numChoices, Func<double> randomDraw)
        {
            Person p = new Person
            {
                Charisma = NormalDistribution.RandomDraw(),
                Susceptibility = NormalDistribution.RandomDraw()
            };
            List<double> prefs = new List<double>();
            for (int idx = 0; idx < numChoices; ++idx)
                prefs.Add(randomDraw());

            p.PreferenceList = Preferences.CreatePreferencesObject(numChoices, prefs);
            return p;
        }
    }
}
