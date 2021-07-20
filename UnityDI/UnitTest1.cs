using NUnit.Framework;
using Unity;

namespace UnityDI
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