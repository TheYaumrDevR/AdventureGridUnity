using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class FrontPointingRightRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            FrontPointingRightRotationState testCandidate = FrontPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<UpPointingRightRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            FrontPointingRightRotationState testCandidate = FrontPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<DownPointingRightRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            FrontPointingRightRotationState testCandidate = FrontPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<RightPointingBackRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            FrontPointingRightRotationState testCandidate = FrontPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<LeftPointingFrontRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            FrontPointingRightRotationState testCandidate = FrontPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<FrontPointingUpRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            FrontPointingRightRotationState testCandidate = FrontPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<FrontPointingDownRotationState>());
        }
    }
}