using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AzureFunctionsChallenge.DecipherText
{
    public class Decipherer
    {
        private readonly Dictionary<string, string> _cipher;

        public Decipherer(Dictionary<string, string> cipher)
        {
            _cipher = cipher.ToDictionary(kp => kp.Value, kp => kp.Key);
        }

        public string Decipher(string message)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < message.Length; i = i + 2)
            {
                sb.Append(
                    _cipher[string.Concat(message[i], message[i + 1])]);
            }


            return sb.ToString();
        }
    }
}