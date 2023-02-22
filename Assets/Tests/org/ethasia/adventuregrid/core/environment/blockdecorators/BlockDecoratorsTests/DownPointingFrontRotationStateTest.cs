using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class DownPointingFrontRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            DownPointingFrontRotationState testCandidate = DownPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<FrontPointingUpRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            DownPointingFrontRotationState testCandidate = DownPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<BackPointingDownRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            DownPointingFrontRotationState testCandidate = DownPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<DownPointingRightRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            DownPointingFrontRotationState testCandidate = DownPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<DownPointingLeftRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            DownPointingFrontRotationState testCandidate = DownPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<RightPointingFrontRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            DownPointingFrontRotationState testCandidate = DownPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<LeftPointingFrontRotationState>());
        }
    }
}