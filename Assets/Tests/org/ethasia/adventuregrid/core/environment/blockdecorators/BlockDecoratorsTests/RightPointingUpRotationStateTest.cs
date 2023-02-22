using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class RightPointingUpRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            RightPointingUpRotationState testCandidate = RightPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<RightPointingBackRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            RightPointingUpRotationState testCandidate = RightPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<RightPointingFrontRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            RightPointingUpRotationState testCandidate = RightPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<BackPointingUpRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            RightPointingUpRotationState testCandidate = RightPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<FrontPointingUpRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            RightPointingUpRotationState testCandidate = RightPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<UpPointingLeftRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            RightPointingUpRotationState testCandidate = RightPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<DownPointingRightRotationState>());
        }
    }
}