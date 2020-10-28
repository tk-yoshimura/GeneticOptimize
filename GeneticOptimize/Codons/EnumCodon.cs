using System;

namespace GeneticOptimize {

    /// <summary>列挙値コドン</summary>
    public struct EnumCodon<T> : ICodon where T : Enum {

        public static T[] Values { get; } = (T[])Enum.GetValues(typeof(T));

        public static int N { get; } = Values.Length;

        /// <summary>コード</summary>
        public T Code { private set; get; }

        /// <summary>コンストラクタ</summary>
        public EnumCodon(Random random) { 
            Code = Values[random.Next(Values.Length)];
        }

        /// <summary>コンストラクタ</summary>
        public EnumCodon(T code) { 
            this.Code = code;
        }

        /// <summary>codon to code</summary>
        public static implicit operator T(EnumCodon<T> codon) {
            return codon.Code;
        }

        /// <summary>変異</summary>
        public void Mutate(Random random) {
            Code = Values[random.Next(Values.Length)];
        }

        /// <summary>文字列化</summary>
        public override string ToString() {
            return Code.ToString();
        }

        /// <summary>クローン</summary>
        public object Clone() {
            return new EnumCodon<T>(Code);
        }
    }
}
