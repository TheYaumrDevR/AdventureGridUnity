using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class LeftPointingUpRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            LeftPointingUpRotationState testCandidate = LeftPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<LeftPointingBackRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            LeftPointingUpRotationState testCandidate = LeftPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<LeftPointingFrontRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            LeftPointingUpRotationState testCandidate = LeftPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<FrontPointingUpRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            LeftPointingUpRotationState testCandidate = LeftPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<BackPointingUpRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            LeftPointingUpRotationState testCandidate = LeftPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<DownPointingLeftRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            LeftPointingUpRotationState testCandidate = LeftPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<UpPointingRightRotationState>());
        }
    }
}