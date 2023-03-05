using NUnit.Framework;

using Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Tests
{
    public class SignPlateBlockAttachmentStrategyTest
    {
        private SignPlateBlockAttachmentStrategy testCandidate = new SignPlateBlockAttachmentStrategy();
        private RotationVisitor rotationVisitor = RotationVisitor.GetInstance();

        [Test]
        public void AttachesToLeftBlockForCorrectBlockTypeAndRotation()
        {
            Block block = WalnutWoodArrowSignplateBlock.GetInstance();
            bool result = testCandidate.AttachesToLeftBlock(block);

            Assert.That(result, Is.True);
        }

        [Test]
        public void DoesNotAttachToLeftBlockWithIncorrectRotation()
        {
            Block block = WalnutWoodArrowSignplateBlock.GetInstance();

            block.Visit(rotationVisitor);
            rotationVisitor.RotateNegativeAroundYAxis();

            bool result = testCandidate.AttachesToLeftBlock(block);

            Assert.That(result, Is.False);
        }    

        [Test]
        public void DoesNotAttachToLeftBlockForIncorrectNeighbor()
        {
            Block block = RockBlock.GetInstance();
            bool result = testCandidate.AttachesToLeftBlock(block);

            Assert.That(result, Is.False);
        }   

        [Test]
        public void AttachesToFrontBlockForCorrectBlockTypeAndRotation()
        {
            Block block = WalnutWoodArrowSignplateBlock.GetInstance();

            block.Visit(rotationVisitor);
            rotationVisitor.RotatePositiveAroundYAxis();

            bool result = testCandidate.AttachesToFrontBlock(block);

            Assert.That(result, Is.True);
        }

        [Test]
        public void DoesNotAttachToFrontBlockWithIncorrectRotation()
        {
            Block block = WalnutWoodArrowSignplateBlock.GetInstance();

            block.Visit(rotationVisitor);
            rotationVisitor.RotateNegativeAroundYAxis();

            bool result = testCandidate.AttachesToFrontBlock(block);

            Assert.That(result, Is.False);
        }    

        [Test]
        public void DoesNotAttachToFrontBlockForIncorrectNeighbor()
        {
            Block block = RockBlock.GetInstance();
            bool result = testCandidate.AttachesToFrontBlock(block);

            Assert.That(result, Is.False);
        }       

        [Test]
        public void AttachesToRightBlockForCorrectBlockTypeAndRotation()
        {
            Block block = WalnutWoodArrowSignplateBlock.GetInstance();

            block.Visit(rotationVisitor);
            rotationVisitor.RotatePositiveAroundYAxis();
            rotationVisitor.RotatePositiveAroundYAxis();

            bool result = testCandidate.AttachesToRightBlock(block);

            Assert.That(result, Is.True);
        }

        [Test]
        public void DoesNotAttachToRightBlockWithIncorrectRotation()
        {
            Block block = WalnutWoodArrowSignplateBlock.GetInstance();
            bool result = testCandidate.AttachesToRightBlock(block);

            Assert.That(result, Is.False);
        }    

        [Test]
        public void DoesNotAttachToRightBlockForIncorrectNeighbor()
        {
            Block block = WalnutPoleBlock.GetInstance();
            bool result = testCandidate.AttachesToRightBlock(block);

            Assert.That(result, Is.False);
        }  

        [Test]
        public void AttachesToBackBlockForCorrectBlockTypeAndRotation()
        {
            Block block = WalnutWoodArrowSignplateBlock.GetInstance();

            block.Visit(rotationVisitor);
            rotationVisitor.RotateNegativeAroundYAxis();

            bool result = testCandidate.AttachesToBackBlock(block);

            Assert.That(result, Is.True);
        }

        [Test]
        public void DoesNotAttachToBackBlockWithIncorrectRotation()
        {
            Block block = WalnutWoodArrowSignplateBlock.GetInstance();

            block.Visit(rotationVisitor);
            rotationVisitor.RotateNegativeAroundYAxis();
            rotationVisitor.RotateNegativeAroundYAxis();
            rotationVisitor.RotateNegativeAroundYAxis();

            bool result = testCandidate.AttachesToBackBlock(block);

            Assert.That(result, Is.False);
        }    

        [Test]
        public void DoesNotAttachToBackBlockForIncorrectNeighbor()
        {
            Block block = EarthBlock.GetInstance();
            bool result = testCandidate.AttachesToBackBlock(block);

            Assert.That(result, Is.False);
        }                         
    }
}