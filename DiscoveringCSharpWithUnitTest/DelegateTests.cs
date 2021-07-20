using MesPremiersUnitTestProject;
using NFluent;
using NUnit.Framework;

namespace CSharp6Test
{
    [TestFixture]
    public class DelegateTests
    {
        private delegate string Stringify(Person person);

        [Test]
        public void test_a_faire()
        {
            Check.That(true).IsTrue();
        }
    }
}