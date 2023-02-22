using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class UpPointingLeftRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            UpPointingLeftRotationState testCandidate = UpPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<BackPointingLeftRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            UpPointingLeftRotationState testCandidate = UpPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<FrontPointingLeftRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            UpPointingLeftRotationState testCandidate = UpPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<UpPointingFrontRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            UpPointingLeftRotationState testCandidate = UpPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<UpPointingBackRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            UpPointingLeftRotationState testCandidate = UpPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<LeftPointingDownRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            UpPointingLeftRotationState testCandidate = UpPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<RightPointingUpRotationState>());
        }
    }
}