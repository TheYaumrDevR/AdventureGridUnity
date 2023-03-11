using NUnit.Framework;
using System.Collections.Generic;

using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class BlockNeighborAttachmentInfoVisitorTest
    {
        [Test]
        public void TestIsAttachedToLeftBlockPoleAttachmentBlockAttachesToLeftSignBlock()
        {
            Island island = new Island(8);
            Block attachingBlock = WalnutAttachmentPoleBlock.GetInstance();
            Block attachedBlock = WalnutWoodArrowSignplateBlock.GetInstance();

            BlockPosition attachmentBlockPosition = new BlockPosition(1, 1, 1);
            BlockPosition attachedBlockPosition = new BlockPosition(2, 1, 1);
            island.PlaceBlockAt(attachingBlock, attachmentBlockPosition);
            island.PlaceBlockAt(attachedBlock, attachedBlockPosition);

            BlockNeighborAttachmentInfoVisitor testCandidate = BlockNeighborAttachmentInfoVisitor.GetInstance();
            attachingBlock.Visit(testCandidate);

            Assert.That(testCandidate.IsAttachedToLeftBlock(), Is.True);
            Assert.That(testCandidate.IsAttachedToRightBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToFrontBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToBackBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToTopBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToBottomBlock(), Is.False);
        }

        [Test]
        public void TestIsAttachedToFrontBlockPoleAttachmentBlockAttachesToFrontSignBlock()
        {
            Island island = new Island(8);
            Block attachingBlock = WalnutAttachmentPoleBlock.GetInstance();
            Block attachedBlock = WalnutWoodArrowSignplateBlock.GetInstance();

            RotationVisitor blockRotator = RotationVisitor.GetInstance();
            attachedBlock.Visit(blockRotator);
            blockRotator.RotatePositiveAroundYAxis();

            BlockPosition attachmentBlockPosition = new BlockPosition(1, 1, 1);
            BlockPosition attachedBlockPosition = new BlockPosition(1, 1, 2);
            island.PlaceBlockAt(attachingBlock, attachmentBlockPosition);
            island.PlaceBlockAt(attachedBlock, attachedBlockPosition);

            BlockNeighborAttachmentInfoVisitor testCandidate = BlockNeighborAttachmentInfoVisitor.GetInstance();
            attachingBlock.Visit(testCandidate);

            Assert.That(testCandidate.IsAttachedToLeftBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToRightBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToFrontBlock(), Is.True);
            Assert.That(testCandidate.IsAttachedToBackBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToTopBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToBottomBlock(), Is.False);
        }      

        [Test]
        public void TestIsAttachedToRightBlockPoleAttachmentBlockAttachesToRightSignBlock()
        {
            Island island = new Island(8);
            Block attachingBlock = WalnutAttachmentPoleBlock.GetInstance();
            Block attachedBlock = WalnutWoodArrowSignplateBlock.GetInstance();

            RotationVisitor blockRotator = RotationVisitor.GetInstance();
            attachedBlock.Visit(blockRotator);
            blockRotator.RotatePositiveAroundYAxis();
            blockRotator.RotatePositiveAroundYAxis();

            BlockPosition attachmentBlockPosition = new BlockPosition(1, 1, 1);
            BlockPosition attachedBlockPosition = new BlockPosition(0, 1, 1);
            island.PlaceBlockAt(attachingBlock, attachmentBlockPosition);
            island.PlaceBlockAt(attachedBlock, attachedBlockPosition);

            BlockNeighborAttachmentInfoVisitor testCandidate = BlockNeighborAttachmentInfoVisitor.GetInstance();
            attachingBlock.Visit(testCandidate);

            Assert.That(testCandidate.IsAttachedToLeftBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToRightBlock(), Is.True);
            Assert.That(testCandidate.IsAttachedToFrontBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToBackBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToTopBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToBottomBlock(), Is.False);
        } 

        [Test]
        public void TestIsAttachedToBackBlockPoleAttachmentBlockAttachesToBackSignBlock()
        {
            Island island = new Island(8);
            Block attachingBlock = WalnutAttachmentPoleBlock.GetInstance();
            Block attachedBlock = WalnutWoodArrowSignplateBlock.GetInstance();

            RotationVisitor blockRotator = RotationVisitor.GetInstance();
            attachedBlock.Visit(blockRotator);
            blockRotator.RotateNegativeAroundYAxis();

            BlockPosition attachmentBlockPosition = new BlockPosition(1, 1, 1);
            BlockPosition attachedBlockPosition = new BlockPosition(1, 1, 0);
            island.PlaceBlockAt(attachingBlock, attachmentBlockPosition);
            island.PlaceBlockAt(attachedBlock, attachedBlockPosition);

            BlockNeighborAttachmentInfoVisitor testCandidate = BlockNeighborAttachmentInfoVisitor.GetInstance();
            attachingBlock.Visit(testCandidate);

            Assert.That(testCandidate.IsAttachedToLeftBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToRightBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToFrontBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToBackBlock(), Is.True);
            Assert.That(testCandidate.IsAttachedToTopBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToBottomBlock(), Is.False);
        }  

        [Test]
        public void TestIsAttachedToTopBlockPoleAttachmentBlockDoesntAttach()
        {
            Island island = new Island(8);
            Block attachingBlock = WalnutAttachmentPoleBlock.GetInstance();
            Block attachedBlock = WalnutWoodArrowSignplateBlock.GetInstance();

            RotationVisitor blockRotator = RotationVisitor.GetInstance();
            attachedBlock.Visit(blockRotator);
            blockRotator.RotateNegativeAroundZAxis();

            BlockPosition attachmentBlockPosition = new BlockPosition(1, 1, 1);
            BlockPosition attachedBlockPosition = new BlockPosition(1, 2, 1);
            island.PlaceBlockAt(attachingBlock, attachmentBlockPosition);
            island.PlaceBlockAt(attachedBlock, attachedBlockPosition);

            BlockNeighborAttachmentInfoVisitor testCandidate = BlockNeighborAttachmentInfoVisitor.GetInstance();
            attachingBlock.Visit(testCandidate);

            Assert.That(testCandidate.IsAttachedToLeftBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToRightBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToFrontBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToBackBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToTopBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToBottomBlock(), Is.False);
        }       

        [Test]
        public void TestIsAttachedToBottomBlockPoleAttachmentBlockDoesntAttach()
        {
            Island island = new Island(8);
            Block attachingBlock = WalnutAttachmentPoleBlock.GetInstance();
            Block attachedBlock = WalnutWoodArrowSignplateBlock.GetInstance();

            RotationVisitor blockRotator = RotationVisitor.GetInstance();
            attachedBlock.Visit(blockRotator);
            blockRotator.RotatePositiveAroundZAxis();

            BlockPosition attachmentBlockPosition = new BlockPosition(1, 1, 1);
            BlockPosition attachedBlockPosition = new BlockPosition(1, 0, 1);
            island.PlaceBlockAt(attachingBlock, attachmentBlockPosition);
            island.PlaceBlockAt(attachedBlock, attachedBlockPosition);

            BlockNeighborAttachmentInfoVisitor testCandidate = BlockNeighborAttachmentInfoVisitor.GetInstance();
            attachingBlock.Visit(testCandidate);

            Assert.That(testCandidate.IsAttachedToLeftBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToRightBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToFrontBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToBackBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToTopBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToBottomBlock(), Is.False);
        }  

        [Test]
        public void TestIsAttachedToLeftBlockPoleAttachmentDoesNotAttachWithIncorrectArrowBlockRotation()
        {
            Island island = new Island(8);
            Block attachingBlock = WalnutAttachmentPoleBlock.GetInstance();
            Block attachedBlock = WalnutWoodArrowSignplateBlock.GetInstance();

            RotationVisitor blockRotator = RotationVisitor.GetInstance();
            attachedBlock.Visit(blockRotator);
            blockRotator.RotateNegativeAroundYAxis();

            BlockPosition attachmentBlockPosition = new BlockPosition(1, 1, 1);
            BlockPosition attachedBlockPosition = new BlockPosition(2, 1, 1);
            island.PlaceBlockAt(attachingBlock, attachmentBlockPosition);
            island.PlaceBlockAt(attachedBlock, attachedBlockPosition);

            BlockNeighborAttachmentInfoVisitor testCandidate = BlockNeighborAttachmentInfoVisitor.GetInstance();
            attachingBlock.Visit(testCandidate);

            Assert.That(testCandidate.IsAttachedToLeftBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToRightBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToFrontBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToBackBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToTopBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToBottomBlock(), Is.False);
        }

        [Test]
        public void TestIsAttachedToFrontBlockPoleAttachmentDoesNotAttachWithIncorrectArrowBlockRotation()
        {
            Island island = new Island(8);
            Block attachingBlock = WalnutAttachmentPoleBlock.GetInstance();
            Block attachedBlock = WalnutWoodArrowSignplateBlock.GetInstance();

            BlockPosition attachmentBlockPosition = new BlockPosition(1, 1, 1);
            BlockPosition attachedBlockPosition = new BlockPosition(1, 1, 2);
            island.PlaceBlockAt(attachingBlock, attachmentBlockPosition);
            island.PlaceBlockAt(attachedBlock, attachedBlockPosition);

            BlockNeighborAttachmentInfoVisitor testCandidate = BlockNeighborAttachmentInfoVisitor.GetInstance();
            attachingBlock.Visit(testCandidate);

            Assert.That(testCandidate.IsAttachedToLeftBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToRightBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToFrontBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToBackBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToTopBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToBottomBlock(), Is.False);
        } 

        [Test]
        public void TestIsAttachedToRightBlockPoleAttachmentDoesNotAttachWithIncorrectArrowBlockRotation()
        {
            Island island = new Island(8);
            Block attachingBlock = WalnutAttachmentPoleBlock.GetInstance();
            Block attachedBlock = WalnutWoodArrowSignplateBlock.GetInstance();

            BlockPosition attachmentBlockPosition = new BlockPosition(1, 1, 1);
            BlockPosition attachedBlockPosition = new BlockPosition(0, 1, 1);
            island.PlaceBlockAt(attachingBlock, attachmentBlockPosition);
            island.PlaceBlockAt(attachedBlock, attachedBlockPosition);

            BlockNeighborAttachmentInfoVisitor testCandidate = BlockNeighborAttachmentInfoVisitor.GetInstance();
            attachingBlock.Visit(testCandidate);

            Assert.That(testCandidate.IsAttachedToLeftBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToRightBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToFrontBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToBackBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToTopBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToBottomBlock(), Is.False);
        }

        [Test]
        public void TestIsAttachedToBackBlockPoleAttachmentDoesNotAttachWithIncorrectArrowBlockRotation()
        {
            Island island = new Island(8);
            Block attachingBlock = WalnutAttachmentPoleBlock.GetInstance();
            Block attachedBlock = WalnutWoodArrowSignplateBlock.GetInstance();

            BlockPosition attachmentBlockPosition = new BlockPosition(1, 1, 1);
            BlockPosition attachedBlockPosition = new BlockPosition(1, 1, 0);
            island.PlaceBlockAt(attachingBlock, attachmentBlockPosition);
            island.PlaceBlockAt(attachedBlock, attachedBlockPosition);

            BlockNeighborAttachmentInfoVisitor testCandidate = BlockNeighborAttachmentInfoVisitor.GetInstance();
            attachingBlock.Visit(testCandidate);

            Assert.That(testCandidate.IsAttachedToLeftBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToRightBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToFrontBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToBackBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToTopBlock(), Is.False);
            Assert.That(testCandidate.IsAttachedToBottomBlock(), Is.False);
        }                                                        
    }    
}