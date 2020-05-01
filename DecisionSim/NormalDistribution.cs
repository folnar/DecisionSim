using System;

namespace DecisionSim
{
    public static class NormalDistribution
    {
        private static readonly Random rand = new Random();

        public static double RandomDraw()
        {
            double x1 = 1.0 - rand.NextDouble();
            double x2 = 1.0 - rand.NextDouble();
            return Math.Sqrt(-2.0 * Math.Log(x1)) * Math.Sin(2.0 * Math.PI * x2);
        }

        public static double RandomDraw(double mu = 0, double sigma = 1)
        {
            double x1 = 1.0 - rand.NextDouble();
            double x2 = 1.0 - rand.NextDouble();
            return mu + sigma * Math.Sqrt(-2.0 * Math.Log(x1)) * Math.Sin(2.0 * Math.PI * x2);
        }
    }
}
