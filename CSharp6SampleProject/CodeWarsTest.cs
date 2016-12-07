using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace CSharp6Test
{
    [TestClass]
    public class CodeWarsTest
    {
        [TestMethod]
        public void multiply_Test()
        {
            Check.That(CustomMath.multiply(12, "14")).IsEqualTo(168);
        }
    }
}