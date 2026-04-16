namespace RT.BigInteger
{
    /// <summary>Encapsulates the two-valued result of a division/modulo operation (<see cref="BigInt.DivideModulo(BigInt)"/>).</summary>
    /// <remarks>Constructor.</remarks>
    public struct QuotientRemainder(BigInt quotient, BigInt remainder)
    {
        /// <summary>The quotient (result of the integer division).</summary>
        public BigInt Quotient { get; private set; } = quotient;
        /// <summary>The remainder (result of the modulo).</summary>
        public BigInt Remainder { get; private set; } = remainder;

        /// <summary>Deconstructor.</summary>
        public readonly void Deconstruct(out BigInt quotient, out BigInt remainder)
        {
            quotient = Quotient;
            remainder = Remainder;
        }
    }
}
