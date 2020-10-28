using GeneticOptimize;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace GeneticOptimizeTest {
    [TestClass]
    public class FloatGeneTest {
        [TestMethod]
        public void CreateTest() {
            Random random = new Random();

            FloatGene gene = new FloatGene(random, 10, 2, 5, 0.1);

            Console.WriteLine(gene);
        }

        [TestMethod]
        public void MutateTest() {
            Random random = new Random();

            FloatGene gene = new FloatGene(random, 10, 2, 5, 0.1);

            Console.WriteLine(gene);

            gene.Mutate(random, 0.2);

            Console.WriteLine(gene.ToString());
        }

        [TestMethod]
        public void CrossoverTest() {
            Random random = new Random();

            FloatGene gene1 = new FloatGene(random, 10, 2, 5, 0.1);
            FloatGene gene2 = new FloatGene(random, 10, 2, 5, 0.1);

            Console.WriteLine(gene1);
            Console.WriteLine(gene2);

            FloatGene gene_cross = FloatGene.Crossover(random, gene1, gene2);

            Console.WriteLine(gene_cross);
        }
    }
}
