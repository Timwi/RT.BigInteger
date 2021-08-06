using System;
using System.Linq;
using System.Text;

namespace RT.BigInteger
{
    /// <summary>Encapsulates an arbitrary-size integer.</summary>
    public struct BigInt : IComparable<BigInt>, IEquatable<BigInt>
    {
        // If the number fits into a single Int32, this is null
        private readonly uint[] _value;

        // If the number fits into a single Int32, this is the actual value.
        // Otherwise, 0 = positive; -1 = negative
        private int _sign;

        private BigInt(uint[] value, int sign)
        {
            if (value == null)
                goto defaultCase;

            if (sign != 0 && sign != -1)
                throw new ArgumentException("sign must be 0 (positive) or -1 (negative).", nameof(sign));

            // Check if we can reduce the array to a single value
            if (value.Length == 0)
            {
                _value = null;
                _sign = 0;
                return;
            }
            if (value.Length == 1 && (sign == 0 ^ value[0] >= 0x80000000U))
            {
                _value = null;
                _sign = unchecked((int) value[0]);
                return;
            }

            // Check if we can halve the size of the array
            var ix = value.Length / 2;
            for (; ix < value.Length; ix++)
                if (value[ix] != unchecked((uint) sign))
                    goto defaultCase;
            ix = value.Length / 2;
            while (ix > 0 && value[ix - 1] == unchecked((uint) sign))
                ix--;

            // Check if we can reduce the array to a single value
            if (ix <= 1 && (sign == 0 ^ value[0] >= 0x80000000U))
            {
                _value = null;
                _sign = unchecked((int) value[0]);
                return;
            }

            if (value.Length < 8)  // avoid re-allocating new arrays when they’re already pretty small
                goto defaultCase;

            _value = new uint[ix];
            Array.Copy(value, 0, _value, 0, ix);
            _sign = sign;
            return;

            defaultCase:
            _value = value;
            _sign = sign;
        }

        /// <summary>Constructs a <see cref="BigInt"/> from a 32-bit signed integer.</summary>
        public BigInt(int value) : this(null, value) { }

        /// <summary>Constructs a <see cref="BigInt"/> from a 64-bit unsigned integer.</summary>
        public BigInt(ulong value)
        {
            if (value <= int.MaxValue)
            {
                _value = null;
                _sign = (int) value;
            }
            else
            {
                _value = new uint[] { unchecked((uint) value), (uint) (value >> 32) };
                _sign = 0;
            }
        }

        /// <summary>Constructs a <see cref="BigInt"/> from a 64-bit signed integer.</summary>
        public BigInt(long value)
        {
            if (value <= int.MaxValue && value >= int.MinValue)
            {
                _value = null;
                _sign = (int) value;
            }
            else
            {
                _value = new uint[] { unchecked((uint) value), unchecked((uint) (value >> 32)) };
                _sign = unchecked((int) value >> 63);
            }
        }

        /// <summary>Constructs a <see cref="BigInt"/> from a 32-bit signed integer.</summary>
        public static implicit operator BigInt(int value) => new BigInt(null, value);
        /// <summary>Constructs a <see cref="BigInt"/> from a 32-bit unsigned integer.</summary>
        public static implicit operator BigInt(uint value) => new BigInt(value);
        /// <summary>Constructs a <see cref="BigInt"/> from a 64-bit signed integer.</summary>
        public static implicit operator BigInt(long value) => new BigInt(value);
        /// <summary>Constructs a <see cref="BigInt"/> from a 64-bit unsigned integer.</summary>
        public static implicit operator BigInt(ulong value) => new BigInt(value);
        /// <summary>Constructs a <see cref="BigInt"/> from an 8-bit signed integer.</summary>
        public static implicit operator BigInt(sbyte value) => new BigInt(null, value);
        /// <summary>Constructs a <see cref="BigInt"/> from an 8-bit unsigned integer.</summary>
        public static implicit operator BigInt(byte value) => new BigInt(value);
        /// <summary>Constructs a <see cref="BigInt"/> from a 16-bit signed integer.</summary>
        public static implicit operator BigInt(ushort value) => new BigInt(value);
        /// <summary>Constructs a <see cref="BigInt"/> from a 16-bit unsigned integer.</summary>
        public static implicit operator BigInt(short value) => new BigInt(value);

        /// <summary>Determines whether the integer is 0.</summary>
        public bool IsZero => _value == null && _sign == 0;

        /// <summary>Returns the negative value.</summary>
        public BigInt Negative
        {
            get
            {
                if (_value == null)
                {
                    var negL = -(long) _sign;
                    var negI = unchecked((int) negL);
                    if (negL == negI)
                        return new BigInt(null, negI);
                    return new BigInt(new uint[] { unchecked((uint) negL), (uint) (negL >> 32) }, negL > 0 ? 0 : -1);
                }

                var neg = add(this, new BigInt(null, -1), subtract: false);
                if (neg._value == null)
                    return new BigInt(null, ~neg._sign);
                for (var i = 0; i < neg._value.Length; i++)
                    neg._value[i] = ~neg._value[i];
                neg._sign = ~neg._sign;
                return neg;
            }
        }
        /// <summary>Returns the negative value.</summary>
        public static BigInt operator -(BigInt op) => op.Negative;

        /// <summary>Returns the absolute value.</summary>
        public BigInt AbsoluteValue => _sign < 0 ? Negative : this;

        /// <summary>Returns the bitwise inverse (bitwise NOT).</summary>
        public BigInt Inverse
        {
            get
            {
                if (_value == null)
                    return new BigInt(null, ~_sign);
                var val = (uint[]) _value.Clone();
                for (var i = 0; i < val.Length; i++)
                    val[i] = ~val[i];
                return new BigInt(val, ~_sign);
            }
        }
        /// <summary>Returns the bitwise inverse (bitwise NOT).</summary>
        public static BigInt operator ~(BigInt op) => op.Inverse;

        /// <summary>Returns whether the bit at <paramref name="index"/> is 1 (regardless of the integer’s sign).</summary>
        public bool GetBit(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "index cannot be negative.");
            if (_value == null)
                return index >= 31 ? (_sign < 0) : ((_sign & (1 << index)) != 0);
            var pos = index >> 5;   // = index / 32 (optimized)
            return pos >= _value.Length ? (_sign < 0) : ((_value[pos] & (1 << (index & 0x1f))) != 0);
        }

        /// <summary>
        ///     Returns the bit-index of the most significant bit in this number. If the number is positive, this is the index
        ///     of the most significant ‘1’ bit. If the number is negative, it is the index of the most significant ‘0’ bit.
        ///     If the number is zero, the result is <c>-1</c>.</summary>
        public int MostSignificantBit
        {
            get
            {
                uint examine;
                int ix;
                if (_value == null)
                {
                    examine = unchecked((uint) _sign);
                    ix = 0;
                }
                else
                {
                    ix = _value.Length - 1;
                    while (ix > 0 && _value[ix] == _sign)
                        ix--;
                    examine = _value[ix];
                }
                var signBit = _sign < 0;
                var bitIx = 31;
                while (bitIx >= 0 && (((examine & (1u << bitIx)) != 0) == signBit))
                    bitIx--;
                return bitIx + 32 * ix;
            }
        }

        /// <summary>
        ///     Returns the result of a bit-shift-right by the specified <paramref name="amount"/>. This is equivalent to
        ///     dividing by 2 to the power of <paramref name="amount"/> and rounding down.</summary>
        public static BigInt operator >>(BigInt operand, int amount)
        {
            if (amount == 0)
                return operand;
            if (amount < 0)
                return operand << (-amount);

            if (operand._value == null)
                return new BigInt(null, operand._sign >> Math.Min(31, amount));

            // Opportunity to optimize the size of the array
            var ix = operand._value.Length;
            var ex = unchecked((uint) operand._sign);
            while (ix > 0 && operand._value[ix - 1] == ex)
                ix--;

            var amount32 = amount >> 5;
            if (amount32 >= ix)
                return new BigInt(null, operand._sign < 0 ? -1 : 0);
            var amountRest = amount & 0x1f;
            if (amount32 == ix - 1)
                return new BigInt(null, unchecked((int) ((operand._value[ix - 1] >> amountRest) | unchecked((uint) ((ulong) ex << (32 - amountRest))))));

            var nv = new uint[ix - amount32];
            for (var i = 0; i < nv.Length; i++)
                nv[i] = (operand._value[i + amount32] >> amountRest) | unchecked((uint) ((ulong) (i + amount32 + 1 >= operand._value.Length ? ex : operand._value[i + amount32 + 1]) << (32 - amountRest)));
            return new BigInt(nv, operand._sign);
        }

        /// <summary>
        ///     Returns the result of a bit-shift-left by the specified <paramref name="amount"/>. This is equivalent to
        ///     multiply by 2 to the power of <paramref name="amount"/>.</summary>
        public static BigInt operator <<(BigInt operand, int amount)
        {
            if (amount == 0 || (operand._value == null && (operand._sign == 0 || operand._sign == -1)))
                return operand;
            if (amount < 0)
                return operand >> (-amount);

            if (operand._value == null && amount < 32)
            {
                var shI = operand._sign << amount;
                if (((long) operand._sign) << amount == shI)
                    return new BigInt(null, shI);
            }

            var amount32 = amount >> 5;
            var amountRest = amount & 0x1f;
            if (operand._value == null)
            {
                var nnewLen = 1 + amount32;
                var nextra = (ulong) unchecked((uint) operand._sign) << amountRest != unchecked((uint) operand._sign) << amountRest;
                if (nextra)
                    nnewLen++;

                var nnv = new uint[nnewLen];
                nnv[amount32] = ((uint) operand._sign) << amountRest;
                if (nextra)
                    nnv[amount32 + 1] = (uint) (operand._sign >> (32 - amountRest));
                return new BigInt(nnv, operand._sign < 0 ? -1 : 0);
            }

            // Opportunity to optimize the size of the array
            var ix = operand._value.Length;
            while (ix > 0 && operand._value[ix - 1] == unchecked((uint) operand._sign))
                ix--;

            var newLen = ix + amount32;
            var extra = (ulong) operand._value[ix - 1] << amountRest != operand._value[ix - 1] << amountRest;
            var nv = new uint[extra ? newLen + 1 : newLen];
            nv[amount32] = operand._value[0] << amountRest;
            for (var i = amount32 + 1; i < newLen; i++)
                nv[i] = (operand._value[i - amount32] << amountRest) | (operand._value[i - amount32 - 1] >> (32 - amountRest));
            if (extra)
                nv[newLen] = operand._value[ix - 1] >> (32 - amountRest);
            return new BigInt(nv, operand._sign);
        }

        private static BigInt add(BigInt one, BigInt two, bool subtract)
        {
            if (one._value == null && two._value == null)
            {
                var sumL = subtract ? (long) one._sign - two._sign : (long) one._sign + two._sign;
                var sumI = unchecked((int) sumL);
                if (sumL == sumI)
                    return new BigInt(null, sumI);
                return new BigInt(new[] { unchecked((uint) sumI), unchecked((uint) ((ulong) sumL >> 32)) }, unchecked((int) (sumL >> 63)));
            }

            uint subtractor = subtract ? 0xffffffffu : 0u;
            var th = (two._sign < 0) ^ subtract ? 0xffffffffu : 0u;
            var l1 = one._value == null ? 1 : one._value.Length;
            var l2 = two._value == null ? 1 : two._value.Length;
            var len = Math.Max(l1, l2);

            var lastVal1 = one._value == null ? one._sign : unchecked((long) (one._value[one._value.Length - 1] | ((ulong) one._sign << 32)));
            var lastVal2 = two._value == null ? two._sign : unchecked((long) (two._value[two._value.Length - 1] | ((ulong) two._sign << 32)));
            var test = subtract ? (lastVal1 - lastVal2 - 1) : (lastVal1 + lastVal2 + 1);
            if (test != unchecked((int) test))
                len++;

            var nv = new uint[len];
            var sum =
                (ulong) (one._value == null ? unchecked((uint) one._sign) : one._value[0]) +
                (ulong) ((two._value == null ? unchecked((uint) two._sign) : two._value[0]) ^ subtractor) +
                (subtract ? 1ul : 0ul);
            nv[0] = unchecked((uint) sum);
            var carry = unchecked((uint) (sum >> 32));
            for (var i = 1; i < len; i++)
            {
                sum =
                    (ulong) (one._value == null ? 0u : i >= one._value.Length ? unchecked((uint) one._sign) : one._value[i]) +
                    (ulong) (two._value == null ? th : (i >= two._value.Length ? unchecked((uint) two._sign) : two._value[i]) ^ subtractor) +
                    (ulong) carry;
                nv[i] = unchecked((uint) sum);
                carry = unchecked((uint) (sum >> 32));
            }
            return new BigInt(nv, (one._sign < 0) ^ (two._sign < 0) ^ subtract ^ (carry != 0) ? -1 : 0);
        }
        /// <summary>Returns the sum of this integer plus <paramref name="other"/>.</summary>
        public BigInt Add(BigInt other) => add(this, other, subtract: false);
        /// <summary>Returns the sum of <paramref name="one"/> plus <paramref name="two"/>.</summary>
        public static BigInt operator +(BigInt one, BigInt two) => add(one, two, subtract: false);
        /// <summary>Returns the difference of <paramref name="one"/> minus <paramref name="two"/>.</summary>
        public static BigInt operator -(BigInt one, BigInt two) => add(one, two, subtract: true);

        private static BigInt multiply(BigInt one, BigInt two)
        {
            if (one.IsZero || two.IsZero)
                return new BigInt(null, 0);
            if (one._value == null && one._sign == 1)
                return two;
            if (two._value == null && two._sign == 1)
                return one;

            if (one._value == null && two._value == null)
            {
                var prL = (long) one._sign * two._sign;
                var prI = unchecked((int) prL);
                if (prI == prL)
                    return new BigInt(null, prI);
            }

            var nv = new uint[(one.MostSignificantBit + two.MostSignificantBit + 33) / 32];
            for (var i = 0; i < nv.Length; i++)
            {
                var vL = i == 0
                    ? one._value == null ? (uint) one._sign : one._value[0]
                    : (ulong) (one._value == null || i >= one._value.Length ? (uint) (one._sign >> 31) : one._value[i]);
                var mL = vL * unchecked(two._value == null ? unchecked((uint) two._sign) : two._value[0]) + nv[i];
                nv[i] = unchecked((uint) mL);
                var carry = unchecked((uint) (mL >> 32));
                for (var j = i + 1; j < nv.Length; j++)
                {
                    mL = vL * unchecked(two._value == null || j - i >= two._value.Length ? unchecked((uint) (two._sign >> 31)) : two._value[j - i]) + carry + nv[j];
                    nv[j] = unchecked((uint) mL);
                    carry = unchecked((uint) (mL >> 32));
                }
            }
            return new BigInt(nv, (one._sign >> 31) ^ (two._sign >> 31));
        }
        /// <summary>Returns the product of this integer times <paramref name="other"/>.</summary>
        public BigInt Multiply(BigInt other) => multiply(this, other);
        /// <summary>Returns the product of <paramref name="one"/> times <paramref name="two"/>.</summary>
        public static BigInt operator *(BigInt one, BigInt two) => multiply(one, two);

        private static QuotientRemainder divideModulo(BigInt one, BigInt two)
        {
            if (two.IsZero)
                throw new DivideByZeroException();

            if (one._value == null && two._value == null)
                return new QuotientRemainder(new BigInt(null, one._sign / two._sign), new BigInt(null, one._sign % two._sign));

            bool neg1 = false, neg2 = false;
            if (one._sign < 0)
            {
                one = -one;
                neg1 = true;
            }
            if (two._sign < 0)
            {
                two = -two;
                neg2 = true;
            }

            // This array starts out with the value of ‘one’ (the dividend). We will successively subtract left-shifted ‘two’s
            // from it until it is smaller than ‘two’, at which point it will contain the remainder.
            var rem = one._value == null ? new[] { unchecked((uint) one._sign) } : neg1 ? one._value : (uint[]) one._value.Clone();
            // Divisor.
            var div = two._value ?? new[] { unchecked((uint) two._sign) };

            var msb1 = one.MostSignificantBit + 1;
            var msb2 = two.MostSignificantBit + 1;
            var curShift = msb1 - msb2;     // how far left-shifted ‘two’ starts out
            uint[] quo = null;  // will contain the quotient at the end

            while (curShift >= 0)
            {
                // Find out whether the part of ‘rem’ that is aligned with ‘div’ is smaller than ‘div’ or not.
                var remBi = curShift % 32;
                for (var i = div.Length - 1; i >= 0; i--)
                {
                    var remBy = curShift / 32 + i;
                    var v = (rem[remBy] >> remBi) | (remBi == 0 || remBy + 1 >= rem.Length ? 0u : rem[remBy + 1] << (32 - remBi));

                    // If our ‘rem’ part is bigger than ‘div’, we want to place a bit in ‘quo’ and then subtract ‘div’ from ‘rem’.
                    if (v > div[i])
                        goto placeBit;

                    // If our ‘rem’ part is smaller than ‘div’, we want to shift over one bit and continue.
                    if (v < div[i])
                        goto nextShift;
                }

                // If we get here, the ‘rem’ part is equal to ‘div’, so we still want to place a bit and subtract

                placeBit:
                if (quo == null)
                    quo = new uint[curShift / 32 + 1];
                quo[curShift / 32] |= 1u << (curShift % 32);

                var carry = 0L;
                for (var i = 0; i < div.Length; i++)
                {
                    var remBy = curShift / 32 + i;
                    var more = remBi > 0 && remBy + 1 < rem.Length;
                    var valA = (rem[remBy] >> remBi);
                    var valB = (more ? rem[remBy + 1] << (32 - remBi) : 0u);
                    var valC = valA | valB;
                    var val = valC + carry - div[i];
                    if (more)
                        rem[remBy + 1] = (rem[remBy + 1] >> remBi << remBi) | unchecked((uint) val >> (32 - remBi));
                    rem[remBy] = unchecked((uint) ((rem[remBy] & ((1u << remBi) - 1)) | (val << remBi)));
                    carry = val >> 32;
                }

                nextShift:
                curShift--;
            }

            var r = new BigInt(rem, 0);
            var q = new BigInt(quo, 0); // if quo == null, the quotient is actually 0, so this works out nicely
            var finalQ = (neg1 ^ neg2) ? -q : q;
            var finalR = neg1 ? -r : r;
            return new QuotientRemainder(finalQ, finalR);
        }
        /// <summary>Calculates a quotient and remainder by dividing this integer by <paramref name="other"/>.</summary>
        public QuotientRemainder DivideModulo(BigInt other) => divideModulo(this, other);
        /// <summary>Returns the quotient obtained by dividing this integer by <paramref name="other"/>.</summary>
        public BigInt Divide(BigInt other) => divideModulo(this, other).Quotient;
        /// <summary>Returns the quotient obtained by dividing <paramref name="one"/> by <paramref name="two"/>.</summary>
        public static BigInt operator /(BigInt one, BigInt two) => divideModulo(one, two).Quotient;
        /// <summary>Returns the remainder obtained when dividing this integer by <paramref name="other"/>.</summary>
        public BigInt Modulo(BigInt other) => divideModulo(this, other).Remainder;
        /// <summary>Returns the remainder obtained when dividing <paramref name="one"/> by <paramref name="two"/>.</summary>
        public static BigInt operator %(BigInt one, BigInt two) => divideModulo(one, two).Remainder;

        /// <summary>Less-than comparison operator.</summary>
        public static bool operator <(BigInt one, BigInt two) => one.CompareTo(two) < 0;
        /// <summary>Greater-than comparison operator.</summary>
        public static bool operator >(BigInt one, BigInt two) => one.CompareTo(two) > 0;
        /// <summary>Less-than-or-equal-to comparison operator.</summary>
        public static bool operator <=(BigInt one, BigInt two) => one.CompareTo(two) <= 0;
        /// <summary>Greater-than-or-equal-to comparison operator.</summary>
        public static bool operator >=(BigInt one, BigInt two) => one.CompareTo(two) >= 0;
        /// <summary>Equality comparison operator.</summary>
        public static bool operator ==(BigInt one, BigInt two) => one.CompareTo(two) == 0;
        /// <summary>Inequality comparison operator.</summary>
        public static bool operator !=(BigInt one, BigInt two) => one.CompareTo(two) != 0;

        /// <summary>Override; see base.</summary>
        public override string ToString()
        {
            if (IsZero)
                return "0";
            var sb = new StringBuilder();
            var val = _sign < 0 ? -this : this;
            while (!val.IsZero)
            {
                var qr = val.DivideModulo(1000000000);
                if (qr.Remainder._value != null)
                    throw new InvalidOperationException("An internal error occurred in BigInt.ToString().");
                var str = qr.Remainder._sign.ToString();
                sb.Insert(0, str);
                val = qr.Quotient;
                if (!val.IsZero && str.Length < 9)
                    sb.Insert(0, new string('0', 9 - str.Length));
            }
            if (_sign < 0)
                sb.Insert(0, "-");
            return sb.ToString();
        }

        /// <summary>Compares this integer to <paramref name="other"/>.</summary>
        public int CompareTo(BigInt other)
        {
            if (_sign != other._sign)
                return _sign < other._sign ? -1 : 1;
            if (_value == null && other._value == null)
                return _sign.CompareTo(other._sign);

            for (var i = Math.Max(_value == null ? 0 : _value.Length - 1, other._value == null ? 0 : other._value.Length - 1); i >= 1; i--)
            {
                var v1 = _value == null || i >= _value.Length ? 0u : _value[i];
                var v2 = other._value == null || i >= other._value.Length ? 0u : other._value[i];
                if (v1 != v2)
                    return v1 < v2 ? -1 : 1;
            }
            var vv1 = _value == null ? unchecked((uint) _sign) : _value[0];
            var vv2 = other._value == null ? unchecked((uint) other._sign) : other._value[0];
            return vv1.CompareTo(vv2);
        }

        /// <summary>Equality comparison.</summary>
        public bool Equals(BigInt other) => CompareTo(other) == 0;

        /// <summary>Equality comparison.</summary>
        public override bool Equals(object obj) => obj is BigInt bi && CompareTo(bi) == 0;

        /// <summary>Hash code function.</summary>
        public override int GetHashCode() => _value == null ? _sign : unchecked((int) _value[0]);

        /// <summary>Increment operator.</summary>
        public static BigInt operator ++(BigInt operand) => add(operand, 1, subtract: false);
        /// <summary>Decrement operator.</summary>
        public static BigInt operator --(BigInt operand) => add(operand, 1, subtract: true);

        /// <summary>Bitwise or operator.</summary>
        public static BigInt operator |(BigInt one, BigInt two)
        {
            if (one._value == null)
            {
                if (two._value == null)
                    return new BigInt(null, one._sign | two._sign);
                if (one._sign < 0)
                    return new BigInt(null, one._sign | unchecked((int) two._value[0]));
                var nv = (uint[]) two._value.Clone();
                nv[0] |= unchecked((uint) one._sign);
                return new BigInt(nv, two._sign | (one._sign >> 31));
            }
            else if (two._value == null)
            {
                if (two._sign < 0)
                    return new BigInt(null, two._sign | unchecked((int) one._value[0]));
                var nv = (uint[]) one._value.Clone();
                nv[0] |= unchecked((uint) two._sign);
                return new BigInt(nv, one._sign | (two._sign >> 31));
            }
            else if (one._value.Length > two._value.Length ? two._sign >= 0 : one._sign < 0)
            {
                var nv = (uint[]) one._value.Clone();
                for (var i = two._value.Length - 1; i >= 0; i--)
                    nv[i] |= two._value[i];
                return new BigInt(nv, one._sign | two._sign);
            }
            else
            {
                var nv = (uint[]) two._value.Clone();
                for (var i = one._value.Length - 1; i >= 0; i--)
                    nv[i] |= one._value[i];
                return new BigInt(nv, two._sign | one._sign);
            }
        }

        /// <summary>Bitwise and operator.</summary>
        public static BigInt operator &(BigInt one, BigInt two)
        {
            if (one._value == null)
            {
                if (two._value == null)
                    return new BigInt(null, one._sign & two._sign);
                if (one._sign >= 0)
                    return new BigInt(null, one._sign & unchecked((int) two._value[0]));
                var nv = (uint[]) two._value.Clone();
                nv[0] &= unchecked((uint) one._sign);
                return new BigInt(nv, two._sign & (one._sign >> 31));
            }
            else if (two._value == null)
            {
                if (two._sign >= 0)
                    return new BigInt(null, two._sign & unchecked((int) one._value[0]));
                var nv = (uint[]) one._value.Clone();
                nv[0] &= unchecked((uint) two._sign);
                return new BigInt(nv, one._sign & (two._sign >> 31));
            }
            else if (one._value.Length > two._value.Length ? two._sign < 0 : one._sign >= 0)
            {
                var nv = (uint[]) one._value.Clone();
                for (var i = two._value.Length - 1; i >= 0; i--)
                    nv[i] &= two._value[i];
                return new BigInt(nv, one._sign & two._sign);
            }
            else
            {
                var nv = (uint[]) two._value.Clone();
                for (var i = one._value.Length - 1; i >= 0; i--)
                    nv[i] &= one._value[i];
                return new BigInt(nv, two._sign & one._sign);
            }
        }

        /// <summary>Bitwise xor operator.</summary>
        public static BigInt operator ^(BigInt one, BigInt two)
        {
            if (one._value == null && two._value == null)
                return new BigInt(null, one._sign ^ two._sign);

            var len = Math.Max(one._value == null ? 1 : one._value.Length, two._value == null ? 1 : two._value.Length);
            var sign = (one._sign >> 31) ^ (two._sign >> 31);
            uint[] nv = null;
            uint v;
            for (var i = len - 1; i >= 1; i--)
            {
                v = (one._value == null || i >= one._value.Length ? unchecked((uint) (one._sign >> 31)) : one._value[i])
                  ^ (two._value == null || i >= two._value.Length ? unchecked((uint) (two._sign >> 31)) : two._value[i]);
                if (v != sign)
                {
                    if (nv == null)
                        nv = new uint[i + 1];
                    nv[i] = v;
                }
            }
            v = (one._value == null ? unchecked((uint) one._sign) : one._value[0]) ^ (two._value == null ? unchecked((uint) two._sign) : two._value[0]);
            if (nv == null)
            {
                if ((v >> 31) == sign)
                    return new BigInt(null, unchecked((int) v));
                nv = new uint[1];
            }
            nv[0] = v;
            return new BigInt(nv, sign);
        }
    }
}
