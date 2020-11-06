using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticOptimize {
    public class IntPhene : IPhene<IntCodon> {
        public int[] Effects { private set; get; }

        public IntPhene(params int[] effects) {
            this.Effects = (int[])effects.Clone();
        }

        public int Effect(IntCodon codon) {
            return Effects[codon.Code];
        }
    }
}
