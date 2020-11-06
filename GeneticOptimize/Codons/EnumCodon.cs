using System;

namespace GeneticOptimize {

    /// <summary>列挙値コドン</summary>
    public struct EnumCodon<T> : ICodon where T : Enum {

        public static T[] Values { get; } = (T[])Enum.GetValues(typeof(T));

        public static int N { get; } = Values.Length;

        /// <summary>コード</summary>
        public int Code { private set; get; }

        /// <summary>コンストラクタ</summary>
        public EnumCodon(Random random) { 
            Code = random.Next(N);
        }

        /// <summary>コンストラクタ</summary>
        public EnumCodon(T code) { 
            this.Code = Array.IndexOf(Values, code);
        }

        /// <summary>コンストラクタ</summary>
        private EnumCodon(int code) { 
            this.Code = code;
        }

        /// <summary>codon to code</summary>
        public static implicit operator T(EnumCodon<T> codon) {
            return Values[codon.Code];
        }

        /// <summary>変異</summary>
        public void Mutate(Random random) {
            Code = random.Next(N);
        }

        /// <summary>文字列化</summary>
        public override string ToString() {
            return Values[Code].ToString();
        }

        /// <summary>クローン</summary>
        public object Clone() {
            return new EnumCodon<T>(Code);
        }
    }
}
