using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class FrontPointingDownRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            FrontPointingDownRotationState testCandidate = FrontPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<UpPointingFrontRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            FrontPointingDownRotationState testCandidate = FrontPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<DownPointingBackRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            FrontPointingDownRotationState testCandidate = FrontPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<RightPointingDownRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            FrontPointingDownRotationState testCandidate = FrontPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<LeftPointingDownRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            FrontPointingDownRotationState testCandidate = FrontPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<FrontPointingRightRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            FrontPointingDownRotationState testCandidate = FrontPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<FrontPointingLeftRotationState>());
        }
    }
}