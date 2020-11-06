using System.Linq;

namespace GeneticOptimize {
    public class IntState : State<IntPhene, IntCodon> {

        public IntState(params int[][] effects)
            : base((new IntPhene[effects[0].Length]).Select((_, i) => new IntPhene(effects.Select((e) => e[i]).ToArray())).ToArray()) {
        }
    }
}
