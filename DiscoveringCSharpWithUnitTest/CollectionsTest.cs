using System.Collections.Generic;
using MesPremiersUnitTestProject;
using NFluent;
using NUnit.Framework;

namespace CSharp6Test
{
    [TestFixture]
    public class CollectionsTest
    {
        [Test]
        public void HashSet_duplicates()
        {
            var mois = new HashSet<string>();
            mois.Add("janvier");
            mois.Add("février");
            mois.Add("mars");
            mois.Add("mars");
            mois.Add("avril");
            Check.That(mois.Count).IsEqualTo(4);

            mois.Add("avril");
            mois.Add("avril");
            Check.That(mois.Count).IsEqualTo(4);
        }

        [Test]
        public void List_duplicates()
        {
            var mois = new List<string>();
            mois.Add("janvier");
            mois.Add("février");
            mois.Add("mars");
            mois.Add("mars");
            mois.Add("avril");
            Check.That(mois.Count).IsEqualTo(5);

            mois.Add("avril");
            mois.Add("avril");
            Check.That(mois.Count).IsEqualTo(7);
        }

        [Test]
        public void MultiMapList_duplicates()
        {

            var personnesParVille = new MultiMapList<string, string>();
            //Lookup<string, string> personnesParVille = (Lookup<string, string>)new List<Person>().ToLookup(k => k.Ville, v => v.Nom);
            personnesParVille.Add("Paris","Arthur");
            personnesParVille.Add("Paris", "Arthur");
            personnesParVille.Add("Paris", "Laurent");
            personnesParVille.Add("Paris", "David");
            personnesParVille.Add("Versailles", "Arthur");
            Check.That(personnesParVille.Count).IsEqualTo(2);
            Check.That(personnesParVille["Paris"].Count).IsEqualTo(4);
            Check.That(personnesParVille["Versailles"].Count).IsEqualTo(1);

            personnesParVille.Add("Versailles", "Arthur");
            Check.That(personnesParVille["Versailles"].Count).IsEqualTo(2);
            Check.That(personnesParVille.Count).IsEqualTo(2);

            personnesParVille.Add("Versailles", "Annabelle");
            Check.That(personnesParVille["Versailles"].Count).IsEqualTo(3);
            Check.That(personnesParVille.Count).IsEqualTo(2);

            personnesParVille.Add("Aix", "Françoise");
            Check.That(personnesParVille.Count).IsEqualTo(3);
        }

        [Test]
        public void MultiMapSet_duplicates()
        {
            var personnesParVille = new MultiMapSet<string, string>();
            //Lookup<string, string> personnesParVille = (Lookup<string, string>)new List<Person>().ToLookup(k => k.Ville, v => v.Nom);
            personnesParVille.Add("Paris","Arthur");
            personnesParVille.Add("Paris", "Arthur");
            personnesParVille.Add("Paris", "Laurent");
            personnesParVille.Add("Paris", "David");
            personnesParVille.Add("Versailles", "Arthur");
            Check.That(personnesParVille.Count).IsEqualTo(2);
            Check.That(personnesParVille["Paris"].Count).IsEqualTo(3);
            Check.That(personnesParVille["Versailles"].Count).IsEqualTo(1);

            personnesParVille.Add("Versailles", "Arthur");
            Check.That(personnesParVille["Versailles"].Count).IsEqualTo(1);
            Check.That(personnesParVille.Count).IsEqualTo(2);

            personnesParVille.Add("Versailles", "Annabelle");
            Check.That(personnesParVille["Versailles"].Count).IsEqualTo(2);
            Check.That(personnesParVille.Count).IsEqualTo(2);

            personnesParVille.Add("Aix", "Françoise");
            Check.That(personnesParVille.Count).IsEqualTo(3);
            Check.That(personnesParVille["Aix"].Count).IsEqualTo(1);
        }
    }
}