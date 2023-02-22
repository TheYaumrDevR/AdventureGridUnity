using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class UpPointingFrontRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            UpPointingFrontRotationState testCandidate = UpPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<BackPointingUpRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            UpPointingFrontRotationState testCandidate = UpPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<FrontPointingDownRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            UpPointingFrontRotationState testCandidate = UpPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<UpPointingRightRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            UpPointingFrontRotationState testCandidate = UpPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<UpPointingLeftRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            UpPointingFrontRotationState testCandidate = UpPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<LeftPointingFrontRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            UpPointingFrontRotationState testCandidate = UpPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<RightPointingFrontRotationState>());
        } 
    }
}