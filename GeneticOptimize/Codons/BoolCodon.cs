using System;

namespace GeneticOptimize {

    /// <summary>2値コドン</summary>
    public struct BoolCodon : ICodon {

        /// <summary>コード</summary>
        public bool Code { private set; get; }

        /// <summary>コンストラクタ</summary>
        public BoolCodon(Random random) {
            this.Code = random.NextBool();
        }

        /// <summary>コンストラクタ</summary>
        public BoolCodon(bool code) {
            this.Code = code;
        }

        /// <summary>codon to code</summary>
        public static implicit operator bool(BoolCodon codon) {
            return codon.Code;
        }

        /// <summary>code to codon</summary>
        public static implicit operator BoolCodon(bool code) {
            return new BoolCodon(code);
        }

        /// <summary>変異</summary>
        public void Mutate(Random random) {
            Code = !Code;
        }

        /// <summary>文字列化</summary>
        public override string ToString() {
            return Code.ToString();
        }

        /// <summary>クローン</summary>
        public object Clone() {
            return new BoolCodon(Code);
        }
    }
}
