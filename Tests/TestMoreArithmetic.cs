namespace RT.BigInteger.Tests
{
    [TestClass]
    public sealed class TestMoreArithmetic
    {
        private void testSignEtc(BigInt value, int expectedSign, bool expectedIsZero, bool expectedIsEven, bool expectedIsOdd, bool expectedIsPowerOfTwo, int expectedMsb)
        {
            Assert.AreEqual(expectedSign, value.Sign);
            Assert.AreEqual(expectedIsZero, value.IsZero);
            Assert.AreEqual(expectedIsEven, value.IsEven);
            Assert.AreEqual(expectedIsOdd, value.IsOdd);
            Assert.AreEqual(expectedIsPowerOfTwo, value.IsPowerOfTwo);
            Assert.AreEqual(expectedMsb, value.MostSignificantBit);
        }

        [TestMethod]
        public void TestSignEtc()
        {
            testSignEtc(BigInt.Parse("-340282366920938463463374607431768211503"), -1, false, false, true, false, 128);
            testSignEtc(BigInt.Parse("-340282366920938463463374607431768211457"), -1, false, false, true, false, 128);
            testSignEtc(BigInt.Parse("-340282366920938463463374607431768211456"), -1, false, true, false, false, 127);
            testSignEtc(BigInt.Parse("-340282366920938463463374607431768211455"), -1, false, false, true, false, 127);
            testSignEtc(BigInt.Parse("-340282366920938463463374607431768211409"), -1, false, false, true, false, 127);
            testSignEtc(BigInt.Parse("-170141183460469231731687303715884105775"), -1, false, false, true, false, 127);
            testSignEtc(BigInt.Parse("-170141183460469231731687303715884105729"), -1, false, false, true, false, 127);
            testSignEtc(BigInt.Parse("-170141183460469231731687303715884105728"), -1, false, true, false, false, 126);
            testSignEtc(BigInt.Parse("-170141183460469231731687303715884105727"), -1, false, false, true, false, 126);
            testSignEtc(BigInt.Parse("-170141183460469231731687303715884105681"), -1, false, false, true, false, 126);
            testSignEtc(BigInt.Parse("-18446744073709551663"), -1, false, false, true, false, 64);
            testSignEtc(BigInt.Parse("-18446744073709551617"), -1, false, false, true, false, 64);
            testSignEtc(BigInt.Parse("-18446744073709551616"), -1, false, true, false, false, 63);
            testSignEtc(BigInt.Parse("-18446744073709551615"), -1, false, false, true, false, 63);
            testSignEtc(BigInt.Parse("-18446744073709551569"), -1, false, false, true, false, 63);
            testSignEtc(BigInt.Parse("-9223372036854775855"), -1, false, false, true, false, 63);
            testSignEtc(BigInt.Parse("-9223372036854775809"), -1, false, false, true, false, 63);
            testSignEtc(BigInt.Parse("-9223372036854775808"), -1, false, true, false, false, 62);
            testSignEtc(BigInt.Parse("-9223372036854775807"), -1, false, false, true, false, 62);
            testSignEtc(BigInt.Parse("-9223372036854775761"), -1, false, false, true, false, 62);
            testSignEtc(BigInt.Parse("-4294967343"), -1, false, false, true, false, 32);
            testSignEtc(BigInt.Parse("-4294967297"), -1, false, false, true, false, 32);
            testSignEtc(BigInt.Parse("-4294967296"), -1, false, true, false, false, 31);
            testSignEtc(BigInt.Parse("-4294967295"), -1, false, false, true, false, 31);
            testSignEtc(BigInt.Parse("-4294967249"), -1, false, false, true, false, 31);
            testSignEtc(BigInt.Parse("-2147483695"), -1, false, false, true, false, 31);
            testSignEtc(BigInt.Parse("-2147483649"), -1, false, false, true, false, 31);
            testSignEtc(BigInt.Parse("-2147483648"), -1, false, true, false, false, 30);
            testSignEtc(BigInt.Parse("-2147483647"), -1, false, false, true, false, 30);
            testSignEtc(BigInt.Parse("-2147483601"), -1, false, false, true, false, 30);
            testSignEtc(BigInt.Parse("-65583"), -1, false, false, true, false, 16);
            testSignEtc(BigInt.Parse("-65537"), -1, false, false, true, false, 16);
            testSignEtc(BigInt.Parse("-65536"), -1, false, true, false, false, 15);
            testSignEtc(BigInt.Parse("-65535"), -1, false, false, true, false, 15);
            testSignEtc(BigInt.Parse("-65489"), -1, false, false, true, false, 15);
            testSignEtc(BigInt.Parse("-47"), -1, false, false, true, false, 5);
            testSignEtc(BigInt.Parse("-1"), -1, false, false, true, false, -1);
            testSignEtc(BigInt.Parse("0"), 0, true, true, false, false, -1);
            testSignEtc(BigInt.Parse("1"), 1, false, false, true, true, 0);
            testSignEtc(BigInt.Parse("47"), 1, false, false, true, false, 5);
            testSignEtc(BigInt.Parse("65489"), 1, false, false, true, false, 15);
            testSignEtc(BigInt.Parse("65535"), 1, false, false, true, false, 15);
            testSignEtc(BigInt.Parse("65536"), 1, false, true, false, true, 16);
            testSignEtc(BigInt.Parse("65537"), 1, false, false, true, false, 16);
            testSignEtc(BigInt.Parse("65583"), 1, false, false, true, false, 16);
            testSignEtc(BigInt.Parse("2147483601"), 1, false, false, true, false, 30);
            testSignEtc(BigInt.Parse("2147483647"), 1, false, false, true, false, 30);
            testSignEtc(BigInt.Parse("2147483648"), 1, false, true, false, true, 31);
            testSignEtc(BigInt.Parse("2147483649"), 1, false, false, true, false, 31);
            testSignEtc(BigInt.Parse("2147483695"), 1, false, false, true, false, 31);
            testSignEtc(BigInt.Parse("4294967249"), 1, false, false, true, false, 31);
            testSignEtc(BigInt.Parse("4294967295"), 1, false, false, true, false, 31);
            testSignEtc(BigInt.Parse("4294967296"), 1, false, true, false, true, 32);
            testSignEtc(BigInt.Parse("4294967297"), 1, false, false, true, false, 32);
            testSignEtc(BigInt.Parse("4294967343"), 1, false, false, true, false, 32);
            testSignEtc(BigInt.Parse("9223372036854775761"), 1, false, false, true, false, 62);
            testSignEtc(BigInt.Parse("9223372036854775807"), 1, false, false, true, false, 62);
            testSignEtc(BigInt.Parse("9223372036854775808"), 1, false, true, false, true, 63);
            testSignEtc(BigInt.Parse("9223372036854775809"), 1, false, false, true, false, 63);
            testSignEtc(BigInt.Parse("9223372036854775855"), 1, false, false, true, false, 63);
            testSignEtc(BigInt.Parse("18446744073709551569"), 1, false, false, true, false, 63);
            testSignEtc(BigInt.Parse("18446744073709551615"), 1, false, false, true, false, 63);
            testSignEtc(BigInt.Parse("18446744073709551616"), 1, false, true, false, true, 64);
            testSignEtc(BigInt.Parse("18446744073709551617"), 1, false, false, true, false, 64);
            testSignEtc(BigInt.Parse("18446744073709551663"), 1, false, false, true, false, 64);
            testSignEtc(BigInt.Parse("170141183460469231731687303715884105681"), 1, false, false, true, false, 126);
            testSignEtc(BigInt.Parse("170141183460469231731687303715884105727"), 1, false, false, true, false, 126);
            testSignEtc(BigInt.Parse("170141183460469231731687303715884105728"), 1, false, true, false, true, 127);
            testSignEtc(BigInt.Parse("170141183460469231731687303715884105729"), 1, false, false, true, false, 127);
            testSignEtc(BigInt.Parse("170141183460469231731687303715884105775"), 1, false, false, true, false, 127);
            testSignEtc(BigInt.Parse("340282366920938463463374607431768211409"), 1, false, false, true, false, 127);
            testSignEtc(BigInt.Parse("340282366920938463463374607431768211455"), 1, false, false, true, false, 127);
            testSignEtc(BigInt.Parse("340282366920938463463374607431768211456"), 1, false, true, false, true, 128);
            testSignEtc(BigInt.Parse("340282366920938463463374607431768211457"), 1, false, false, true, false, 128);
        }
    }
}