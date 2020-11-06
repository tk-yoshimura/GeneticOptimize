using System;
using System.Linq;
using System.Collections.Generic;

namespace GeneticOptimize {
    public abstract class Optimizer<Codon> where Codon : ICodon {
        protected readonly int Items;
        protected readonly Gene<Codon>[] GenePool;
        protected readonly long[] Evals;

        protected readonly int Genes, GeneSaves;
        protected readonly double MutateProb;

        public Optimizer(int items, int genes = 1000, int gene_saves = 20, double mutate_prob = 0.05) {
            if (items < 1) {
                throw new ArgumentException(nameof(items));
            }
            if (genes < gene_saves || genes < 1 || gene_saves < 1) { 
                throw new ArgumentException($"{nameof(genes)},{nameof(gene_saves)}");
            }
            if (!(mutate_prob > 0) || mutate_prob > 1) {
                throw new ArgumentException(nameof(mutate_prob));
            }

            this.Items = items;
            this.Genes = genes;
            this.GeneSaves = gene_saves;
            this.MutateProb = mutate_prob;
            this.GenePool = new Gene<Codon>[genes];
            this.Evals = new long[genes];
        }

        public IEnumerable<Gene<Codon>> BestGenes => GenePool.Take(GeneSaves);

        public Gene<Codon> BestGene => GenePool.First();

        public abstract Gene<Codon> CreateGene(Random random);

        public abstract long Evaluate(Gene<Codon> gene);

        public abstract bool IsValid(Gene<Codon> gene);

        public void Initialize(Random random) {
            int i = 0;
            while (i < Genes) {
                Gene<Codon> gene = CreateGene(random);
                if (!IsValid(gene)) {
                    continue;
                }

                GenePool[i] = gene;
                Evals[i] = Evaluate(gene);

                i++;
            }

            Sort();
        }

        public void NextGeneration(Random random) {
            int i = GeneSaves;
            while (i < Genes) {
                Gene<Codon> gene = GenePool[i];
                gene.Crossover(random, GenePool[random.Next(GeneSaves)], GenePool[random.Next(GeneSaves)]);
                gene.Mutate(random, MutateProb);

                if (!IsValid(gene)) {
                    continue;
                }

                GenePool[i] = gene;
                Evals[i] = Evaluate(gene);

                i++;
            }

            Sort();
        }

        public void SkipGeneration(Random random, int generation) {
            while (generation > 0) {
                NextGeneration(random);

                generation--;
            }
        }

        public void Sort() {
            Array.Sort(Evals, GenePool);
            Array.Reverse(Evals);
            Array.Reverse(GenePool);
        }
    }
}
