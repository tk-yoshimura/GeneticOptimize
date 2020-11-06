using GeneticOptimize;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace GeneticOptimizeTest {
    [TestClass]
    public class BoolGeneTest {
        [TestMethod]
        public void CreateTest() {
            Random random = new Random();

            BoolGene gene = new BoolGene(random, 10);

            Console.WriteLine(gene);
        }

        [TestMethod]
        public void MutateTest() {
            Random random = new Random();

            BoolGene gene = new BoolGene(random, 10);

            Console.WriteLine(gene);

            gene.Mutate(random, 0.2);

            Console.WriteLine(gene);
        }

        [TestMethod]
        public void CrossoverTest() {
            Random random = new Random();

            BoolGene gene1 = new BoolGene(random, 10);
            BoolGene gene2 = new BoolGene(random, 10);

            Console.WriteLine(gene1);
            Console.WriteLine(gene2);

            BoolGene gene_cross = new BoolGene(random, 10);
            
            gene_cross.Crossover(random, gene1, gene2);

            Console.WriteLine(gene_cross);
        }
    }
}
