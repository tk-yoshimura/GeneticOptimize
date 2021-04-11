
using GeneticOptimize;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace GeneticOptimizeTest {
    [TestClass]
    public class EnumGeneTest {
        enum Color {
            Red, Green, Blue
        }

        [TestMethod]
        public void CreateTest() {
            Random random = new();

            EnumGene<Color> gene = new(random, 10);

            Console.WriteLine(gene);
        }

        [TestMethod]
        public void MutateTest() {
            Random random = new();

            EnumGene<Color> gene = new(random, 10);

            Console.WriteLine(gene);

            gene.Mutate(random, 0.2);

            Console.WriteLine(gene);
        }

        [TestMethod]
        public void CrossoverTest() {
            Random random = new();

            EnumGene<Color> gene1 = new(random, 10);
            EnumGene<Color> gene2 = new(random, 10);

            Console.WriteLine(gene1);
            Console.WriteLine(gene2);

            EnumGene<Color> gene_cross = new(random, 10);

            gene_cross.Crossover(random, gene1, gene2);

            Console.WriteLine(gene_cross);
        }
    }
}
