using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class UpPointingRightRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            UpPointingRightRotationState testCandidate = UpPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<BackPointingRightRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            UpPointingRightRotationState testCandidate = UpPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<FrontPointingRightRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            UpPointingRightRotationState testCandidate = UpPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<UpPointingBackRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            UpPointingRightRotationState testCandidate = UpPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<UpPointingFrontRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            UpPointingRightRotationState testCandidate = UpPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<LeftPointingUpRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            UpPointingRightRotationState testCandidate = UpPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<RightPointingDownRotationState>());
        }
    }
}