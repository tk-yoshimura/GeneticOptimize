namespace GeneticOptimize {
    public class BoolPhene : IPhene<BoolCodon> {
        public int TrueEffect { private set; get; }

        public int FalseEffect { private set; get; }

        public BoolPhene(int true_effect, int false_effect = 0) {
            this.TrueEffect = true_effect;
            this.FalseEffect = false_effect;
        }

        public int Effect(BoolCodon codon) {
            return codon.Code ? TrueEffect : FalseEffect;
        }
    }
}
