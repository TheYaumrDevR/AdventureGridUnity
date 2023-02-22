using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class RightPointingFrontRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            RightPointingFrontRotationState testCandidate = RightPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<RightPointingUpRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            RightPointingFrontRotationState testCandidate = RightPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<RightPointingDownRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            RightPointingFrontRotationState testCandidate = RightPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<BackPointingRightRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            RightPointingFrontRotationState testCandidate = RightPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<FrontPointingLeftRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            RightPointingFrontRotationState testCandidate = RightPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<UpPointingFrontRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            RightPointingFrontRotationState testCandidate = RightPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<DownPointingFrontRotationState>());
        }
    }
}