namespace DecisionSim
{
    public class ChoiceGroup
    {
        public string Name { get; set; }
        public int Population { get; set; }

        private ChoiceGroup() { }

        public static ChoiceGroup CreateChoiceGroup(string nameParam, int popParam = 0)
        {
            return new ChoiceGroup
            {
                Name = nameParam,
                Population = popParam
            };
        }

        internal void IncrementPopulation(int amount = 1)
        {
            Population += amount;
        }
    }
}