namespace RT.BigInteger.Tests
{
    [TestClass]
    public sealed class TestConversions
    {
        private void testConversion(BigInt value, string reference)
        {
            Assert.AreEqual(reference, value.ToString());
        }

        private void testConversionFromInt(int value)
        {
            // Test constructor
            testConversion(new BigInt(value), value.ToString());

            // Test implicit conversion
            testConversion(value, value.ToString());

            // Test explicit conversion
            testConversion((BigInt) value, value.ToString());
        }

        [TestMethod]
        public void TestConversionFromInt()
        {
            testConversionFromInt(-2147483648);
            testConversionFromInt(-2147483647);
            testConversionFromInt(-2147483601);
            testConversionFromInt(-65583);
            testConversionFromInt(-65537);
            testConversionFromInt(-65536);
            testConversionFromInt(-65535);
            testConversionFromInt(-65489);
            testConversionFromInt(-47);
            testConversionFromInt(-1);
            testConversionFromInt(0);
            testConversionFromInt(1);
            testConversionFromInt(47);
            testConversionFromInt(65489);
            testConversionFromInt(65535);
            testConversionFromInt(65536);
            testConversionFromInt(65537);
            testConversionFromInt(65583);
            testConversionFromInt(2147483601);
            testConversionFromInt(2147483647);
        }

        private void testConversionFromUInt(uint value)
        {
            // Test constructor
            testConversion(new BigInt(value), value.ToString());

            // Test implicit conversion
            testConversion(value, value.ToString());

            // Test explicit conversion
            testConversion((BigInt) value, value.ToString());
        }

        [TestMethod]
        public void TestConversionFromUInt()
        {
            testConversionFromUInt(0);
            testConversionFromUInt(1);
            testConversionFromUInt(47);
            testConversionFromUInt(65489);
            testConversionFromUInt(65535);
            testConversionFromUInt(65536);
            testConversionFromUInt(65537);
            testConversionFromUInt(65583);
            testConversionFromUInt(2147483601);
            testConversionFromUInt(2147483647);
            testConversionFromUInt(2147483648);
            testConversionFromUInt(2147483649);
            testConversionFromUInt(2147483695);
            testConversionFromUInt(4294967249);
            testConversionFromUInt(4294967295);
        }

        private void testConversionFromLong(long value)
        {
            // Test constructor
            testConversion(new BigInt(value), value.ToString());

            // Test implicit conversion
            testConversion(value, value.ToString());

            // Test explicit conversion
            testConversion((BigInt) value, value.ToString());
        }

        [TestMethod]
        public void TestConversionFromLong()
        {
            testConversionFromLong(-9223372036854775808);
            testConversionFromLong(-9223372036854775807);
            testConversionFromLong(-9223372036854775761);
            testConversionFromLong(-4294967343);
            testConversionFromLong(-4294967297);
            testConversionFromLong(-4294967296);
            testConversionFromLong(-4294967295);
            testConversionFromLong(-4294967249);
            testConversionFromLong(-2147483695);
            testConversionFromLong(-2147483649);
            testConversionFromLong(-2147483648);
            testConversionFromLong(-2147483647);
            testConversionFromLong(-2147483601);
            testConversionFromLong(-65583);
            testConversionFromLong(-65537);
            testConversionFromLong(-65536);
            testConversionFromLong(-65535);
            testConversionFromLong(-65489);
            testConversionFromLong(-47);
            testConversionFromLong(-1);
            testConversionFromLong(0);
            testConversionFromLong(1);
            testConversionFromLong(47);
            testConversionFromLong(65489);
            testConversionFromLong(65535);
            testConversionFromLong(65536);
            testConversionFromLong(65537);
            testConversionFromLong(65583);
            testConversionFromLong(2147483601);
            testConversionFromLong(2147483647);
            testConversionFromLong(2147483648);
            testConversionFromLong(2147483649);
            testConversionFromLong(2147483695);
            testConversionFromLong(4294967249);
            testConversionFromLong(4294967295);
            testConversionFromLong(4294967296);
            testConversionFromLong(4294967297);
            testConversionFromLong(4294967343);
            testConversionFromLong(9223372036854775761);
            testConversionFromLong(9223372036854775807);
        }

        private void testConversionFromULong(ulong value)
        {
            // Test constructor
            testConversion(new BigInt(value), value.ToString());

            // Test implicit conversion
            testConversion(value, value.ToString());

            // Test explicit conversion
            testConversion((BigInt) value, value.ToString());
        }

        [TestMethod]
        public void TestConversionFromULong()
        {
            testConversionFromULong(0);
            testConversionFromULong(1);
            testConversionFromULong(47);
            testConversionFromULong(65489);
            testConversionFromULong(65535);
            testConversionFromULong(65536);
            testConversionFromULong(65537);
            testConversionFromULong(65583);
            testConversionFromULong(2147483601);
            testConversionFromULong(2147483647);
            testConversionFromULong(2147483648);
            testConversionFromULong(2147483649);
            testConversionFromULong(2147483695);
            testConversionFromULong(4294967249);
            testConversionFromULong(4294967295);
            testConversionFromULong(4294967296);
            testConversionFromULong(4294967297);
            testConversionFromULong(4294967343);
            testConversionFromULong(9223372036854775761);
            testConversionFromULong(9223372036854775807);
            testConversionFromULong(9223372036854775808);
            testConversionFromULong(9223372036854775809);
            testConversionFromULong(9223372036854775855);
            testConversionFromULong(18446744073709551569);
            testConversionFromULong(18446744073709551615);
        }

        private void testConversionFromShort(short value)
        {
            // Test constructor
            testConversion(new BigInt(value), value.ToString());

            // Test implicit conversion
            testConversion(value, value.ToString());

            // Test explicit conversion
            testConversion((BigInt) value, value.ToString());
        }

        [TestMethod]
        public void TestConversionFromShort()
        {
            testConversionFromShort(-32768);
            testConversionFromShort(-47);
            testConversionFromShort(-1);
            testConversionFromShort(0);
            testConversionFromShort(1);
            testConversionFromShort(47);
            testConversionFromShort(32767);
        }

        private void testConversionFromUShort(ushort value)
        {
            // Test constructor
            testConversion(new BigInt(value), value.ToString());

            // Test implicit conversion
            testConversion(value, value.ToString());

            // Test explicit conversion
            testConversion((BigInt) value, value.ToString());
        }

        [TestMethod]
        public void TestConversionFromUShort()
        {
            testConversionFromUShort(0);
            testConversionFromUShort(1);
            testConversionFromUShort(47);
            testConversionFromUShort(65489);
            testConversionFromUShort(65535);
        }

        private void testConversionFromSByte(sbyte value)
        {
            // Test constructor
            testConversion(new BigInt(value), value.ToString());

            // Test implicit conversion
            testConversion(value, value.ToString());

            // Test explicit conversion
            testConversion((BigInt) value, value.ToString());
        }

        [TestMethod]
        public void TestConversionFromSByte()
        {
            testConversionFromSByte(-128);
            testConversionFromSByte(-47);
            testConversionFromSByte(-1);
            testConversionFromSByte(0);
            testConversionFromSByte(1);
            testConversionFromSByte(47);
            testConversionFromSByte(127);
        }

        private void testConversionFromByte(byte value)
        {
            // Test constructor
            testConversion(new BigInt(value), value.ToString());

            // Test implicit conversion
            testConversion(value, value.ToString());

            // Test explicit conversion
            testConversion((BigInt) value, value.ToString());
        }

        [TestMethod]
        public void TestConversionFromByte()
        {
            testConversionFromByte(0);
            testConversionFromByte(1);
            testConversionFromByte(47);
            testConversionFromByte(255);
        }

        private void testExplicitConversions(BigInt value, sbyte sb, byte b, short s, ushort us, int i, uint ui, long l, ulong ul)
        {
            Assert.AreEqual(sb, (sbyte) value);
            Assert.AreEqual(b, (byte) value);
            Assert.AreEqual(s, (short) value);
            Assert.AreEqual(us, (ushort) value);
            Assert.AreEqual(i, (int) value);
            Assert.AreEqual(ui, (uint) value);
            Assert.AreEqual(l, (long) value);
            Assert.AreEqual(ul, (ulong) value);
        }

        [TestMethod]
        public void TestExplicitConversions()
        {
            testExplicitConversions(BigInt.Parse("-340282366920938463463374607431768211503"), -47, 209, -47, 65489, -47, 4294967249, -47, 18446744073709551569);
            testExplicitConversions(BigInt.Parse("-340282366920938463463374607431768211457"), -1, 255, -1, 65535, -1, 4294967295, -1, 18446744073709551615);
            testExplicitConversions(BigInt.Parse("-340282366920938463463374607431768211456"), 0, 0, 0, 0, 0, 0, 0, 0);
            testExplicitConversions(BigInt.Parse("-340282366920938463463374607431768211455"), 1, 1, 1, 1, 1, 1, 1, 1);
            testExplicitConversions(BigInt.Parse("-340282366920938463463374607431768211409"), 47, 47, 47, 47, 47, 47, 47, 47);
            testExplicitConversions(BigInt.Parse("-170141183460469231731687303715884105775"), -47, 209, -47, 65489, -47, 4294967249, -47, 18446744073709551569);
            testExplicitConversions(BigInt.Parse("-170141183460469231731687303715884105729"), -1, 255, -1, 65535, -1, 4294967295, -1, 18446744073709551615);
            testExplicitConversions(BigInt.Parse("-170141183460469231731687303715884105728"), 0, 0, 0, 0, 0, 0, 0, 0);
            testExplicitConversions(BigInt.Parse("-170141183460469231731687303715884105727"), 1, 1, 1, 1, 1, 1, 1, 1);
            testExplicitConversions(BigInt.Parse("-170141183460469231731687303715884105681"), 47, 47, 47, 47, 47, 47, 47, 47);
            testExplicitConversions(BigInt.Parse("-18446744073709551663"), -47, 209, -47, 65489, -47, 4294967249, -47, 18446744073709551569);
            testExplicitConversions(BigInt.Parse("-18446744073709551617"), -1, 255, -1, 65535, -1, 4294967295, -1, 18446744073709551615);
            testExplicitConversions(BigInt.Parse("-18446744073709551616"), 0, 0, 0, 0, 0, 0, 0, 0);
            testExplicitConversions(BigInt.Parse("-18446744073709551615"), 1, 1, 1, 1, 1, 1, 1, 1);
            testExplicitConversions(BigInt.Parse("-18446744073709551569"), 47, 47, 47, 47, 47, 47, 47, 47);
            testExplicitConversions(BigInt.Parse("-9223372036854775855"), -47, 209, -47, 65489, -47, 4294967249, 9223372036854775761, 9223372036854775761);
            testExplicitConversions(BigInt.Parse("-9223372036854775809"), -1, 255, -1, 65535, -1, 4294967295, 9223372036854775807, 9223372036854775807);
            testExplicitConversions(BigInt.Parse("-9223372036854775808"), 0, 0, 0, 0, 0, 0, -9223372036854775808, 9223372036854775808);
            testExplicitConversions(BigInt.Parse("-9223372036854775807"), 1, 1, 1, 1, 1, 1, -9223372036854775807, 9223372036854775809);
            testExplicitConversions(BigInt.Parse("-9223372036854775761"), 47, 47, 47, 47, 47, 47, -9223372036854775761, 9223372036854775855);
            testExplicitConversions(BigInt.Parse("-4294967343"), -47, 209, -47, 65489, -47, 4294967249, -4294967343, 18446744069414584273);
            testExplicitConversions(BigInt.Parse("-4294967297"), -1, 255, -1, 65535, -1, 4294967295, -4294967297, 18446744069414584319);
            testExplicitConversions(BigInt.Parse("-4294967296"), 0, 0, 0, 0, 0, 0, -4294967296, 18446744069414584320);
            testExplicitConversions(BigInt.Parse("-4294967295"), 1, 1, 1, 1, 1, 1, -4294967295, 18446744069414584321);
            testExplicitConversions(BigInt.Parse("-4294967249"), 47, 47, 47, 47, 47, 47, -4294967249, 18446744069414584367);
            testExplicitConversions(BigInt.Parse("-2147483695"), -47, 209, -47, 65489, 2147483601, 2147483601, -2147483695, 18446744071562067921);
            testExplicitConversions(BigInt.Parse("-2147483649"), -1, 255, -1, 65535, 2147483647, 2147483647, -2147483649, 18446744071562067967);
            testExplicitConversions(BigInt.Parse("-2147483648"), 0, 0, 0, 0, -2147483648, 2147483648, -2147483648, 18446744071562067968);
            testExplicitConversions(BigInt.Parse("-2147483647"), 1, 1, 1, 1, -2147483647, 2147483649, -2147483647, 18446744071562067969);
            testExplicitConversions(BigInt.Parse("-2147483601"), 47, 47, 47, 47, -2147483601, 2147483695, -2147483601, 18446744071562068015);
            testExplicitConversions(BigInt.Parse("-65583"), -47, 209, -47, 65489, -65583, 4294901713, -65583, 18446744073709486033);
            testExplicitConversions(BigInt.Parse("-65537"), -1, 255, -1, 65535, -65537, 4294901759, -65537, 18446744073709486079);
            testExplicitConversions(BigInt.Parse("-65536"), 0, 0, 0, 0, -65536, 4294901760, -65536, 18446744073709486080);
            testExplicitConversions(BigInt.Parse("-65535"), 1, 1, 1, 1, -65535, 4294901761, -65535, 18446744073709486081);
            testExplicitConversions(BigInt.Parse("-65489"), 47, 47, 47, 47, -65489, 4294901807, -65489, 18446744073709486127);
            testExplicitConversions(BigInt.Parse("-47"), -47, 209, -47, 65489, -47, 4294967249, -47, 18446744073709551569);
            testExplicitConversions(BigInt.Parse("-1"), -1, 255, -1, 65535, -1, 4294967295, -1, 18446744073709551615);
            testExplicitConversions(BigInt.Parse("0"), 0, 0, 0, 0, 0, 0, 0, 0);
            testExplicitConversions(BigInt.Parse("1"), 1, 1, 1, 1, 1, 1, 1, 1);
            testExplicitConversions(BigInt.Parse("47"), 47, 47, 47, 47, 47, 47, 47, 47);
            testExplicitConversions(BigInt.Parse("65489"), -47, 209, -47, 65489, 65489, 65489, 65489, 65489);
            testExplicitConversions(BigInt.Parse("65535"), -1, 255, -1, 65535, 65535, 65535, 65535, 65535);
            testExplicitConversions(BigInt.Parse("65536"), 0, 0, 0, 0, 65536, 65536, 65536, 65536);
            testExplicitConversions(BigInt.Parse("65537"), 1, 1, 1, 1, 65537, 65537, 65537, 65537);
            testExplicitConversions(BigInt.Parse("65583"), 47, 47, 47, 47, 65583, 65583, 65583, 65583);
            testExplicitConversions(BigInt.Parse("2147483601"), -47, 209, -47, 65489, 2147483601, 2147483601, 2147483601, 2147483601);
            testExplicitConversions(BigInt.Parse("2147483647"), -1, 255, -1, 65535, 2147483647, 2147483647, 2147483647, 2147483647);
            testExplicitConversions(BigInt.Parse("2147483648"), 0, 0, 0, 0, -2147483648, 2147483648, 2147483648, 2147483648);
            testExplicitConversions(BigInt.Parse("2147483649"), 1, 1, 1, 1, -2147483647, 2147483649, 2147483649, 2147483649);
            testExplicitConversions(BigInt.Parse("2147483695"), 47, 47, 47, 47, -2147483601, 2147483695, 2147483695, 2147483695);
            testExplicitConversions(BigInt.Parse("4294967249"), -47, 209, -47, 65489, -47, 4294967249, 4294967249, 4294967249);
            testExplicitConversions(BigInt.Parse("4294967295"), -1, 255, -1, 65535, -1, 4294967295, 4294967295, 4294967295);
            testExplicitConversions(BigInt.Parse("4294967296"), 0, 0, 0, 0, 0, 0, 4294967296, 4294967296);
            testExplicitConversions(BigInt.Parse("4294967297"), 1, 1, 1, 1, 1, 1, 4294967297, 4294967297);
            testExplicitConversions(BigInt.Parse("4294967343"), 47, 47, 47, 47, 47, 47, 4294967343, 4294967343);
            testExplicitConversions(BigInt.Parse("9223372036854775761"), -47, 209, -47, 65489, -47, 4294967249, 9223372036854775761, 9223372036854775761);
            testExplicitConversions(BigInt.Parse("9223372036854775807"), -1, 255, -1, 65535, -1, 4294967295, 9223372036854775807, 9223372036854775807);
            testExplicitConversions(BigInt.Parse("9223372036854775808"), 0, 0, 0, 0, 0, 0, -9223372036854775808, 9223372036854775808);
            testExplicitConversions(BigInt.Parse("9223372036854775809"), 1, 1, 1, 1, 1, 1, -9223372036854775807, 9223372036854775809);
            testExplicitConversions(BigInt.Parse("9223372036854775855"), 47, 47, 47, 47, 47, 47, -9223372036854775761, 9223372036854775855);
            testExplicitConversions(BigInt.Parse("18446744073709551569"), -47, 209, -47, 65489, -47, 4294967249, -47, 18446744073709551569);
            testExplicitConversions(BigInt.Parse("18446744073709551615"), -1, 255, -1, 65535, -1, 4294967295, -1, 18446744073709551615);
            testExplicitConversions(BigInt.Parse("18446744073709551616"), 0, 0, 0, 0, 0, 0, 0, 0);
            testExplicitConversions(BigInt.Parse("18446744073709551617"), 1, 1, 1, 1, 1, 1, 1, 1);
            testExplicitConversions(BigInt.Parse("18446744073709551663"), 47, 47, 47, 47, 47, 47, 47, 47);
            testExplicitConversions(BigInt.Parse("170141183460469231731687303715884105681"), -47, 209, -47, 65489, -47, 4294967249, -47, 18446744073709551569);
            testExplicitConversions(BigInt.Parse("170141183460469231731687303715884105727"), -1, 255, -1, 65535, -1, 4294967295, -1, 18446744073709551615);
            testExplicitConversions(BigInt.Parse("170141183460469231731687303715884105728"), 0, 0, 0, 0, 0, 0, 0, 0);
            testExplicitConversions(BigInt.Parse("170141183460469231731687303715884105729"), 1, 1, 1, 1, 1, 1, 1, 1);
            testExplicitConversions(BigInt.Parse("170141183460469231731687303715884105775"), 47, 47, 47, 47, 47, 47, 47, 47);
            testExplicitConversions(BigInt.Parse("340282366920938463463374607431768211409"), -47, 209, -47, 65489, -47, 4294967249, -47, 18446744073709551569);
            testExplicitConversions(BigInt.Parse("340282366920938463463374607431768211455"), -1, 255, -1, 65535, -1, 4294967295, -1, 18446744073709551615);
            testExplicitConversions(BigInt.Parse("340282366920938463463374607431768211456"), 0, 0, 0, 0, 0, 0, 0, 0);
            testExplicitConversions(BigInt.Parse("340282366920938463463374607431768211457"), 1, 1, 1, 1, 1, 1, 1, 1);
        }
    }
}