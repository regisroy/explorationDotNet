using NFluent;
using NUnit.Framework;

namespace CSharp6Test
{
	[TestFixture]
	public class CodeWarsTest
	{
		[Test]
		public void multiply_Test()
		{
			Check.That(CustomMath.multiply(12, "14")).IsEqualTo(168);
		}
	}
}