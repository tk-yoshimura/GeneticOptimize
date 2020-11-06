using System;

namespace GeneticOptimize {

    public abstract class Gene<Codon> where Codon : ICodon {
        public Codon[] Codons { protected set; get; }

        public int Length => Codons.Length;

        protected Gene() { }

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

            int i = 0;
            foreach(bool b in random.NextBools(length)) { 
                Codons[i] = b ? gene1[i] : gene2[i];
                i++;
            }
        }

        public override string ToString() {
            return string.Join(',', Codons);
        }
    }
}
