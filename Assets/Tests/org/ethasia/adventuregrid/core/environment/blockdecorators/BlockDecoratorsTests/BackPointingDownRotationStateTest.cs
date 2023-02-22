using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class BackPointingDownRotationStateTest
    {
        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            BackPointingDownRotationState testCandidate = BackPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundXAxis();

            Assert.That(result, Is.TypeOf<DownPointingFrontRotationState>());
        }

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            BackPointingDownRotationState testCandidate = BackPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundXAxis();

            Assert.That(result, Is.TypeOf<UpPointingBackRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            BackPointingDownRotationState testCandidate = BackPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundYAxis();

            Assert.That(result, Is.TypeOf<LeftPointingDownRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            BackPointingDownRotationState testCandidate = BackPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundYAxis();

            Assert.That(result, Is.TypeOf<RightPointingDownRotationState>());
        }  

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            BackPointingDownRotationState testCandidate = BackPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotatePositiveAroundZAxis();

            Assert.That(result, Is.TypeOf<BackPointingRightRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            BackPointingDownRotationState testCandidate = BackPointingDownRotationState.GetInstance();
            RotationState result = testCandidate.RotateNegativeAroundZAxis();

            Assert.That(result, Is.TypeOf<BackPointingLeftRotationState>());
        }                                        
    }
}
