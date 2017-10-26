using MesPremiersUnitTestProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace CSharp6Test
{
    [TestClass]
    public class ClassTypeTest
    {
        [TestMethod]
        public void Type_string_properties()
        {
            Check.That(typeof(Person).Name).IsEqualTo("Person");
            Check.That(typeof(Person).FullName).IsEqualTo("MesPremiersUnitTestProject.Person");
            Check.That(typeof(Person).AssemblyQualifiedName).IsEqualTo("MesPremiersUnitTestProject.Person, MesPremiersUnitTestProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            Check.That(typeof(Person).Namespace).IsEqualTo("MesPremiersUnitTestProject");
        }
    }
}