namespace RT.BigInteger.Tests
{
    [TestClass]
    public sealed class TestConversions
    {
        private void testConversion(BigInt i, string reference)
        {
            Assert.AreEqual(reference, i.ToString());
        }

        private void testConversionFromInt(int i)
        {
            // Test constructor
            testConversion(new BigInt(i), i.ToString());

            // Test implicit conversion
            testConversion(i, i.ToString());

            // Test explicit conversion
            testConversion((BigInt) i, i.ToString());
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

        private void testConversionFromUInt(uint i)
        {
            // Test constructor
            testConversion(new BigInt(i), i.ToString());

            // Test implicit conversion
            testConversion(i, i.ToString());

            // Test explicit conversion
            testConversion((BigInt) i, i.ToString());
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

        private void testConversionFromLong(long i)
        {
            // Test constructor
            testConversion(new BigInt(i), i.ToString());

            // Test implicit conversion
            testConversion(i, i.ToString());

            // Test explicit conversion
            testConversion((BigInt) i, i.ToString());
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

        private void testConversionFromULong(ulong i)
        {
            // Test constructor
            testConversion(new BigInt(i), i.ToString());

            // Test implicit conversion
            testConversion(i, i.ToString());

            // Test explicit conversion
            testConversion((BigInt) i, i.ToString());
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

        private void testConversionFromShort(short i)
        {
            // Test constructor
            testConversion(new BigInt(i), i.ToString());

            // Test implicit conversion
            testConversion(i, i.ToString());

            // Test explicit conversion
            testConversion((BigInt) i, i.ToString());
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

        private void testConversionFromUShort(ushort i)
        {
            // Test constructor
            testConversion(new BigInt(i), i.ToString());

            // Test implicit conversion
            testConversion(i, i.ToString());

            // Test explicit conversion
            testConversion((BigInt) i, i.ToString());
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

        private void testConversionFromSByte(sbyte i)
        {
            // Test constructor
            testConversion(new BigInt(i), i.ToString());

            // Test implicit conversion
            testConversion(i, i.ToString());

            // Test explicit conversion
            testConversion((BigInt) i, i.ToString());
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

        private void testConversionFromByte(byte i)
        {
            // Test constructor
            testConversion(new BigInt(i), i.ToString());

            // Test implicit conversion
            testConversion(i, i.ToString());

            // Test explicit conversion
            testConversion((BigInt) i, i.ToString());
        }

        [TestMethod]
        public void TestConversionFromByte()
        {
            testConversionFromByte(0);
            testConversionFromByte(1);
            testConversionFromByte(47);
            testConversionFromByte(255);
        }
    }
}