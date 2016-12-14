using NUnit.Framework;

namespace XPPractices
{
    [TestFixture]
    public class CaesarCypherTests
    {
        [Test]
        public void EncryptA()
        {
            var cypher = new CaesarCypher();
            Assert.AreEqual("N", cypher.Encrypt("A"));
        }
    }

    public class CaesarCypher
    {
        public string Encrypt(string sentence)
        {
            return "N";
        }
    }
}