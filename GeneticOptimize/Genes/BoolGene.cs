using System;
using System.Linq;

namespace GeneticOptimize {
    public class BoolGene : Gene<BoolCodon> {

        public BoolGene(Random random, int length) {
            Codons = random.NextBools(length).Select((b) => new BoolCodon(b)).ToArray();
        }
    }
}
