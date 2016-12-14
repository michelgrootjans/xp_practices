using NUnit.Framework;

namespace XPPractices
{
    [TestFixture]
    public class CaesarCypherTests
    {
        [TestCase("A", "N")]
        [TestCase("AA", "NN")]
        [TestCase("B", "O")]
        [TestCase("N", "A")]
        [TestCase(";", ";")]
        public void Encrypt(string original, string encrypted)
        {
            var cypher = new CaesarCypher();
            Assert.AreEqual(encrypted, cypher.Encrypt(original));
            Assert.AreEqual(original, cypher.Decrypt(cypher.Encrypt(original)));
        }

        [TestCase("a", "N")]
        public void AssymetricalEncrypt(string original, string encrypted)
        {
            var cypher = new CaesarCypher();
            Assert.AreEqual(encrypted, cypher.Encrypt(original));
            Assert.AreEqual(original.ToUpper(), cypher.Decrypt(cypher.Encrypt(original)));
        }

        [TestCase("C", "N")]
        [TestCase("B", "O")]
        [TestCase("A", "P")]
        [TestCase("D", "Q")]
        public void CustomAlphapbet(string original, string encrypted)
        {
            var cypher = new CaesarCypher(alphabet: "CBA" + "DEFGHIJKLMNOPQRSTUVWXYZ");
            Assert.AreEqual(encrypted, cypher.Encrypt(original));
            Assert.AreEqual(original, cypher.Decrypt(cypher.Encrypt(original)));
        }

        [TestCase("A", 1,  "B")]
        [TestCase("A", 2,  "C")]
        [TestCase("A", 25, "Z")]
        [TestCase("A", 26, "A")]
        public void CustomOffset(string original, int offset, string encrypted)
        {
            var cypher = new CaesarCypher(offset: offset);
            Assert.AreEqual(encrypted, cypher.Encrypt(original));
            Assert.AreEqual(original, cypher.Decrypt(cypher.Encrypt(original)));
        }

        [TestCase("A", "ABC", 1, "B")]
        [TestCase("A", "ABC", 2, "C")]
        [TestCase("A", "ABC", 3, "A")]
        [TestCase("A", "CBA", 1, "C")]
        public void CustomAlphabetAndOffset(string original, string alphabet, int offset, string encrypted)
        {
            var cypher = new CaesarCypher(alphabet: alphabet, offset: offset);
            Assert.AreEqual(encrypted, cypher.Encrypt(original));
            Assert.AreEqual(original, cypher.Decrypt(cypher.Encrypt(original)));
        }
    }
}