using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace NFluent.Test
{
    [TestFixture]
    public class NFluentDemoTest
    {
        private readonly int[] _integers = {1, 2, 3, 4, 5, 666};
        private readonly int[] _integersReversed = { 3, 2, 1 };
        private readonly string[] _guitarHeroes = {"Hendrix", "Paco de Lucia", "Django Reinhardt", "Baden Powell"};
        private readonly Person _camus = new Person {Name = "Camus"};
        private readonly Person _sartre = new Person {Name = "Sartre"};

        [Test]
        public void MiscChecks()
        {
            Check.That(_integers).Contains(3, 5, 666);

            Check.That(_integersReversed).IsOnlyMadeOf(3, 2, 1);

            Check.That(_guitarHeroes).ContainsExactly("Hendrix", "Paco de Lucia", "Django Reinhardt", "Baden Powell");

            Check.That(_camus).IsNotEqualTo(_sartre).And.IsInstanceOf<Person>();

            const string heroes = "Batman and Robin";
            Check.That(heroes).Not.Contains("Joker").And.StartsWith("Bat").And.Contains("Robin");

            int? one = 1;
            Check.That(one).HasAValue().Which.IsPositive().And.IsEqualTo(1);

            const Nationality frenchNationality = Nationality.French;
            Check.ThatEnum(frenchNationality).IsNotEqualTo(Nationality.Korean);

            const string motivationalSaying = "Failure is mother of success.";
            Check.That(motivationalSaying).IsNotInstanceOf<int>();
        }

        [Test]
        public void Demo3()
        {
            // Works also with lambda for exception checking
            Check.ThatCode(() => { throw new InvalidOperationException(); }).Throws<InvalidOperationException>();

            // or execution duration checking
            Check.ThatCode(() => Thread.Sleep(30)).LastsLessThan(60, TimeUnit.Milliseconds);
        }

        [Test]
        public void Demo2()
        {
            var persons = new List<Person>
            {
                new Person {Name = "Thomas", Age = 38},
                new Person {Name = "Achille", Age = 10, Nationality = Nationality.French},
                new Person {Name = "Anton", Age = 7, Nationality = Nationality.French},
                new Person {Name = "Arjun", Age = 7, Nationality = Nationality.Indian}
            };

            Check.That(persons.Extracting("Name")).ContainsExactly("Thomas", "Achille", "Anton", "Arjun");
            Check.That(persons.Extracting("Age")).ContainsExactly(38, 10, 7, 7);
            Check.That(persons.Extracting("Nationality"))
                .ContainsExactly(Nationality.Unknown, Nationality.French, Nationality.French, Nationality.Indian);
        }
    }
}