using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class RightPointingDownRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            RightPointingDownRotationState testCandidate = RightPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<RightPointingFrontRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            RightPointingDownRotationState testCandidate = RightPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<RightPointingBackRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            RightPointingDownRotationState testCandidate = RightPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<BackPointingDownRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            RightPointingDownRotationState testCandidate = RightPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<FrontPointingDownRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            RightPointingDownRotationState testCandidate = RightPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<UpPointingRightRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            RightPointingDownRotationState testCandidate = RightPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<DownPointingLeftRotationState>());
        }
    }
}