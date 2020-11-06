using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticOptimize {
    internal static class RandomExtend {

        public static bool NextBool(this Random random) {
            return (random.Next() & 1) == 1;
        }

        public static IEnumerable<bool> NextBools(this Random random, int length) {
            byte[] bs = new byte[(length + 7) / 8];

            random.NextBytes(bs);

            int k = 0;
            foreach(byte b in bs) {
                uint v = b;

                for(int j = 0; j < 8 && k < length; j++, k++) { 
                    yield return (v & 1) == 1;
                    v >>= 1;
                }
            }
        }

        public static bool NextBool(this Random random, double prob) {
            return random.NextDouble() < prob;
        }

        public static double NextRange(this Random random, double min, double max) {
            return min + random.NextDouble() * (max - min);
        }

        public static T Choice<T>(this Random random, IEnumerable<T> collection) {
            return collection.Skip(random.Next(collection.Count())).First();
        }

        public static T Choice<T>(this Random random, T[] collection) {
            return collection[random.Next(collection.Count())];
        }

    }
}
