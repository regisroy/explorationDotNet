using MesPremiersUnitTestProject;
using NFluent;
using NUnit.Framework;

namespace CSharp6Test
{
    [TestFixture]
    public class ClassTypeTest
    {
        [Test]
        public void Type_string_properties()
        {
            Check.That(typeof(Person).Name).IsEqualTo("Person");
            Check.That(typeof(Person).FullName).IsEqualTo("MesPremiersUnitTestProject.Person");
            Check.That(typeof(Person).AssemblyQualifiedName).IsEqualTo("MesPremiersUnitTestProject.Person, DiscoveringC#WithUnitTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            Check.That(typeof(Person).Namespace).IsEqualTo("MesPremiersUnitTestProject");
        }
    }
}