using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticOptimize {
    public class Gene<Codon> where Codon : ICodon {
        public Codon[] Codons { get; }

        public int Length => Codons.Length;

        public Gene(Codon[] codons) {
            this.Codons = codons;
        }

        internal Gene(Gene<Codon> gene) { 
            this.Codons = gene.Codons;
        }

        public virtual void Mutate(Random random, double mutate_rate = 0.1) { 
            for(int i = 0; i < Codons.Length; i++) { 
                if(random.NextBool(mutate_rate)) { 
                    Codons[i].Mutate(random);
                }
            }
        }

        internal static Codon[] Crossover(Random random, Gene<Codon> gene1, Gene<Codon> gene2) { 
            if(gene1.Length != gene2.Length) { 
                throw new ArgumentException(nameof(Length));
            }

            int length = gene1.Length;

            Codon[] codons = new Codon[length];
            bool[] bs = random.NextBools(length).ToArray();

            for(int i = 0; i < length; i++) { 
                codons[i] = bs[i] ? gene1.Codons[i] : gene2.Codons[i];
            }

            return codons;
        }

        public override string ToString() {
            return string.Join(',', Codons);
        }
    }
}
