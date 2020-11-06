using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticOptimize {
    public class State<Phene, Codon> where Phene : IPhene<Codon> where Codon : ICodon {

        private Phene[] Phenes { set; get; }

        public State(Phene[] phenes) {
            this.Phenes = (Phene[])phenes.Clone();
        }

        public long Effect(Gene<Codon> gene) {
            if (gene.Length != Phenes.Length) {
                throw new ArgumentException(nameof(gene));
            }

            long sum = 0;

            for (int i = 0; i < Phenes.Length; i++) {
                sum += Phenes[i].Effect(gene[i]);
            }

            return sum;
        }
    }
}
