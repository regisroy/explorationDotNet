using System.Collections.Generic;
using NFluent;
using NUnit.Framework;

namespace CSharp6Test
{
    [TestFixture]
    public class DictionaryTest
    {
        [Test]
        public void Dictionary_add()
        {
            var nbPhotosByVille = new Dictionary<string, int>();
            nbPhotosByVille["Paris"] = 10000;
            nbPhotosByVille["Marseille"] = 639;
            Check.That(nbPhotosByVille.Count).IsEqualTo(2);

            nbPhotosByVille["Paris"] = 12365;
            Check.That(nbPhotosByVille.Count).IsEqualTo(2);

            nbPhotosByVille["Vauréal"] = 132;
            Check.That(nbPhotosByVille.Count).IsEqualTo(3);
        }
    }
}