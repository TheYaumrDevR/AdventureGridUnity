using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class LeftPointingBackRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            LeftPointingBackRotationState testCandidate = LeftPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<LeftPointingDownRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            LeftPointingBackRotationState testCandidate = LeftPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<LeftPointingUpRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            LeftPointingBackRotationState testCandidate = LeftPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<FrontPointingLeftRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            LeftPointingBackRotationState testCandidate = LeftPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<BackPointingRightRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            LeftPointingBackRotationState testCandidate = LeftPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<DownPointingBackRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            LeftPointingBackRotationState testCandidate = LeftPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<UpPointingBackRotationState>());
        }
    }
}