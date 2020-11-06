namespace GeneticOptimize {
    public interface IPhene<Codon> where Codon : ICodon {
        int Effect(Codon codon);
    }
}
