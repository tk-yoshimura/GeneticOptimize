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

        public static EnumGene<T> Crossover(Random random, EnumGene<T> gene1, EnumGene<T> gene2) { 
            return new EnumGene<T>(Gene<EnumCodon<T>>.Crossover(random, gene1, gene2));
        } 
    }
}
