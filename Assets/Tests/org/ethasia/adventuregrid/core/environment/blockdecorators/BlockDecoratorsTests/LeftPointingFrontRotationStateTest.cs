using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class LeftPointingFrontRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            LeftPointingFrontRotationState testCandidate = LeftPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<LeftPointingUpRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            LeftPointingFrontRotationState testCandidate = LeftPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<LeftPointingDownRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            LeftPointingFrontRotationState testCandidate = LeftPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<FrontPointingRightRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            LeftPointingFrontRotationState testCandidate = LeftPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<BackPointingLeftRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            LeftPointingFrontRotationState testCandidate = LeftPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<DownPointingFrontRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            LeftPointingFrontRotationState testCandidate = LeftPointingFrontRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<UpPointingFrontRotationState>());
        }
    }
}