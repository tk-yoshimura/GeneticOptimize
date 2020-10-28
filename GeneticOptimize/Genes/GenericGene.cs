using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticOptimize {
    public class GenericGene : Gene<ICodon> {

        public GenericGene(ICodon[] codons) 
            : base(codons){ }

        public static GenericGene Crossover(Random random, GenericGene gene1, GenericGene gene2) { 
            return new GenericGene(Gene<ICodon>.Crossover(random, gene1, gene2));
        } 
    }
}
