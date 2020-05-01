using System;

namespace DecisionSim
{
    class BiModalDistribution
    {
        private static readonly Random rand = new Random();

        //public static double RandomDraw(double mu = 0, double sigma = 1)
        public static double RandomDraw()
        {
            double mu = 5;
            double sigma = 1;
            if (rand.NextDouble() < 0.5)
                return NormalDistribution.RandomDraw(mu, sigma);
            else
                return NormalDistribution.RandomDraw(mu + 5 * sigma, sigma);
        }
    }
}
