namespace RT.BigInteger
{
    /// <summary>Encapsulates the two-valued result of a division/modulo operation (<see cref="BigInt.DivideModulo(BigInt)"/>).</summary>
    public struct QuotientRemainder
    {
        /// <summary>The quotient (result of the integer division).</summary>
        public BigInt Quotient { get; private set; }
        /// <summary>The remainder (result of the modulo).</summary>
        public BigInt Remainder { get; private set; }

        /// <summary>Constructor.</summary>
        public QuotientRemainder(BigInt quotient, BigInt remainder)
        {
            Quotient = quotient;
            Remainder = remainder;
        }

        /// <summary>Deconstructor.</summary>
        public void Deconstruct(out BigInt quotient, out BigInt remainder)
        {
            quotient = Quotient;
            remainder = Remainder;
        }
    }
}
