using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class DownPointingLeftRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            DownPointingLeftRotationState testCandidate = DownPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<FrontPointingLeftRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            DownPointingLeftRotationState testCandidate = DownPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<BackPointingLeftRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            DownPointingLeftRotationState testCandidate = DownPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<DownPointingFrontRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            DownPointingLeftRotationState testCandidate = DownPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<DownPointingBackRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            DownPointingLeftRotationState testCandidate = DownPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<RightPointingDownRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            DownPointingLeftRotationState testCandidate = DownPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<LeftPointingUpRotationState>());
        }
    }
}