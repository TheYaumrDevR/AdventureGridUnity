using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class FrontPointingUpRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            FrontPointingUpRotationState testCandidate = FrontPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<UpPointingBackRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            FrontPointingUpRotationState testCandidate = FrontPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<DownPointingFrontRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            FrontPointingUpRotationState testCandidate = FrontPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<RightPointingUpRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            FrontPointingUpRotationState testCandidate = FrontPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<LeftPointingUpRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            FrontPointingUpRotationState testCandidate = FrontPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<FrontPointingLeftRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            FrontPointingUpRotationState testCandidate = FrontPointingUpRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<FrontPointingRightRotationState>());
        }
    }
}