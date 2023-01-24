using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Interactors.Factories;
using Org.Ethasia.Adventuregrid.Interactors.Mocks;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Mocks;

using NUnit.Framework;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Controllers.ControllerTests
{
    public class PlayerWithWorldInteractionControllerTest
    {
        [SetUp]
        public void InitDependencies()
        {
            InteractorsFactory.SetInstance(new InteractorsMockFactory());
        }

        [Test]
        public void TestPlayerIsGroundedPassesCorrectBlockPositions()
        {
            PlayerWithWorldInteractionControllerImpl testCandidate = new PlayerWithWorldInteractionControllerImpl();
            Position3 testPosition = new Position3(22538.03f, 10414.37f, 38488.55f);

            testCandidate.TestPlayerIsGrounded(testPosition);

            BlockPosition? usedBlockPosition = GroundedCheckInteractorMock.GetLastPassedBlockPosition();
            GroundedCheckInteractorMock.ResetMock();

            Assert.That(usedBlockPosition?.X, Is.EqualTo(45076));
            Assert.That(usedBlockPosition?.Y, Is.EqualTo(20828));
            Assert.That(usedBlockPosition?.Z, Is.EqualTo(76977));
        }
    }
}