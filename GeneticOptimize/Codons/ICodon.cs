using System;

namespace GeneticOptimize {

    /// <summary>コドン</summary>
    public interface ICodon : ICloneable {

        /// <summary>変異</summary>
        void Mutate(Random random);
    }
}
