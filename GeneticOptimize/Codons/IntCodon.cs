using System;

namespace GeneticOptimize {

    /// <summary>整数値コドン</summary>
    public struct IntCodon : ICodon {

        /// <summary>コード</summary>
        public int Code { private set; get; }

        /// <summary>コード数</summary>
        public int Indexes { private set; get; }

        /// <summary>コンストラクタ</summary>
        public IntCodon(Random random, int indexes)
            : this(random.Next(indexes), indexes) { }
    
        /// <summary>コンストラクタ</summary>
        public IntCodon(int code, int indexes) {
            if (indexes < 1) { 
                throw new ArgumentException(nameof(indexes));
            }
            if(code >= indexes) { 
                throw new ArgumentException(nameof(code));
            }

            this.Code = code;
            this.Indexes = indexes;
        }

        /// <summary>codon to code</summary>
        public static implicit operator int(IntCodon codon) {
            return codon.Code;
        }

        /// <summary>変異</summary>
        public void Mutate(Random random) {
            Code = random.Next(Indexes); 
        }

        /// <summary>文字列化</summary>
        public override string ToString() {
            return Code.ToString();
        }

        /// <summary>クローン</summary>
        public object Clone() {
            return new IntCodon(Code, Indexes);
        }
    }
}
