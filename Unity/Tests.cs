using NUnit.Framework;
using Unity.Exceptions;

namespace Unity
{
	[TestFixture]
	public class Tests
	{
		[Test]
		public void TestRegistering()
		{
			var container = new UnityContainer();
			//erreur is expected Unity.Exceptions.ResolutionFailedException
			Assert.Throws<ResolutionFailedException>(() => container.Resolve<IObjectsDataSet>("objectDataset"));
		}
	}

	public interface IObjectsDataSet
	{
	}
}