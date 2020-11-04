using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticOptimize {
    internal static class GeneOperator {
        
        public static void Mutate<Codon>(Random random, Gene<Codon> codons, double mutate_rate = 0.1) where Codon : ICodon { 
            for(int i = 0; i < codons.Length; i++) { 
                if(random.NextBool(mutate_rate)) { 
                    codons[i].Mutate(random);
                }
            }
        }

        public static Gene<Codon> Crossover<Codon>(Random random, Gene<Codon> gene1, Gene<Codon> gene2) where Codon : ICodon { 
            if(gene1.Length != gene2.Length) { 
                throw new ArgumentException("Length");
            }

            int length = gene1.Length;

            Codon[] codons = new Codon[length];
            bool[] bs = random.NextBools(length).ToArray();

            for(int i = 0; i < length; i++) { 
                codons[i] = bs[i] ? gene1[i] : gene2[i];
            }

            return new Gene<Codon>(codons);
        }
    }
}
