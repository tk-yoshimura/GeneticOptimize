
using GeneticOptimize;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace GeneticOptimizeTest {
    [TestClass]
    public class IntCodonTest {
        [TestMethod]
        public void CreateTest() {
            Random random = new();

            for (int i = 0; i < 100; i++) {
                var codon = new IntCodon(random, 5);

                Assert.IsTrue(0 <= codon && codon < 5);
            }
        }

        [TestMethod]
        public void MutateTest() {
            Random random = new();

            var codon = new IntCodon(random, 5);

            Console.WriteLine(codon);

            for (int i = 0; i < 100; i++) {
                codon.Mutate(random);

                Assert.IsTrue(0 <= codon && codon < 5);

                Console.WriteLine(codon);
            }
        }
    }
}
