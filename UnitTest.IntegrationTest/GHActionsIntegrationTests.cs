using GHActionsPOCCD.Service;
using NUnit.Framework;

namespace UnitTest.IntegrationTest
{
    [TestFixture]
    public class GHActionsIntegrationTests
    {
        private GHActionsService _gHActionsService;

        [OneTimeSetUp]
        public void Initialize()
        {
            _gHActionsService = new GHActionsService();
        }
        [Test]
        public void ReturnValidString_Sucess()
        {
            Assert.That(_gHActionsService.Amigos(), Is.Not.Null);
        }
    }
}
