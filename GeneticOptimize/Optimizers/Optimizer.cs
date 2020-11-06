using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GeneticOptimize {
    public abstract class Optimizer<Codon> where Codon : ICodon {
        protected readonly Gene<Codon>[] GenePool;
        protected readonly long[] Evals;

        protected readonly int Genes, GeneSaves;
        protected readonly double MutateProb;

        public Optimizer(int genes = 1000, int gene_saves = 20, double mutate_prob = 0.05) {
            if (genes < gene_saves || genes < 1 || gene_saves < 1) { 
                throw new ArgumentException($"{nameof(genes)},{nameof(gene_saves)}");
            }
            if (!(mutate_prob > 0) || mutate_prob > 1) {
                throw new ArgumentException(nameof(mutate_prob));
            }
            
            this.Genes = genes;
            this.GeneSaves = gene_saves;
            this.MutateProb = mutate_prob;
            this.GenePool = new Gene<Codon>[genes];
            this.Evals = new long[genes];

            Initialize();
        }

        public IEnumerable<Gene<Codon>> BestGenes => GenePool.Take(GeneSaves);

        public abstract Gene<Codon> CreateGene();

        public abstract long Eval(Gene<Codon> gene);

        public abstract bool IsValid(Gene<Codon> gene);

        public void Initialize() {
            int i = 0;
            while (i < Genes) {
                Gene<Codon> gene = CreateGene();
                if (!IsValid(gene)) {
                    continue;
                }

                GenePool[i] = gene;
                Evals[i] = Eval(gene);

                i++;
            }

            Sort();
        }

        public void NextGeneration(Random random) {
            int i = GeneSaves;
            while (i < Genes) {
                Gene<Codon> gene = GenePool[i];
                gene.Crossover(random, GenePool[random.Next(GeneSaves)], GenePool[random.Next(GeneSaves)]);
                if (!IsValid(gene)) {
                    continue;
                }

                GenePool[i] = gene;
                Evals[i] = Eval(gene);

                i++;
            }

            Sort();
        }

        public void Sort() {
            Array.Sort(Evals, GenePool);
            Array.Reverse(Evals);
            Array.Reverse(GenePool);
        }
    }
}
