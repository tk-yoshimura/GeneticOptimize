using System;

namespace GeneticOptimize {
    public class EnumPhene<T> : IPhene<EnumCodon<T>> where T : Enum {
        public int[] Effects { private set; get; }

        public EnumPhene(params int[] effects) {
            if (effects.Length != EnumCodon<T>.N) {
                throw new ArgumentException(nameof(effects));
            }
            
            this.Effects = (int[])effects.Clone();
        }

        public int Effect(EnumCodon<T> codon) {
            return Effects[codon.Code];
        }
    }
}
