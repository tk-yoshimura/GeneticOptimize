using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticOptimize {
    public class IntGene : Gene<IntCodon> {

        public IntGene(IntCodon[] codons) 
            : base(codons){ }

        public IntGene(Random ramdom, int length, int codon_min, int codon_max) 
            : this((new IntCodon[length])
                  .Select((c) => new IntCodon(ramdom, codon_min, codon_max)).ToArray()){ }
    }
}
