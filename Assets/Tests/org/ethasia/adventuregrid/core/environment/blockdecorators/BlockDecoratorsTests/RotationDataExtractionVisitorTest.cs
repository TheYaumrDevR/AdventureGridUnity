using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class RotationDataExtractionVisitorTest
    {
        [Test]
        public void TestVisitExtractsRotationData()
        {
            RotationDataExtractionVisitor testCandidate = RotationDataExtractionVisitor.GetInstance();
            RotationDataBlockDecorator block = new RotationDataBlockDecorator(WalnutWoodArrowSignplateBlock.GetInstance());

            block.RotatePositiveAroundXAxis();
            block.RotateNegativeAroundYAxis();
            block.RotatePositiveAroundZAxis();
            block.Visit(testCandidate);

            bool hasRotationState = testCandidate.HasRotationState;
            RotationState result = testCandidate.ExtractedRotationState;
            RotationState expected = block.CurrentRotationState;
            
            Assert.That(hasRotationState, Is.True);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestVisitHasRotationStateResetsAfterExtraction()
        {
            RotationDataExtractionVisitor testCandidate = RotationDataExtractionVisitor.GetInstance();
            RotationDataBlockDecorator block = new RotationDataBlockDecorator(WalnutWoodArrowSignplateBlock.GetInstance());

            block.RotatePositiveAroundXAxis();
            block.RotatePositiveAroundXAxis();
            block.RotatePositiveAroundXAxis();
            block.RotateNegativeAroundYAxis();
            block.RotatePositiveAroundZAxis();
            block.RotateNegativeAroundZAxis();
            block.Visit(testCandidate);

            RotationState result = testCandidate.ExtractedRotationState;
            RotationState expected = block.CurrentRotationState;
            
            Assert.That(testCandidate.HasRotationState, Is.False);
            Assert.That(result, Is.EqualTo(expected));
        }        
    }
}