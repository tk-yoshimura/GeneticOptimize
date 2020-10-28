using GeneticOptimize;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace GeneticOptimizeTest {
    [TestClass]
    public class EnumCodonTest {
        enum Color { 
            Red, Green, Blue
        }

        [TestMethod]
        public void CreateTest() {
            Random random = new Random();

            for(int i = 0; i < 10; i++) { 
                var codon = new EnumCodon<Color>(random);

                Console.WriteLine(codon);
            }
        }

        [TestMethod]
        public void MutateTest() {
            Random random = new Random();

            var codon = new EnumCodon<Color>(random);

            Console.WriteLine(codon);

            for(int i = 0; i < 10; i++) { 
                codon.Mutate(random);
                Console.WriteLine(codon);
            }
        }
    }
}
