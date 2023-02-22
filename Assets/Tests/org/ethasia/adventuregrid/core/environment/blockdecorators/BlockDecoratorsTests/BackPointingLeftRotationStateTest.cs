using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class BackPointingLeftRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            BackPointingLeftRotationState testCandidate = BackPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<DownPointingLeftRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            BackPointingLeftRotationState testCandidate = BackPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<UpPointingLeftRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            BackPointingLeftRotationState testCandidate = BackPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<LeftPointingFrontRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            BackPointingLeftRotationState testCandidate = BackPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<RightPointingBackRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            BackPointingLeftRotationState testCandidate = BackPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<BackPointingDownRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            BackPointingLeftRotationState testCandidate = BackPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<BackPointingUpRotationState>());
        }
    }
}