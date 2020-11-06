using System;
using System.Linq;

namespace GeneticOptimize {
    public class IntGene : Gene<IntCodon>  {

        public IntGene(Random random, int length, int min, int max) {
            Codons = (new IntCodon[length]).Select((_) => new IntCodon(random, min, max)).ToArray();
        }
    }
}
