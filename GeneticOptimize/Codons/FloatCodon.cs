using System;

namespace GeneticOptimize {

    /// <summary>実数値コドン</summary>
    public struct FloatCodon : ICodon {

        /// <summary>コード</summary>
        public double Code { private set; get; }

        /// <summary>コード最小値</summary>
        public double Min { private set; get; }

        /// <summary>コード最大値</summary>
        public double Max { private set; get; }

        /// <summary>変位量</summary>
        public double Displacement { set; get; }

        /// <summary>コンストラクタ</summary>
        public FloatCodon(Random random, double min, double max, double displacement) { 
        
            if(!(min < max)) { 
                throw new ArgumentException($"{nameof(min)}, {nameof(max)}");
            }
            if((max - min) <= displacement) { 
                throw  new ArgumentException(nameof(displacement));
            }

            this.Code = Math.Truncate(random.NextRange(min, max) / displacement) * displacement;
            this.Min = min;
            this.Max = max;
            this.Displacement = displacement;
        }
        
        /// <summary>コンストラクタ</summary>
        public FloatCodon(double code, double min, double max, double displacement) { 
            if(!(min < max)) { 
                throw new ArgumentException($"{nameof(min)}, {nameof(max)}");
            }
            if(code < min || max < code) { 
                throw new ArgumentException(nameof(code));
            }
            if((max - min) <= displacement) { 
                throw  new ArgumentException(nameof(displacement));
            }

            this.Code = code;
            this.Min = min;
            this.Max = max;
            this.Displacement = displacement;
        }

        /// <summary>codon to code</summary>
        public static implicit operator double(FloatCodon codon) {
            return codon.Code;
        }

        /// <summary>変異</summary>
        public void Mutate(Random random) {
            Code = random.NextBool() ? Math.Max(Min, Code - Displacement) : Math.Min(Max, Code + Displacement); 
        }

        /// <summary>文字列化</summary>
        public override string ToString() {
            return Code.ToString();
        }

        /// <summary>文字列化</summary>
        public string ToString(string format = "F2") {
            return Code.ToString(format);
        }

        /// <summary>クローン</summary>
        public object Clone() {
            return new FloatCodon(Code, Min, Max, Displacement);
        }
    }
}
