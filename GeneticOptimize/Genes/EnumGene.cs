using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticOptimize {
    public class EnumGene<T> : Gene<EnumCodon<T>> where T : Enum  {

        public EnumGene(EnumCodon<T>[] codons) 
            : base(codons){ }

        public EnumGene(Random ramdom, int length) 
            : this((new EnumCodon<T>[length]).Select((c) => new EnumCodon<T>(ramdom)).ToArray()){ }
    }
}
