using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class DownPointingRightRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            DownPointingRightRotationState testCandidate = DownPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<FrontPointingRightRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            DownPointingRightRotationState testCandidate = DownPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<BackPointingRightRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            DownPointingRightRotationState testCandidate = DownPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<DownPointingBackRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            DownPointingRightRotationState testCandidate = DownPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<DownPointingFrontRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            DownPointingRightRotationState testCandidate = DownPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<RightPointingUpRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            DownPointingRightRotationState testCandidate = DownPointingRightRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<LeftPointingDownRotationState>());
        }
    }
}