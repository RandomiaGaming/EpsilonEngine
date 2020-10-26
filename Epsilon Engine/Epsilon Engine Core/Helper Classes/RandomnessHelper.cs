using System;
namespace EpsilonEngine
{
    public static class RandomnessHelper
    {
        private static readonly Random RNG = new Random();
        public static int Next(int min, int max)
        {
            return RNG.Next(min, max);
        }
    }
}
