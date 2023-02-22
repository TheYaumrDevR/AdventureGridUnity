using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class LeftPointingDownRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            LeftPointingDownRotationState testCandidate = LeftPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<LeftPointingFrontRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            LeftPointingDownRotationState testCandidate = LeftPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<LeftPointingBackRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            LeftPointingDownRotationState testCandidate = LeftPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<FrontPointingDownRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            LeftPointingDownRotationState testCandidate = LeftPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<BackPointingDownRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            LeftPointingDownRotationState testCandidate = LeftPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<DownPointingRightRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            LeftPointingDownRotationState testCandidate = LeftPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<UpPointingLeftRotationState>());
        }
    }
}