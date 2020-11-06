using System;

namespace GeneticOptimize {
    public class NapsackOptimizer : Optimizer<BoolCodon> {
        protected readonly long MaxWeight;
        protected readonly BoolState Values, Weights;

        public NapsackOptimizer(int items, int[] values, int[] weights, long max_weight, int genes = 1000, int gene_saves = 20, double mutate_prob = 0.05)
            : base(items, genes, gene_saves, mutate_prob) {

            if (items != values.Length || items != weights.Length) {
                throw new ArgumentException(nameof(items));
            }

            this.Values = new BoolState(values);
            this.Weights = new BoolState(weights);
            this.MaxWeight = max_weight;
        }

        public long BestValue => Values.Effect(BestGene);

        public long BestWeight => Weights.Effect(BestGene);

        public override Gene<BoolCodon> CreateGene(Random random) {
            return new BoolGene(random, Items);
        }

        public override long Evaluate(Gene<BoolCodon> gene) {
            return Values.Effect(gene);
        }

        public override bool IsValid(Gene<BoolCodon> gene) {
            return Weights.Effect(gene) <= MaxWeight;
        }
    }
}
