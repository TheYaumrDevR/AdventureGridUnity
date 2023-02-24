using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class RotationDataBlockDecoratorTest
    {
        [Test]
        public void TestRotationStateIsCorrectlySetAfterRotations()
        {
            RotationDataBlockDecorator testCandidate = new RotationDataBlockDecorator(WalnutWoodArrowSignplateBlock.GetInstance());

            testCandidate.RotatePositiveAroundXAxis();
            testCandidate.RotateNegativeAroundYAxis();
            testCandidate.RotatePositiveAroundZAxis();

            RotationState result = testCandidate.CurrentRotationState;

            Assert.That(result, Is.TypeOf<LeftPointingUpRotationState>());
            
        }

        [Test]
        public void TestRotationStateIsCorrectlySetAfterRotationsWithLockedXAxisRotation()
        {
            RotationDataBlockDecorator testCandidate = new RotationDataBlockDecorator(WalnutWoodArrowSignplateBlock.GetInstance());

            testCandidate.LockXAxisRotation = true;

            testCandidate.RotatePositiveAroundXAxis();
            testCandidate.RotatePositiveAroundYAxis();
            testCandidate.RotateNegativeAroundZAxis();

            RotationState result = testCandidate.CurrentRotationState;

            Assert.That(result, Is.TypeOf<DownPointingRightRotationState>());
        }  

        [Test]
        public void TestRotationStateIsCorrectlySetAfterRotationsWithLockedYAxisRotation()
        {
            RotationDataBlockDecorator testCandidate = new RotationDataBlockDecorator(WalnutWoodArrowSignplateBlock.GetInstance());

            testCandidate.LockYAxisRotation = true;

            testCandidate.RotateNegativeAroundXAxis();
            testCandidate.RotatePositiveAroundYAxis();
            testCandidate.RotateNegativeAroundZAxis();

            RotationState result = testCandidate.CurrentRotationState;

            Assert.That(result, Is.TypeOf<LeftPointingFrontRotationState>());
        }   

        [Test]
        public void TestRotationStateIsCorrectlySetAfterRotationsWithLockedZAxisRotation()
        {
            RotationDataBlockDecorator testCandidate = new RotationDataBlockDecorator(WalnutWoodArrowSignplateBlock.GetInstance());

            testCandidate.LockZAxisRotation = true;

            testCandidate.RotateNegativeAroundXAxis();
            testCandidate.RotateNegativeAroundYAxis();
            testCandidate.RotateNegativeAroundZAxis();

            RotationState result = testCandidate.CurrentRotationState;

            Assert.That(result, Is.TypeOf<DownPointingLeftRotationState>());
        }                      
    }
}