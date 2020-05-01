using System;

namespace DecisionSim
{
    class UniformDistribution
    {
        private static readonly Random rand = new Random();

        public static double RandomDraw()
        {
            return rand.NextDouble();
        }
    }
}
