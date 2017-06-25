using AzureFunctionsChallenge.DecipherText;
using NUnit.Framework;
using System.Collections.Generic;

namespace AzureFunctionsChallenge.Tests
{
    [TestFixture]
    public class DecipherTextTests
    {
        [Test]
        public void Decipher_WhenSimpleMessageIsInput_ShouldDecipherCorrectly()
        {
            var decipherer = new Decipherer(
                new Dictionary<string, string>
                {
                    { "A", "76" },
                    { "B", "12" }
                });

            var result = decipherer.Decipher("76121276");

            Assert.That(result, Is.EqualTo("ABBA"));
        }

        [Test]
        public void Decipher_WhenComplexMessageIsInput_ShouldDecipherCorrectly()
        {
            var decipherer = new Decipherer(
                new Dictionary<string, string>
                {
                    { "a", "56"  },
                    { "b", "20"  },
                    { "c", "24"  },
                    { "d", "85"  },
                    { "e", "15"  },
                    { "f", "92"  },
                    { "g", "25"  },
                    { "h", "19"  },
                    { "i", "10"  },
                    { "j", "66"  },
                    { "k", "83"  },
                    { "l", "75"  },
                    { "m", "73"  },
                    { "n", "27"  },
                    { "o", "82"  },
                    { "p", "18"  },
                    { "q", "71"  },
                    { "r", "32"  },
                    { "s", "62"  },
                    { "t", "39"  },
                    { "u", "33"  },
                    { "v", "64"  },
                    { "w", "88"  },
                    { "x", "54"  },
                    { "y", "95"  },
                    { "z", "53"  },
                    { " ", "86"  }
                });

            var result = decipherer.Decipher("3919158618333218751586927582881532861062862782398627102415");

            Assert.That(result, Is.EqualTo("the purple flower is not nice"));
        }
    }
}