using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticOptimize {
    public class FloatGene : Gene<FloatCodon> {

        public FloatGene(FloatCodon[] codons) 
            : base(codons){ }

        public FloatGene(Random ramdom, int length, double codon_min, double codon_max, double codon_displacement) 
            : this((new FloatCodon[length])
                  .Select((c) => new FloatCodon(ramdom, codon_min, codon_max, codon_displacement)).ToArray()){ }

        public static FloatGene Crossover(Random random, FloatGene gene1, FloatGene gene2) { 
            return new FloatGene(Gene<FloatCodon>.Crossover(random, gene1, gene2));
        } 

        /// <summary>文字列化</summary>
        public string ToString(string format = "F2") {
            return string.Join(',', Codons.Select((c) => c.ToString(format)));
        }
    }
}
