using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class DownPointingBackRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            DownPointingBackRotationState testCandidate = DownPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<FrontPointingDownRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            DownPointingBackRotationState testCandidate = DownPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<BackPointingUpRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            DownPointingBackRotationState testCandidate = DownPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<DownPointingLeftRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            DownPointingBackRotationState testCandidate = DownPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<DownPointingRightRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            DownPointingBackRotationState testCandidate = DownPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<RightPointingBackRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            DownPointingBackRotationState testCandidate = DownPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<LeftPointingBackRotationState>());
        }
    }
}