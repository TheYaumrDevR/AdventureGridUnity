using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class RotationVisitorTest 
    {
        private RotationVisitor testCandidate = RotationVisitor.GetInstance();

        [Test]
        public void TestRotatePositiveAroundXAxis()
        {
            RotationDataBlockDecorator block = new RotationDataBlockDecorator(EarthBlock.GetInstance());

            block.Visit(testCandidate);
            testCandidate.RotatePositiveAroundXAxis();

            RotationState result = block.CurrentRotationState;
            Assert.That(result, Is.TypeOf<UpPointingBackRotationState>());
        }   

        [Test]
        public void TestRotateNegativeAroundXAxis()
        {
            RotationDataBlockDecorator block = new RotationDataBlockDecorator(EarthBlock.GetInstance());

            block.Visit(testCandidate);
            testCandidate.RotateNegativeAroundXAxis();

            RotationState result = block.CurrentRotationState;
            Assert.That(result, Is.TypeOf<DownPointingFrontRotationState>());
        }     

        [Test]
        public void TestRotatePositiveAroundYAxis()
        {
            RotationDataBlockDecorator block = new RotationDataBlockDecorator(EarthBlock.GetInstance());

            block.Visit(testCandidate);
            testCandidate.RotatePositiveAroundYAxis();

            RotationState result = block.CurrentRotationState;
            Assert.That(result, Is.TypeOf<RightPointingUpRotationState>());
        }   

        [Test]
        public void TestRotateNegativeAroundYAxis()
        {
            RotationDataBlockDecorator block = new RotationDataBlockDecorator(EarthBlock.GetInstance());

            block.Visit(testCandidate);
            testCandidate.RotateNegativeAroundYAxis();

            RotationState result = block.CurrentRotationState;
            Assert.That(result, Is.TypeOf<LeftPointingUpRotationState>());
        } 

        [Test]
        public void TestRotatePositiveAroundZAxis()
        {
            RotationDataBlockDecorator block = new RotationDataBlockDecorator(EarthBlock.GetInstance());

            block.Visit(testCandidate);
            testCandidate.RotatePositiveAroundZAxis();

            RotationState result = block.CurrentRotationState;
            Assert.That(result, Is.TypeOf<FrontPointingLeftRotationState>());
        }  

        [Test]
        public void TestRotateNegativeAroundZAxis()
        {
            RotationDataBlockDecorator block = new RotationDataBlockDecorator(EarthBlock.GetInstance());

            block.Visit(testCandidate);
            testCandidate.RotateNegativeAroundZAxis();

            RotationState result = block.CurrentRotationState;
            Assert.That(result, Is.TypeOf<FrontPointingRightRotationState>());
        }                                    
    }
}