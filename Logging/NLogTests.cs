using System;
using NLog;
using NUnit.Framework;

namespace Logging
{
    [TestFixture]
    public class Tests
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        [Test]
        public void NLog_Tests()
        {
            
            var exception = new Exception("Ce est une exception");
            var exception2 = new Exception("Ce est une exception", exception);
            logger.Error(exception2);
        }
    }
}