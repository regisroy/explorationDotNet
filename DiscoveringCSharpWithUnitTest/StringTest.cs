using System;
using NFluent;
using NUnit.Framework;

namespace CSharp6Test
{
    [TestFixture]
    public class StringTest
    {
        [Test]
        public void Comparaisons()
        {
            Check.That(string.Compare("aix En Provence", "AIX EN PROVENCE")).IsEqualTo(-1);
            Check.That(string.Compare("aix En Provence", "AIX EN PROVENCE", StringComparison.Ordinal)).IsEqualTo(32);
            Check.That(string.Compare("aix En Provence", "AIX EN PROVENCE", StringComparison.OrdinalIgnoreCase)).IsEqualTo(0);
        }

        [Test]
        public void TrimEnd()
        {
            const string MY_STRING = "Hello World, Hello World!";
            char[] myChar = {'r', 'o', 'W', 'l', 'd', '!', ' '};
            Check.That(MY_STRING.TrimEnd(myChar)).IsEqualTo("Hello World, He");
        }

        [Test]
        public void TrimStart()
        {
            //attention les majuscules sont importantes
            const string MY_STRING = "Hello World, hello World!";
            char[] myChar = {'H', 'e', 'o', 'W', 'L', 'd', ' '};
            Check.That(MY_STRING.TrimStart(myChar)).IsEqualTo("llo World, hello World!");
        }
    }
}