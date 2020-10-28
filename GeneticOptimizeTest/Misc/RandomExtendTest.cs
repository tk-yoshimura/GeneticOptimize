using GeneticOptimize;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace GeneticOptimizeTest {
    [TestClass]
    public class RandomExtendTest {
        [TestMethod]
        public void BoolTest() {
            Random random = new Random();

            for(int i = 0; i < 10; i++) { 
                Console.WriteLine(random.NextBool());
            }

            for(int i = 0; i < 10; i++) { 
                Console.WriteLine(random.NextBool(0.2));
            }
        }

        [TestMethod]
        public void BoolsTest() {
            Random random = new Random();

            int trues = 0, falses = 0;

            foreach(int length in new int[]{ 7, 8, 9, 15, 16, 17 }) { 
                Console.WriteLine(length);
                
                foreach(bool b in random.NextBools(length)) { 
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
            Random random = new Random();

            for(int i = 0; i < 10; i++) { 
                Console.WriteLine(random.NextRange(0.1, 0.5));
            }
        }
    }
}
