using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class BackPointingUpRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            BackPointingUpRotationState testCandidate = BackPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<DownPointingBackRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            BackPointingUpRotationState testCandidate = BackPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<UpPointingFrontRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            BackPointingUpRotationState testCandidate = BackPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<LeftPointingUpRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            BackPointingUpRotationState testCandidate = BackPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<RightPointingUpRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            BackPointingUpRotationState testCandidate = BackPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<BackPointingLeftRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            BackPointingUpRotationState testCandidate = BackPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<BackPointingRightRotationState>());
        }
    }
}