using GeneticOptimize;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace GeneticOptimizeTest {
    [TestClass]
    public class IntCodonTest {
        [TestMethod]
        public void CreateTest() {
            Random random = new Random();

            var codon = new IntCodon(random, 2, 5);

            Assert.IsTrue(2 <= codon && codon <= 5);
        }

        [TestMethod]
        public void MutateTest() {
            Random random = new Random();

            var codon = new IntCodon(random, 2, 5);

            Console.WriteLine(codon);

            codon.Mutate(random);

            Assert.IsTrue(2 <= codon && codon <= 5);

            Console.WriteLine(codon);
        }
    }
}
