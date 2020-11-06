using System;
using System.Linq;

namespace GeneticOptimize {
    public class EnumState<T> : State<EnumPhene<T>, EnumCodon<T>> where T : Enum {

        public EnumState(params int[][] effects)
            : base((new EnumPhene<T>[effects[0].Length]).Select((_, i) => new EnumPhene<T>(effects.Select((e) => e[i]).ToArray())).ToArray())  { 
        }
    }
}
