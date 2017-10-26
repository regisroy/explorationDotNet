using System.Collections.Generic;
using System.Linq;
using MesPremiersUnitTestProject;
using NFluent;
using NUnit.Framework;

namespace CSharp6Test
{
    [TestFixture]
    public class LinqTest
    {
        [Test]
        public void Skip()
        {
            var persons = new List<Person>
            {
                new Person("Nom", "Prénom", "Adresse"),
                new Person("Dubois", "Alain", "Adresse"),
                new Person("Azure", "Vincent", "Adresse"),
                new Person("Délai", "Luc", "Adresse"),
                new Person("Zazou", "Simbi", "Adresse"),
                new Person("Vinoux", "Jérémie", "Adresse")
            };

            var list1 = persons.OrderByDescending(e=>e.Nom).Skip(1);
            var person1 = list1.First();
            Check.That(list1).HasSize(5);
            Check.That(person1.Nom).IsEqualTo("Vinoux");

            var list2 = persons.OrderByDescending(e => e.Nom);
            Check.That(list2).HasSize(6);
            var person2 = list2.First();
            Check.That(person2.Nom).IsEqualTo("Zazou");
        }
    }
}