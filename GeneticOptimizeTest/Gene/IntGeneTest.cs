using GeneticOptimize;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace GeneticOptimizeTest {
    [TestClass]
    public class IntGeneTest {
        [TestMethod]
        public void CreateTest() {
            Random random = new Random();

            IntGene gene = new IntGene(random, 10, 2, 5);

            Console.WriteLine(gene);
        }

        [TestMethod]
        public void MutateTest() {
            Random random = new Random();

            IntGene gene = new IntGene(random, 10, 2, 5);

            Console.WriteLine(gene);

            gene.Mutate(random, 0.2);

            Console.WriteLine(gene);
        }

        [TestMethod]
        public void CrossoverTest() {
            Random random = new Random();

            IntGene gene1 = new IntGene(random, 10, 2, 5);
            IntGene gene2 = new IntGene(random, 10, 2, 5);

            Console.WriteLine(gene1);
            Console.WriteLine(gene2);

            IntGene gene_cross = IntGene.Crossover(random, gene1, gene2);

            Console.WriteLine(gene_cross);
        }
    }
}
