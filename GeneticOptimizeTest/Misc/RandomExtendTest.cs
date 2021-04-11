
using GeneticOptimize;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;

namespace GeneticOptimizeTest {
    [TestClass]
    public class RandomExtendTest {
        [TestMethod]
        public void BoolTest() {
            Random random = new();

            for (int i = 0; i < 10; i++) {
                Console.WriteLine(random.NextBool());
            }

            for (int i = 0; i < 10; i++) {
                Console.WriteLine(random.NextBool(0.2));
            }
        }

        [TestMethod]
        public void BoolsTest() {
            Random random = new();

            int trues = 0, falses = 0;

            foreach (int length in new int[] { 7, 8, 9, 15, 16, 17 }) {
                Console.WriteLine(length);

                foreach (bool b in random.NextBools(length)) {
                    Console.WriteLine(b);

                    if (b) {
                        trues++;
                    }
                    else {
                        falses++;
                    }
                }
            }

            Console.WriteLine($"true: {trues}");
            Console.WriteLine($"false: {falses}");
        }

        [TestMethod]
        public void RangeTest() {
            Random random = new();

            for (int i = 0; i < 10; i++) {
                Console.WriteLine(random.NextRange(0.1, 0.5));
            }
        }

        [TestMethod]
        public void ChoiceTest() {
            Random random = new();

            IEnumerable<int> xs = new int[] { 1, 2, 3, 4 };

            for (int i = 0; i < 10; i++) {
                Console.WriteLine(random.Choice(xs));
            }

            for (int i = 0; i < 10; i++) {
                Console.WriteLine(random.Choice(new int[] { 5, 6, 7, 8 }));
            }
        }
    }
}
