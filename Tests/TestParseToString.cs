namespace RT.BigInteger.Tests
{
    [TestClass]
    public sealed class TestString
    {
        private void testParseToString(string str)
        {
            var result = BigInt.Parse(str);
            Assert.AreEqual(str, result.ToString());

            // Test leading zero as well
            result = BigInt.Parse(str.StartsWith("-") ? $"-0{str.Substring(1)}" : $"0{str}");
            Assert.AreEqual(str, result.ToString());
        }

        [TestMethod]
        public void TestParseToString()
        {
            testParseToString("-340282366920938463463374607431768211503");
            testParseToString("-340282366920938463463374607431768211457");
            testParseToString("-340282366920938463463374607431768211456");
            testParseToString("-340282366920938463463374607431768211455");
            testParseToString("-340282366920938463463374607431768211409");
            testParseToString("-170141183460469231731687303715884105775");
            testParseToString("-170141183460469231731687303715884105729");
            testParseToString("-170141183460469231731687303715884105728");
            testParseToString("-170141183460469231731687303715884105727");
            testParseToString("-170141183460469231731687303715884105681");
            testParseToString("-18446744073709551663");
            testParseToString("-18446744073709551617");
            testParseToString("-18446744073709551616");
            testParseToString("-18446744073709551615");
            testParseToString("-18446744073709551569");
            testParseToString("-9223372036854775855");
            testParseToString("-9223372036854775809");
            testParseToString("-9223372036854775808");
            testParseToString("-9223372036854775807");
            testParseToString("-9223372036854775761");
            testParseToString("-4294967343");
            testParseToString("-4294967297");
            testParseToString("-4294967296");
            testParseToString("-4294967295");
            testParseToString("-4294967249");
            testParseToString("-2147483695");
            testParseToString("-2147483649");
            testParseToString("-2147483648");
            testParseToString("-2147483647");
            testParseToString("-2147483601");
            testParseToString("-65583");
            testParseToString("-65537");
            testParseToString("-65536");
            testParseToString("-65535");
            testParseToString("-65489");
            testParseToString("-47");
            testParseToString("-1");
            testParseToString("0");
            testParseToString("1");
            testParseToString("47");
            testParseToString("340282366920938463463374607431768211409");
            testParseToString("340282366920938463463374607431768211455");
            testParseToString("340282366920938463463374607431768211456");
            testParseToString("340282366920938463463374607431768211457");
            testParseToString("340282366920938463463374607431768211503");
            testParseToString("170141183460469231731687303715884105681");
            testParseToString("170141183460469231731687303715884105727");
            testParseToString("170141183460469231731687303715884105728");
            testParseToString("170141183460469231731687303715884105729");
            testParseToString("170141183460469231731687303715884105775");
            testParseToString("18446744073709551569");
            testParseToString("18446744073709551615");
            testParseToString("18446744073709551616");
            testParseToString("18446744073709551617");
            testParseToString("18446744073709551663");
            testParseToString("9223372036854775761");
            testParseToString("9223372036854775807");
            testParseToString("9223372036854775808");
            testParseToString("9223372036854775809");
            testParseToString("9223372036854775855");
            testParseToString("4294967249");
            testParseToString("4294967295");
            testParseToString("4294967296");
            testParseToString("4294967297");
            testParseToString("4294967343");
            testParseToString("2147483601");
            testParseToString("2147483647");
            testParseToString("2147483648");
            testParseToString("2147483649");
            testParseToString("2147483695");
            testParseToString("65489");
            testParseToString("65535");
            testParseToString("65536");
            testParseToString("65537");
            testParseToString("65583");
            testParseToString("-47");
            testParseToString("-1");
            testParseToString("0");
            testParseToString("1");
            testParseToString("47");
            testParseToString("340282366920938463463374607431768211409340282366920938463463374607431768211455340282366920938463463374607431768211456340282366920938463463374607431768211457340282366920938463463374607431768211503");
            testParseToString("300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003");
        }
    }
}