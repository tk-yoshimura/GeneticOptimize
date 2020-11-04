using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticOptimize {
    public class BoolGene : Gene<BoolCodon> {

        public BoolGene(BoolCodon[] codons) 
            : base(codons){ }

        public BoolGene(Random ramdom, int length) 
            : this((new BoolCodon[length]).Select((c) => new BoolCodon(ramdom)).ToArray()){ }
    }
}
