using NFluent;
using NUnit.Framework;

namespace CSharp6Test
{
    [TestFixture]
    public class ExtensionsTest
    {
        [Test]
        public void extension_methods()
        {
            var ville = new Ville
            {
                Name = "Vauréal",
                CodePostal = "95490"
            };
            Check.That(ville.Detruire()).IsEqualTo("La ville Vauréal avec le code postal 95490 sera détruite !");
        }
    }

    public class Ville
    {
        public string Name { get; set; }
        public string CodePostal { get; set; }

        public string Contruire()
        {
            return $"La ville {Name} est construite !";
        }
    }

    public static class VilleExtension
    {
        public static string Detruire(this Ville ville)
        {
            return $"La ville {ville.Name} avec le code postal {ville.CodePostal} sera détruite !";
        }
    }
}