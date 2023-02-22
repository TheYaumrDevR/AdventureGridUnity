using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class UpPointingBackRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            UpPointingBackRotationState testCandidate = UpPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<BackPointingDownRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            UpPointingBackRotationState testCandidate = UpPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<FrontPointingUpRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            UpPointingBackRotationState testCandidate = UpPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<UpPointingLeftRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            UpPointingBackRotationState testCandidate = UpPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<UpPointingRightRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            UpPointingBackRotationState testCandidate = UpPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<LeftPointingBackRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            UpPointingBackRotationState testCandidate = UpPointingBackRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<RightPointingBackRotationState>());
        } 
    }
}