using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticOptimize {
    public interface IPhene<Codon> where Codon : ICodon {
        int Effect(Codon codon);
    }
}
