using System.Collections.Generic;
using System.Linq;
using MesPremiersUnitTestProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace CSharp6Test
{
    [TestClass]
    public class DictionaryTest
    {
        [TestMethod]
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