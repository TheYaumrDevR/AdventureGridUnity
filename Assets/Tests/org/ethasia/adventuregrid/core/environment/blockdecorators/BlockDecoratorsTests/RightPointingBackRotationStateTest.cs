using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class RightPointingBackRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            RightPointingBackRotationState testCandidate = RightPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<RightPointingDownRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            RightPointingBackRotationState testCandidate = RightPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<RightPointingUpRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            RightPointingBackRotationState testCandidate = RightPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<BackPointingLeftRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            RightPointingBackRotationState testCandidate = RightPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<FrontPointingRightRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            RightPointingBackRotationState testCandidate = RightPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<UpPointingBackRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            RightPointingBackRotationState testCandidate = RightPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<DownPointingBackRotationState>());
        }
    }
}