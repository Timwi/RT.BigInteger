namespace RT.BigInteger.Tests
{
    [TestClass]
    public sealed class TestMiscellaneous
    {
        private void testEqualsGetHashCode(object bigInt1, object bigInt2)
        {
            Assert.IsTrue(bigInt1.Equals(bigInt1));
            Assert.IsTrue(bigInt2.Equals(bigInt2));
            Assert.IsTrue(bigInt1.Equals(bigInt2));
            Assert.IsTrue(bigInt2.Equals(bigInt1));
            Assert.AreEqual(bigInt1.GetHashCode(), bigInt2.GetHashCode());
        }

        [TestMethod]
        public void TestNotEqualsOtherObjects()
        {
            object obj = new BigInt(1);
            Assert.IsFalse(obj.Equals(new object()));
            Assert.IsFalse(obj.Equals(null));
        }

        [TestMethod]
        public void TestEqualsGetHashCode()
        {
            testEqualsGetHashCode(BigInt.Parse("-340282366920938463463374607431768211503"), BigInt.Parse("-340282366920938463463374607431768211503"));
            testEqualsGetHashCode(BigInt.Parse("-340282366920938463463374607431768211457"), BigInt.Parse("-340282366920938463463374607431768211457"));
            testEqualsGetHashCode(BigInt.Parse("-340282366920938463463374607431768211456"), BigInt.Parse("-340282366920938463463374607431768211456"));
            testEqualsGetHashCode(BigInt.Parse("-340282366920938463463374607431768211455"), BigInt.Parse("-340282366920938463463374607431768211455"));
            testEqualsGetHashCode(BigInt.Parse("-340282366920938463463374607431768211409"), BigInt.Parse("-340282366920938463463374607431768211409"));
            testEqualsGetHashCode(BigInt.Parse("-170141183460469231731687303715884105775"), BigInt.Parse("-170141183460469231731687303715884105775"));
            testEqualsGetHashCode(BigInt.Parse("-170141183460469231731687303715884105729"), BigInt.Parse("-170141183460469231731687303715884105729"));
            testEqualsGetHashCode(BigInt.Parse("-170141183460469231731687303715884105728"), BigInt.Parse("-170141183460469231731687303715884105728"));
            testEqualsGetHashCode(BigInt.Parse("-170141183460469231731687303715884105727"), BigInt.Parse("-170141183460469231731687303715884105727"));
            testEqualsGetHashCode(BigInt.Parse("-170141183460469231731687303715884105681"), BigInt.Parse("-170141183460469231731687303715884105681"));
            testEqualsGetHashCode(BigInt.Parse("-18446744073709551663"), BigInt.Parse("-18446744073709551663"));
            testEqualsGetHashCode(BigInt.Parse("-18446744073709551617"), BigInt.Parse("-18446744073709551617"));
            testEqualsGetHashCode(BigInt.Parse("-18446744073709551616"), BigInt.Parse("-18446744073709551616"));
            testEqualsGetHashCode(BigInt.Parse("-18446744073709551615"), BigInt.Parse("-18446744073709551615"));
            testEqualsGetHashCode(BigInt.Parse("-18446744073709551569"), BigInt.Parse("-18446744073709551569"));
            testEqualsGetHashCode(BigInt.Parse("-9223372036854775855"), BigInt.Parse("-9223372036854775855"));
            testEqualsGetHashCode(BigInt.Parse("-9223372036854775809"), BigInt.Parse("-9223372036854775809"));
            testEqualsGetHashCode(BigInt.Parse("-9223372036854775808"), BigInt.Parse("-9223372036854775808"));
            testEqualsGetHashCode(BigInt.Parse("-9223372036854775807"), BigInt.Parse("-9223372036854775807"));
            testEqualsGetHashCode(BigInt.Parse("-9223372036854775761"), BigInt.Parse("-9223372036854775761"));
            testEqualsGetHashCode(BigInt.Parse("-4294967343"), BigInt.Parse("-4294967343"));
            testEqualsGetHashCode(BigInt.Parse("-4294967297"), BigInt.Parse("-4294967297"));
            testEqualsGetHashCode(BigInt.Parse("-4294967296"), BigInt.Parse("-4294967296"));
            testEqualsGetHashCode(BigInt.Parse("-4294967295"), BigInt.Parse("-4294967295"));
            testEqualsGetHashCode(BigInt.Parse("-4294967249"), BigInt.Parse("-4294967249"));
            testEqualsGetHashCode(BigInt.Parse("-2147483695"), BigInt.Parse("-2147483695"));
            testEqualsGetHashCode(BigInt.Parse("-2147483649"), BigInt.Parse("-2147483649"));
            testEqualsGetHashCode(BigInt.Parse("-2147483648"), BigInt.Parse("-2147483648"));
            testEqualsGetHashCode(BigInt.Parse("-2147483647"), BigInt.Parse("-2147483647"));
            testEqualsGetHashCode(BigInt.Parse("-2147483601"), BigInt.Parse("-2147483601"));
            testEqualsGetHashCode(BigInt.Parse("-65583"), BigInt.Parse("-65583"));
            testEqualsGetHashCode(BigInt.Parse("-65537"), BigInt.Parse("-65537"));
            testEqualsGetHashCode(BigInt.Parse("-65536"), BigInt.Parse("-65536"));
            testEqualsGetHashCode(BigInt.Parse("-65535"), BigInt.Parse("-65535"));
            testEqualsGetHashCode(BigInt.Parse("-65489"), BigInt.Parse("-65489"));
            testEqualsGetHashCode(BigInt.Parse("-47"), BigInt.Parse("-47"));
            testEqualsGetHashCode(BigInt.Parse("-1"), BigInt.Parse("-1"));
            testEqualsGetHashCode(BigInt.Parse("0"), BigInt.Parse("0"));
            testEqualsGetHashCode(BigInt.Parse("1"), BigInt.Parse("1"));
            testEqualsGetHashCode(BigInt.Parse("47"), BigInt.Parse("47"));
            testEqualsGetHashCode(BigInt.Parse("65489"), BigInt.Parse("65489"));
            testEqualsGetHashCode(BigInt.Parse("65535"), BigInt.Parse("65535"));
            testEqualsGetHashCode(BigInt.Parse("65536"), BigInt.Parse("65536"));
            testEqualsGetHashCode(BigInt.Parse("65537"), BigInt.Parse("65537"));
            testEqualsGetHashCode(BigInt.Parse("65583"), BigInt.Parse("65583"));
            testEqualsGetHashCode(BigInt.Parse("2147483601"), BigInt.Parse("2147483601"));
            testEqualsGetHashCode(BigInt.Parse("2147483647"), BigInt.Parse("2147483647"));
            testEqualsGetHashCode(BigInt.Parse("2147483648"), BigInt.Parse("2147483648"));
            testEqualsGetHashCode(BigInt.Parse("2147483649"), BigInt.Parse("2147483649"));
            testEqualsGetHashCode(BigInt.Parse("2147483695"), BigInt.Parse("2147483695"));
            testEqualsGetHashCode(BigInt.Parse("4294967249"), BigInt.Parse("4294967249"));
            testEqualsGetHashCode(BigInt.Parse("4294967295"), BigInt.Parse("4294967295"));
            testEqualsGetHashCode(BigInt.Parse("4294967296"), BigInt.Parse("4294967296"));
            testEqualsGetHashCode(BigInt.Parse("4294967297"), BigInt.Parse("4294967297"));
            testEqualsGetHashCode(BigInt.Parse("4294967343"), BigInt.Parse("4294967343"));
            testEqualsGetHashCode(BigInt.Parse("9223372036854775761"), BigInt.Parse("9223372036854775761"));
            testEqualsGetHashCode(BigInt.Parse("9223372036854775807"), BigInt.Parse("9223372036854775807"));
            testEqualsGetHashCode(BigInt.Parse("9223372036854775808"), BigInt.Parse("9223372036854775808"));
            testEqualsGetHashCode(BigInt.Parse("9223372036854775809"), BigInt.Parse("9223372036854775809"));
            testEqualsGetHashCode(BigInt.Parse("9223372036854775855"), BigInt.Parse("9223372036854775855"));
            testEqualsGetHashCode(BigInt.Parse("18446744073709551569"), BigInt.Parse("18446744073709551569"));
            testEqualsGetHashCode(BigInt.Parse("18446744073709551615"), BigInt.Parse("18446744073709551615"));
            testEqualsGetHashCode(BigInt.Parse("18446744073709551616"), BigInt.Parse("18446744073709551616"));
            testEqualsGetHashCode(BigInt.Parse("18446744073709551617"), BigInt.Parse("18446744073709551617"));
            testEqualsGetHashCode(BigInt.Parse("18446744073709551663"), BigInt.Parse("18446744073709551663"));
            testEqualsGetHashCode(BigInt.Parse("170141183460469231731687303715884105681"), BigInt.Parse("170141183460469231731687303715884105681"));
            testEqualsGetHashCode(BigInt.Parse("170141183460469231731687303715884105727"), BigInt.Parse("170141183460469231731687303715884105727"));
            testEqualsGetHashCode(BigInt.Parse("170141183460469231731687303715884105728"), BigInt.Parse("170141183460469231731687303715884105728"));
            testEqualsGetHashCode(BigInt.Parse("170141183460469231731687303715884105729"), BigInt.Parse("170141183460469231731687303715884105729"));
            testEqualsGetHashCode(BigInt.Parse("170141183460469231731687303715884105775"), BigInt.Parse("170141183460469231731687303715884105775"));
            testEqualsGetHashCode(BigInt.Parse("340282366920938463463374607431768211409"), BigInt.Parse("340282366920938463463374607431768211409"));
            testEqualsGetHashCode(BigInt.Parse("340282366920938463463374607431768211455"), BigInt.Parse("340282366920938463463374607431768211455"));
            testEqualsGetHashCode(BigInt.Parse("340282366920938463463374607431768211456"), BigInt.Parse("340282366920938463463374607431768211456"));
            testEqualsGetHashCode(BigInt.Parse("340282366920938463463374607431768211457"), BigInt.Parse("340282366920938463463374607431768211457"));
        }
    }
}
