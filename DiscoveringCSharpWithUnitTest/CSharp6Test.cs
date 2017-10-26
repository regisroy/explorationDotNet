using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharp6Test;
using NFluent;
using NUnit.Framework;
using static CSharp6.CSharp6Class;

namespace CSharp6
{
    [TestFixture]
    public class CSharp6Test
    {
        [Test]
        public void Method_ExpressionBodied_Test()
        {
            //1
            Check.That(ExpressionBodied(10)).IsEqualTo(20);
            //2
            var instance = new CSharp6Class();
            instance.ExpressionBodied("un message");
            Check.That(instance.Recorder).IsEqualTo("un message");
        }

        [Test]
        public void Constructor_Test()
        {
            //1 : Constructor : Object initializer
            var cSharp6Class = new CSharp6Class {Version = 6, DateSortie = new DateTime(2015, 1, 1)};
            Check.That(cSharp6Class.DateSortie).IsInSameYearAs(new DateTime(2015, 12, 12));
            Check.That(cSharp6Class.Version).IsEqualTo(6);

            //2 : Constructor : Optional parameters & params
            var cSharp6Class2 = new CSharp6Class(date: new DateTime(2015, 1, 1), name: "C#6");
            Check.That(cSharp6Class2.DateSortie).IsEqualTo(new DateTime(2015, 1, 1));
            Check.That(cSharp6Class2.Version).IsEqualTo(6);
            Check.That(cSharp6Class2.Name).IsEqualTo("C#6");
        }

        [Test]
        public void Type_String_Interpolation_Test()
        {
            const string VARIABLE = "valeure";
            //1 : String concatenation / interpolation
            Check.That($"Concaténation de string spécial C#6. {VARIABLE}")
                 .IsEqualTo("Concaténation de string spécial C#6. valeure");
        }

        [Test]
        public void Types_Test()
        {
            //int - Int32
            const int MON_INT = 12;
            Check.That(int.Parse("12")).IsEqualTo(MON_INT);
            //default values
            Check.That(new short()).IsEqualTo(0);
            Check.That(new int()).IsEqualTo(0);
            Check.That(new long()).IsEqualTo(0);
            Check.That(new long()).IsEqualTo(0);
            Check.That(new long()).IsEqualTo(0);
            Check.That(new float()).IsEqualTo(0F);
            Check.That(new double()).IsEqualTo(0D);
            Check.That(new decimal()).IsEqualTo(0M);
        }

        [Test]
        public void Arrays_Struct_Test()
        {
            //Arrays
            var vowels = new char[5];
            vowels[0] = 'a';
            vowels[1] = 'e';
            vowels[2] = 'i';
            vowels[3] = 'o';
            vowels[4] = 'u';
            Check.That(vowels).HasSize(5).And.ContainsExactly('a', 'e', 'i', 'o', 'u');
            //Default values, values vs references
            var ps = new PointS[100];
            Check.That(ps[0].x).IsEqualTo(0);
            var pc = new PointC[100];
            Check.ThatCode(() =>
            {
                var a1 = pc[0].x;
            }).Throws<NullReferenceException>();
        }

        [Test]
        public void Methods_Test()
        {
            //default values
            var cSharp6Class = new CSharp6Class();
            cSharp6Class.MethodWithDefaultValues();
            Check.That(cSharp6Class.Param1).IsEqualTo("param1 default value");
            Check.That(cSharp6Class.Param2).IsEqualTo("param2 default value");
            Check.That(cSharp6Class.Param3).IsEqualTo("param3 default value");
            Check.That(cSharp6Class.Param4).IsEqualTo("param4 default value");
            //optional parameters
            cSharp6Class.MethodWithOptionalParameter("parameter 0", "parameter 1");
            Check.That(cSharp6Class.Param0).IsEqualTo("parameter 0");
            Check.That(cSharp6Class.Param1).IsEqualTo("parameter 1");
            Check.That(cSharp6Class.Param2).IsEqualTo("param2 default value");
            Check.That(cSharp6Class.Param3).IsEqualTo("param3 default value");
            Check.That(cSharp6Class.Param4).IsEqualTo("param4 default value");
            //named parameters
            cSharp6Class.MethodWithOptionalParameter(param3: "Paramètre 3", param1: "Paramètre 1", param0: "Paramètre 0");
            Check.That(cSharp6Class.Param0).IsEqualTo("Paramètre 0");
            Check.That(cSharp6Class.Param1).IsEqualTo("Paramètre 1");
            Check.That(cSharp6Class.Param2).IsEqualTo("param2 default value");
            Check.That(cSharp6Class.Param3).IsEqualTo("Paramètre 3");
            Check.That(cSharp6Class.Param4).IsEqualTo("param4 default value");
            //by reference
            var point1 = new PointC();
            PointC point2 = cSharp6Class.MethodParameterByRef(ref point1);
            Check.That(point1).IsEqualTo(point2).And.IsNull();
            //by value
            var point3 = new PointC();
            PointC point4 = cSharp6Class.MethodParameterByValue(point3);
            Check.That(point4).IsNotEqualTo(point3).And.IsNull();
            Check.That(point3).IsNotNull();
            //out : if point5 is not changed by method, then a compilation error is raised
            var point5 = new PointC();
            cSharp6Class.MethodParameterOut(out point5);
            Check.That(point5).IsNull();
        }

        [Test]
        public void ConditionalOperators_Test()
        {
            PointC point1 = null;
            PointC point2 = null;
            var point3 = new PointC();
            //null conditional
            Check.That(point1?.message).IsNull();
            point1 = new PointC();
            Check.That(point1?.message?.Append("")).IsNull();
            var stringBuilder = new StringBuilder("1er message");
            point1.message = stringBuilder;
            Check.That(point1.message).IsNotNull().And.IsEqualTo(stringBuilder);
            //null coalescing
            Check.That(point2 ?? point3).IsEqualTo(point3);
            Check.That(point1 ?? point3).IsEqualTo(point1);
        }

        [Test]
        public void Override_vs_Hide()
        {
            var recorder = new StringBuilder();
            BaseClass isReallyBase = new BaseClass {Recorder = recorder};
            BaseClass isReallyDerived = new DerivedClass {Recorder = recorder};
            DerivedClass isClearlyDerived = new DerivedClass {Recorder = recorder};

            isReallyBase.WriteNum(); // writes 100
            Check.That(recorder.ToString()).IsEqualTo("100");
            recorder.Clear();

            isReallyBase.WriteStr(); // writes parent
            Check.That(recorder.ToString()).IsEqualTo("parent");
            recorder.Clear();

            isReallyDerived.WriteNum(); // writes 100
            Check.That(recorder.ToString()).IsEqualTo("100");
            recorder.Clear();

            isReallyDerived.WriteStr(); // writes overrided
            Check.That(recorder.ToString()).IsEqualTo("overrided");
            recorder.Clear();

            isClearlyDerived.WriteNum(); // writes 99999
            Check.That(recorder.ToString()).IsEqualTo("99999");
            recorder.Clear();

            isClearlyDerived.WriteStr(); // writes overrided
            Check.That(recorder.ToString()).IsEqualTo("overrided");
        }

        [Test]
        public void ISet_Test()
        {
            ISet<string> set = new HashSet<string>();
            set.Add("un");
            set.Add("deux");
            set.Add("trois");
            set.Add("quatre");
            set.Add("quatre");
            Check.That(set).ContainsExactly("un", "deux", "trois", "quatre");
        }

        [Test]
        public void List_Test()
        {
            //ArrayList can store different types
            IList list = new ArrayList();
            list.Add(55);
            list.Add("un");
            list.Add("deux");
            list.Add("trois");
            list.Add(12);
            list.Add("quatre");
            list.Add("quatre");
            list.Add(55.3);
            Check.That(list).HasSize(8);
            var enumerator = list.GetEnumerator();
            enumerator.MoveNext();
            var current = enumerator.Current;
            Check.That(current).IsInstanceOf<int>();

            //List must be types
            IList<string> list2 = new List<string>();
            list2.Add("un");
            list2.Add("deux");
            list2.Add("trois");
            list2.Add("trois");
            list2.Add("quatre");
            list2.Add("quatre");
            list2.Add("cinq");
            Check.That(list2).HasSize(7);
        }

        [Test]
        public void TestDates()
        {
            var d1 = new DateTime(2016, 12, 5, 15, 58, 23);
            var d2 = new DateTime(2016, 12, 5, 12, 01, 25);
            var d3 = new DateTime(2016, 12, 5, 12, 01, 25);
            Check.That(d1 == d2).IsFalse();

            Check.That(d3 == d2).IsTrue();
            Check.That(d3.Equals(d2)).IsTrue();

            Check.That(d1.Date == d2.Date).IsTrue();
            Check.That(d1.Date.Equals(d2.Date)).IsTrue();

            var tuple = new Tuple<DateTime?, DateTime?>(new DateTime(2016, 12, 5, 15, 58, 23), null);

            Check.That(tuple.Item1.Value.Date.Equals(tuple.Item2.HasValue ? tuple.Item2.Value : DateTime.MinValue)).IsFalse();
        }

        [Test]
        public void TestLinq()
        {
            var personnes = new List<Personne>
            {
                new Personne(1, "Théo", "95490", "Vauréal", "theo@mail.com"),
                new Personne(2, "Arthur", "92120", "Ermont", ""),
                new Personne(3, "David", "02120", "Guise", "david@mail.com"),
                new Personne(4, "Tristan", "02159", "Chateau", "tristan@mail.com"),
                new Personne(5, "Marc", "75009", "Paris", "marc@mail.com"),
                new Personne(6, "Alain", "95490", "Vauréal", "alain@mail.com"),
                new Personne(6, "Alain", "95490", "Vauréal", ""),
                new Personne(7, "Marc", "75 009", "paris", "marc@mail.com"),
                new Personne(7, "Pierre", "75010", "paris", "pierre@mail.com"),
                new Personne(7, "Pierre", "75 010", "paris", "pierre@mail.com"),
                new Personne(7, "Pierre", "75 010", "paris", "")
            };

            Console.WriteLine("--- list 1 ---");
            var list1 = personnes.OrderBy(order => order.Nom).ToList();
            Console.WriteLine($"list 1:{list1}");
            Check.That(list1).HasSize(11);


            Console.WriteLine("\n--- list 2 ---");
            var list2 = personnes.GroupBy(x => x.Nom).Select(x => x.Count() > 1);
            Console.WriteLine($"list 2:{list2}");
            Check.That(list2).HasSize(7);

            var enumerable = personnes
                .GroupBy(c => c.Nom)
                .Where(grp => grp.Count() > 1)
                .Select(grp => grp.Key);

            var enumerable1 = from c in personnes
                              group c by c.Nom
                              into grp
                              where grp.Count() > 1
                              select grp.Key;

            var groupes =
                    from personne in personnes
                    group personne by personne.Nom
                    into grouping
                    where grouping.Count() > 1
                    orderby grouping.Key
                    select grouping
                ;
            Check.That(groupes).HasSize(3);
            Console.WriteLine("\n--- Groups ----");
            Console.WriteLine($"groups:{groupes}");
            foreach (var groupe in groupes)
            {
                Console.WriteLine($"key:{groupe.Key}");
                foreach (var personneDuGroupe in groupe)
                {
                    Console.WriteLine($"personne du groupe:{personneDuGroupe}");
                }
                Console.WriteLine($"FirstOrDefault:{groupe.FirstOrDefault()}");
                Console.WriteLine($"First:{groupe.First()}");
                Console.WriteLine($"Last:{groupe.Last()}");
            }

            Console.WriteLine("--- List 3 : groups ---");
            var list3 = groupes.ToList();
            foreach (var item in list3)
            {
                Console.WriteLine($"item:{item}");
            }
            Check.That(groupes).HasSize(3);
        }

        [Test]
        public void LindTestSort()
        {
            var personnes = new List<Personne>
            {
                new Personne(7, "Pierre", "75010", "paris", "pierre@mail.com"),
                new Personne(7, "Pierre", "75 010", "paris", "pierre@mail.com"),
                new Personne(7, "Pierre", "75 010", "paris", "")
            };


            var orderedEnumerable = personnes.OrderBy(el => el.Email);

            foreach (var personne in orderedEnumerable)
            {
                Console.WriteLine(personne);
            }

            Console.WriteLine("-- skip 1 --");
            var orderedEnumerable2 = personnes.OrderByDescending(el => el.Email).Skip(1);
            foreach (var personne in orderedEnumerable2)
            {
                Console.WriteLine(personne);
            }
        }

        [Test]
        public void DefaultTest()
        {
            StringBuilder defaultStringBuilder = default(StringBuilder);
            Check.That(defaultStringBuilder).IsNull();

            bool defaultBool = default(bool);
            Check.That(defaultBool).IsFalse();

            int defaultint = default(int);
            Check.That(defaultint).IsEqualTo(0);

            Personne defaultPersonne = default(Personne);
            Check.That(defaultPersonne).IsNull();
        }

        private class Personne
        {
            public Personne(int personId, string nom, string codepostal, string ville, string email)
            {
                PersonId = personId;
                Nom = nom;
                CodePostal = codepostal;
                Ville = ville;
                Email = email;
            }

            public int PersonId { get; set; }
            public string Nom { get; set; }
            public string Email { get; set; }
            public string CodePostal { get; set; }
            public string Ville { get; set; }

            public override string ToString()
            {
                return $"{PersonId} {Nom} {CodePostal} {Email} {Ville}";
            }
        }
    }
}