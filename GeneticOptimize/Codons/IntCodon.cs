using System;

namespace GeneticOptimize {

    /// <summary>整数値コドン</summary>
    public struct IntCodon : ICodon {

        /// <summary>コード</summary>
        public int Code { private set; get; }

        /// <summary>コード最小値</summary>
        public int Min { private set; get; }

        /// <summary>コード最大値</summary>
        public int Max { private set; get; }

        /// <summary>コンストラクタ</summary>
        public IntCodon(Random random, int min, int max)
            : this(random.Next(min, max + 1), min, max) { }
    
        /// <summary>コンストラクタ</summary>
        public IntCodon(int code, int min, int max) { 
            if(!(min < max)) { 
                throw new ArgumentException($"{nameof(min)}, {nameof(max)}");
            }
            if(code < min || max < code) { 
                throw new ArgumentException(nameof(code));
            }

            this.Code = code;
            this.Min = min;
            this.Max = max;
        }

        /// <summary>codon to code</summary>
        public static implicit operator int(IntCodon codon) {
            return codon.Code;
        }

        /// <summary>変異</summary>
        public void Mutate(Random random) {
            Code = random.NextBool() ? Math.Max(Min, Code - 1) : Math.Min(Max, Code + 1); 
        }

        /// <summary>文字列化</summary>
        public override string ToString() {
            return Code.ToString();
        }

        /// <summary>クローン</summary>
        public object Clone() {
            return new IntCodon(Code, Min, Max);
        }
    }
}
