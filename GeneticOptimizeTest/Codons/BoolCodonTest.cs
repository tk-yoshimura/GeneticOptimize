
using GeneticOptimize;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace GeneticOptimizeTest {
    [TestClass]
    public class BoolCodonTest {
        [TestMethod]
        public void CreateTest() {
            Random random = new();

            var codon = new BoolCodon(random);

            CollectionAssert.Contains(new bool[] { true, false }, (bool)codon);
        }

        [TestMethod]
        public void MutateTest() {
            Random random = new();

            var codon = new BoolCodon(random);

            Console.WriteLine(codon);

            var code = codon;

            codon.Mutate(random);

            Assert.IsFalse(code == codon);

            Console.WriteLine(codon);
        }
    }
}
