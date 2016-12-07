using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using CSharp6Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using static CSharp6.CSharp6Class;

namespace CSharp6
{
    [TestClass]
    public class CSharp6Test
    {
        [TestMethod]
        public void Method_ExpressionBodied_Test()
        {
            //1
            Check.That(ExpressionBodied(10)).IsEqualTo(20);
            //2
            var instance = new CSharp6Class();
            instance.ExpressionBodied("un message");
            Check.That(instance.Recorder).IsEqualTo("un message");
        }

        [TestMethod]
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

        [TestMethod]
        public void Type_String_Interpolation_Test()
        {
            const string variable = "valeure";
            //1 : String concatenation / interpolation
            Check.That($"Concaténation de string spécial C#6. {variable}")
                .IsEqualTo("Concaténation de string spécial C#6. valeure");
        }

        [TestMethod]
        public void Types_Test()
        {
            //int - Int32
            const int monInt = 12;
            Check.That(Int32.Parse("12")).IsEqualTo(monInt);
            //default values
            Check.That(new Int16()).IsEqualTo((short) 0);
            Check.That(new Int32()).IsEqualTo((int) 0);
            Check.That(new Int64()).IsEqualTo((long) 0);
            Check.That(new Int64()).IsEqualTo((long) 0);
            Check.That(new Int64()).IsEqualTo((long) 0);
            Check.That(new Single()).IsEqualTo((float) 0F);
            Check.That(new Double()).IsEqualTo((double) 0D);
            Check.That(new Decimal()).IsEqualTo((decimal) 0M);
        }

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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
            Check.That(list).HasSize(7);
        }
    }
}