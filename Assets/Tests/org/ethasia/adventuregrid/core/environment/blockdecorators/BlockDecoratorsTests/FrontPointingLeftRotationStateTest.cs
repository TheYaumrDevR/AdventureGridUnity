using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class FrontPointingLeftRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            FrontPointingLeftRotationState testCandidate = FrontPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<UpPointingLeftRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            FrontPointingLeftRotationState testCandidate = FrontPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<DownPointingLeftRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            FrontPointingLeftRotationState testCandidate = FrontPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<RightPointingFrontRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            FrontPointingLeftRotationState testCandidate = FrontPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<LeftPointingBackRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            FrontPointingLeftRotationState testCandidate = FrontPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<FrontPointingDownRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            FrontPointingLeftRotationState testCandidate = FrontPointingLeftRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<FrontPointingUpRotationState>());
        }
    }
}