using GeneticOptimize;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace GeneticOptimizeTest {

    [TestClass]
    public class NapsackOptimizerTest {

        [TestMethod]
        public void OptimizeTest() {
            const int items = 20, generations = 50;
            const long max_weight = 40;

            int[] values = new int[items] { 10, 8, 6, 5, 6, 7, 4, 20, 5, 6, 3, 7, 8, 9, 2, 15, 20, 20, 2, 6 };
            int[] weights = new int[items] { 7, 6, 7, 4, 5, 3, 10, 5, 4, 4, 5, 9, 2, 5, 4, 7, 8, 9, 10, 22 };

            Random random = new Random();

            NapsackOptimizer napsack = new NapsackOptimizer(items, values, weights, max_weight, genes:20, gene_saves:5, mutate_prob: 0.1);

            napsack.Initialize(random);

            Console.WriteLine($"V={napsack.BestValue}, W={napsack.BestWeight}");

            for (int i = 0; i < generations; i++) {
                napsack.NextGeneration(random);

                Console.WriteLine($"V={napsack.BestValue}, W={napsack.BestWeight}");
            }

            Console.WriteLine(napsack.BestGene);
        }
    }
}
