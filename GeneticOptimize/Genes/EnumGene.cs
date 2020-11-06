using System;
using System.Linq;

namespace GeneticOptimize {
    public class EnumGene<T> : Gene<EnumCodon<T>> where T : Enum  {

        public EnumGene(Random random, int length) {
            Codons = (new EnumCodon<T>[length]).Select((_) => new EnumCodon<T>(random)).ToArray();
        }
    }
}
