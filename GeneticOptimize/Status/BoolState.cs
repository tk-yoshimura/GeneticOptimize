using System.Linq;

namespace GeneticOptimize {
    public class BoolState : State<BoolPhene, BoolCodon> {

        public BoolState(int[] true_effects, int[] false_effects)
            : base((new BoolPhene[true_effects.Length]).Select((_, i) => new BoolPhene(true_effects[i], false_effects[i])).ToArray())  { 
        }

        public BoolState(int[] true_effects)
            : base(true_effects.Select((n) => new BoolPhene(n)).ToArray())  { 
        }
    }
}
