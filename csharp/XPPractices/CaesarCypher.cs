using System.Collections.Generic;
using System.Linq;

namespace XPPractices
{
    public class CaesarCypher
    {
        private readonly int offset;
        private readonly IList<string> alphabet;

        public CaesarCypher(string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ", int offset = 13)
        {
            this.offset = offset;
            this.alphabet = alphabet.ToList();
        }

        public string Encrypt(string sentence)
        {
            return DoEncryption(sentence, offset);
        }

        public string Decrypt(string sentence)
        {
            return DoEncryption(sentence, -offset);
        }

        private string DoEncryption(string sentence, int offset)
        {
            return sentence.ToList()
                .Select(letter => EncryptLetter(letter, offset))
                .Aggregate("", (newSentence, letter) => newSentence + letter);
        }

        private string EncryptLetter(string letter, int offset)
        {
            var uppercase = letter.ToUpper();
            if (!alphabet.Contains(uppercase)) return letter;

            var letterPosition = alphabet.IndexOf(uppercase);
            var newPosition = (letterPosition + alphabet.Count + offset) % alphabet.Count;
            return alphabet[newPosition];
        }
    }

    public static class StringExtensions
    {
        public static IList<string> ToList(this string letters)
        {
            return letters.Select(c => c.ToString()).ToList();
        }
    }
}