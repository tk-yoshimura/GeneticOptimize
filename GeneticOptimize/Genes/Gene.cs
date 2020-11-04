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

        public Codon this[int index] {
            set {
                Codons[index] = value;
            }
            get {
                return Codons[index];
            }
        }

        public void Mutate(Random random, double mutate_rate = 0.1) { 
            for(int i = 0; i < Length; i++) { 
                if(random.NextBool(mutate_rate)) { 
                    Codons[i].Mutate(random);
                }
            }
        }

        public void Crossover(Random random, Gene<Codon> gene1, Gene<Codon> gene2) { 
            if(gene1.Length != gene2.Length) { 
                throw new ArgumentException("Length");
            }

            int length = gene1.Length;

            bool[] bs = random.NextBools(length).ToArray();

            for(int i = 0; i < length; i++) { 
                Codons[i] = bs[i] ? gene1[i] : gene2[i];
            }
        }

        public override string ToString() {
            return string.Join(',', Codons);
        }
    }
}
