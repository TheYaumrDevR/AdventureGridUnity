using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class BackPointingRightRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            BackPointingRightRotationState testCandidate = BackPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<DownPointingRightRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            BackPointingRightRotationState testCandidate = BackPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<UpPointingRightRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            BackPointingRightRotationState testCandidate = BackPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<LeftPointingBackRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            BackPointingRightRotationState testCandidate = BackPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<RightPointingFrontRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            BackPointingRightRotationState testCandidate = BackPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<BackPointingUpRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            BackPointingRightRotationState testCandidate = BackPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<BackPointingDownRotationState>());
        }
    }
}