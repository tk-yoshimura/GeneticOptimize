using System;
using System.Linq;

namespace GeneticOptimize {
    public class IntGene : Gene<IntCodon>  {

        public IntGene(Random random, int length, int indexes) {
            Codons = (new IntCodon[length]).Select((_) => new IntCodon(random, indexes)).ToArray();
        }
    }
}
