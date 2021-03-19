using NUnit.Framework;

using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks.ChunkPresentingTests
{
    public class StandardBlockVisualsBuilderTest
    {
        [Test]
        public void TestThatBuildingVisualsWithoutBlockReturnsZeroBuffers()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            testCandidate.Build();

            float[] shapePositions = testCandidate.GetShapePositions();
            int[] shapeTriangleIndices = testCandidate.GetShapeIndices();
            float[] faceNormals = testCandidate.GetShapeNormals();
            float[] uvCoordinates = testCandidate.GetShapeUvCoordinates();

            Assert.That(shapePositions.Length, Is.EqualTo(0));
            Assert.That(shapeTriangleIndices.Length, Is.EqualTo(0));
            Assert.That(faceNormals.Length, Is.EqualTo(0));
            Assert.That(uvCoordinates.Length, Is.EqualTo(0));    
        }   

        [Test]
        public void TestThatTranslatedBlockIsCorrectlyPositioned() 
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            RockBlock blockToRender = RockBlock.GetInstance();
            BlockPosition blockPosition = new BlockPosition(1, 5, 2);

            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetPositionOfBlockInChunk(blockPosition);

            testCandidate.Build();

            float[] expectedPositions = CalculateExpectedVertexPositionsBasedOnBlockPosition(blockPosition);

            float[] shapePositions = testCandidate.GetShapePositions();

            Assert.That(shapePositions, Is.EqualTo(expectedPositions));
        }

        [Test]
        public void TestThatHiddenFrontFacePositionsAreNotPresent()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            EarthBlock blockToRender = EarthBlock.GetInstance();
            BlockPosition blockPosition = new BlockPosition(11, 23, 0);

            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetPositionOfBlockInChunk(blockPosition);
            testCandidate.SetFrontFaceOfBlockIsHidden(true);

            testCandidate.Build();

            float[] tp = CalculateExpectedVertexPositionsBasedOnBlockPosition(blockPosition); // translated positions
            float[] expectedPositions = {
                tp[12], tp[13], tp[14], tp[15], tp[16], tp[17], tp[18], tp[19], tp[20], tp[21], tp[22], tp[23],
                tp[24], tp[25], tp[26], tp[27], tp[28], tp[29], tp[30], tp[31], tp[32], tp[33], tp[34], tp[35],
                tp[36], tp[37], tp[38], tp[39], tp[40], tp[41], tp[42], tp[43], tp[44], tp[45], tp[46], tp[47],
                tp[48], tp[49], tp[50], tp[51], tp[52], tp[53], tp[54], tp[55], tp[56], tp[57], tp[58], tp[59],
                tp[60], tp[61], tp[62], tp[63], tp[64], tp[65], tp[66], tp[67], tp[68], tp[69], tp[70], tp[71]
            };
            float[] shapePositions = testCandidate.GetShapePositions();

            Assert.That(shapePositions, Is.EqualTo(expectedPositions));
        }

        [Test]
        public void TestThatHiddenRightFacePositionsAreNotPresent()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            EarthBlock blockToRender = EarthBlock.GetInstance();
            BlockPosition blockPosition = new BlockPosition(0, 100, 34);

            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetPositionOfBlockInChunk(blockPosition);
            testCandidate.SetRightFaceOfBlockIsHidden(true);

            testCandidate.Build();

            float[] tp = CalculateExpectedVertexPositionsBasedOnBlockPosition(blockPosition); // translated positions
            float[] expectedPositions = {
                tp[0], tp[1], tp[2], tp[3], tp[4], tp[5], tp[6], tp[7], tp[8], tp[9], tp[10], tp[11],
                tp[24], tp[25], tp[26], tp[27], tp[28], tp[29], tp[30], tp[31], tp[32], tp[33], tp[34], tp[35],
                tp[36], tp[37], tp[38], tp[39], tp[40], tp[41], tp[42], tp[43], tp[44], tp[45], tp[46], tp[47],
                tp[48], tp[49], tp[50], tp[51], tp[52], tp[53], tp[54], tp[55], tp[56], tp[57], tp[58], tp[59],
                tp[60], tp[61], tp[62], tp[63], tp[64], tp[65], tp[66], tp[67], tp[68], tp[69], tp[70], tp[71]
            };
            float[] shapePositions = testCandidate.GetShapePositions();

            Assert.That(shapePositions, Is.EqualTo(expectedPositions));
        }

        [Test]
        public void TestThatHiddenBackFacePositionsAreNotPresent()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            GrassyEarthBlock blockToRender = GrassyEarthBlock.GetInstance();
            BlockPosition blockPosition = new BlockPosition(28, 32, 32);

            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetPositionOfBlockInChunk(blockPosition);
            testCandidate.SetBackFaceOfBlockIsHidden(true);

            testCandidate.Build();

            float[] tp = CalculateExpectedVertexPositionsBasedOnBlockPosition(blockPosition); // translated positions
            float[] expectedPositions = {
                tp[0], tp[1], tp[2], tp[3], tp[4], tp[5], tp[6], tp[7], tp[8], tp[9], tp[10], tp[11],
                tp[12], tp[13], tp[14], tp[15], tp[16], tp[17], tp[18], tp[19], tp[20], tp[21], tp[22], tp[23],
                tp[36], tp[37], tp[38], tp[39], tp[40], tp[41], tp[42], tp[43], tp[44], tp[45], tp[46], tp[47],
                tp[48], tp[49], tp[50], tp[51], tp[52], tp[53], tp[54], tp[55], tp[56], tp[57], tp[58], tp[59],
                tp[60], tp[61], tp[62], tp[63], tp[64], tp[65], tp[66], tp[67], tp[68], tp[69], tp[70], tp[71]
            };
            float[] shapePositions = testCandidate.GetShapePositions();

            Assert.That(shapePositions, Is.EqualTo(expectedPositions));
        }

        [Test]
        public void TestThatHiddenLeftFacePositionsAreNotPresent()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            GrassyEarthBlock blockToRender = GrassyEarthBlock.GetInstance();
            BlockPosition blockPosition = new BlockPosition(32, 120, 14);

            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetPositionOfBlockInChunk(blockPosition);
            testCandidate.SetLeftFaceOfBlockIsHidden(true);

            testCandidate.Build();

            float[] tp = CalculateExpectedVertexPositionsBasedOnBlockPosition(blockPosition); // translated positions
            float[] expectedPositions = {
                tp[0], tp[1], tp[2], tp[3], tp[4], tp[5], tp[6], tp[7], tp[8], tp[9], tp[10], tp[11],
                tp[12], tp[13], tp[14], tp[15], tp[16], tp[17], tp[18], tp[19], tp[20], tp[21], tp[22], tp[23],
                tp[24], tp[25], tp[26], tp[27], tp[28], tp[29], tp[30], tp[31], tp[32], tp[33], tp[34], tp[35],
                tp[48], tp[49], tp[50], tp[51], tp[52], tp[53], tp[54], tp[55], tp[56], tp[57], tp[58], tp[59],
                tp[60], tp[61], tp[62], tp[63], tp[64], tp[65], tp[66], tp[67], tp[68], tp[69], tp[70], tp[71]
            };
            float[] shapePositions = testCandidate.GetShapePositions();

            Assert.That(shapePositions, Is.EqualTo(expectedPositions));
        }   

        [Test]
        public void TestThatHiddenBottomFacePositionsAreNotPresent()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            GrassyEarthBlock blockToRender = GrassyEarthBlock.GetInstance();
            BlockPosition blockPosition = new BlockPosition(23, 64, 14);

            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetPositionOfBlockInChunk(blockPosition);
            testCandidate.SetBottomFaceOfBlockIsHidden(true);

            testCandidate.Build();

            float[] tp = CalculateExpectedVertexPositionsBasedOnBlockPosition(blockPosition); // translated positions
            float[] expectedPositions = {
                tp[0], tp[1], tp[2], tp[3], tp[4], tp[5], tp[6], tp[7], tp[8], tp[9], tp[10], tp[11],
                tp[12], tp[13], tp[14], tp[15], tp[16], tp[17], tp[18], tp[19], tp[20], tp[21], tp[22], tp[23],
                tp[24], tp[25], tp[26], tp[27], tp[28], tp[29], tp[30], tp[31], tp[32], tp[33], tp[34], tp[35],
                tp[36], tp[37], tp[38], tp[39], tp[40], tp[41], tp[42], tp[43], tp[44], tp[45], tp[46], tp[47],
                tp[60], tp[61], tp[62], tp[63], tp[64], tp[65], tp[66], tp[67], tp[68], tp[69], tp[70], tp[71]
            };
            float[] shapePositions = testCandidate.GetShapePositions();

            Assert.That(shapePositions, Is.EqualTo(expectedPositions));
        }   

        [Test]
        public void TestThatHiddenTopFacePositionsAreNotPresent()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            GrassyEarthBlock blockToRender = GrassyEarthBlock.GetInstance();
            BlockPosition blockPosition = new BlockPosition(77, 0, 51);

            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetPositionOfBlockInChunk(blockPosition);
            testCandidate.SetTopFaceOfBlockIsHidden(true);

            testCandidate.Build();

            float[] tp = CalculateExpectedVertexPositionsBasedOnBlockPosition(blockPosition); // translated positions
            float[] expectedPositions = {
                tp[0], tp[1], tp[2], tp[3], tp[4], tp[5], tp[6], tp[7], tp[8], tp[9], tp[10], tp[11],
                tp[12], tp[13], tp[14], tp[15], tp[16], tp[17], tp[18], tp[19], tp[20], tp[21], tp[22], tp[23],
                tp[24], tp[25], tp[26], tp[27], tp[28], tp[29], tp[30], tp[31], tp[32], tp[33], tp[34], tp[35],
                tp[36], tp[37], tp[38], tp[39], tp[40], tp[41], tp[42], tp[43], tp[44], tp[45], tp[46], tp[47],
                tp[48], tp[49], tp[50], tp[51], tp[52], tp[53], tp[54], tp[55], tp[56], tp[57], tp[58], tp[59]
            };
            float[] shapePositions = testCandidate.GetShapePositions();

            Assert.That(shapePositions, Is.EqualTo(expectedPositions));
        }            

        [Test]
        public void TestThatIndexBufferForFirstBlockInChunkIsCalculatedProperly()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            RockBlock blockToRender = RockBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);

            testCandidate.Build();

            int[] expectedIndices = CalculateExpectedIndicesBasedOnBlockNumberInChunk(0);
            int[] shapeIndices = testCandidate.GetShapeIndices();

            Assert.That(shapeIndices, Is.EqualTo(expectedIndices));
        } 

        [Test]
        public void TestThatIndexBufferForTenthBlockInChunkIsCalculatedProperly()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            RockBlock blockToRender = RockBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetIndexBufferOffsetInChunk(10);

            testCandidate.Build();

            int[] expectedIndices = CalculateExpectedIndicesBasedOnBlockNumberInChunk(10);
            int[] shapeIndices = testCandidate.GetShapeIndices();

            Assert.That(shapeIndices, Is.EqualTo(expectedIndices));
        }         

        [Test]
        public void TestThatIndexBufferHasReducedIndicesIfFrontFaceIsHidden()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            GrassyEarthBlock blockToRender = GrassyEarthBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetIndexBufferOffsetInChunk(13);
            testCandidate.SetFrontFaceOfBlockIsHidden(true);

            testCandidate.Build();

            int[] fullIndices = CalculateExpectedIndicesBasedOnBlockNumberInChunk(13);
            int[] expectedIndices = {
                fullIndices[0], fullIndices[1], fullIndices[2], fullIndices[3], fullIndices[4], fullIndices[5],
                fullIndices[6], fullIndices[7], fullIndices[8], fullIndices[9], fullIndices[10], fullIndices[11],
                fullIndices[12], fullIndices[13], fullIndices[14], fullIndices[15], fullIndices[16], fullIndices[17],
                fullIndices[18], fullIndices[19], fullIndices[20], fullIndices[21], fullIndices[22], fullIndices[23],
                fullIndices[24], fullIndices[25], fullIndices[26], fullIndices[27], fullIndices[28], fullIndices[29]
            };
            int[] shapeIndices = testCandidate.GetShapeIndices();

            Assert.That(shapeIndices, Is.EqualTo(expectedIndices));
        } 

        [Test]
        public void TestThatIndexBufferHasReducedIndicesIfRightFaceIsHidden()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            EarthBlock blockToRender = EarthBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetIndexBufferOffsetInChunk(3);
            testCandidate.SetRightFaceOfBlockIsHidden(true);

            testCandidate.Build();

            int[] fullIndices = CalculateExpectedIndicesBasedOnBlockNumberInChunk(3);
            int[] expectedIndices = {
                fullIndices[0], fullIndices[1], fullIndices[2], fullIndices[3], fullIndices[4], fullIndices[5],
                fullIndices[6], fullIndices[7], fullIndices[8], fullIndices[9], fullIndices[10], fullIndices[11],
                fullIndices[12], fullIndices[13], fullIndices[14], fullIndices[15], fullIndices[16], fullIndices[17],
                fullIndices[18], fullIndices[19], fullIndices[20], fullIndices[21], fullIndices[22], fullIndices[23],
                fullIndices[24], fullIndices[25], fullIndices[26], fullIndices[27], fullIndices[28], fullIndices[29]
            };
            int[] shapeIndices = testCandidate.GetShapeIndices();

            Assert.That(shapeIndices, Is.EqualTo(expectedIndices));
        } 

        [Test]
        public void TestThatIndexBufferHasReducedIndicesIfBackFaceIsHidden()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            RockBlock blockToRender = RockBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetIndexBufferOffsetInChunk(17);
            testCandidate.SetBackFaceOfBlockIsHidden(true);

            testCandidate.Build();

            int[] fullIndices = CalculateExpectedIndicesBasedOnBlockNumberInChunk(17);
            int[] expectedIndices = {
                fullIndices[0], fullIndices[1], fullIndices[2], fullIndices[3], fullIndices[4], fullIndices[5],
                fullIndices[6], fullIndices[7], fullIndices[8], fullIndices[9], fullIndices[10], fullIndices[11],
                fullIndices[12], fullIndices[13], fullIndices[14], fullIndices[15], fullIndices[16], fullIndices[17],
                fullIndices[18], fullIndices[19], fullIndices[20], fullIndices[21], fullIndices[22], fullIndices[23],
                fullIndices[24], fullIndices[25], fullIndices[26], fullIndices[27], fullIndices[28], fullIndices[29]
            };
            int[] shapeIndices = testCandidate.GetShapeIndices();

            Assert.That(shapeIndices, Is.EqualTo(expectedIndices));
        }  

        [Test]
        public void TestThatIndexBufferHasReducedIndicesIfLeftFaceIsHidden()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            RockBlock blockToRender = RockBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetIndexBufferOffsetInChunk(54);
            testCandidate.SetLeftFaceOfBlockIsHidden(true);

            testCandidate.Build();

            int[] fullIndices = CalculateExpectedIndicesBasedOnBlockNumberInChunk(54);
            int[] expectedIndices = {
                fullIndices[0], fullIndices[1], fullIndices[2], fullIndices[3], fullIndices[4], fullIndices[5],
                fullIndices[6], fullIndices[7], fullIndices[8], fullIndices[9], fullIndices[10], fullIndices[11],
                fullIndices[12], fullIndices[13], fullIndices[14], fullIndices[15], fullIndices[16], fullIndices[17],
                fullIndices[18], fullIndices[19], fullIndices[20], fullIndices[21], fullIndices[22], fullIndices[23],
                fullIndices[24], fullIndices[25], fullIndices[26], fullIndices[27], fullIndices[28], fullIndices[29]
            };
            int[] shapeIndices = testCandidate.GetShapeIndices();

            Assert.That(shapeIndices, Is.EqualTo(expectedIndices));
        }   

        [Test]
        public void TestThatIndexBufferHasReducedIndicesIfBottomFaceIsHidden()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            EarthBlock blockToRender = EarthBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetIndexBufferOffsetInChunk(67);
            testCandidate.SetBottomFaceOfBlockIsHidden(true);

            testCandidate.Build();

            int[] fullIndices = CalculateExpectedIndicesBasedOnBlockNumberInChunk(67);
            int[] expectedIndices = {
                fullIndices[0], fullIndices[1], fullIndices[2], fullIndices[3], fullIndices[4], fullIndices[5],
                fullIndices[6], fullIndices[7], fullIndices[8], fullIndices[9], fullIndices[10], fullIndices[11],
                fullIndices[12], fullIndices[13], fullIndices[14], fullIndices[15], fullIndices[16], fullIndices[17],
                fullIndices[18], fullIndices[19], fullIndices[20], fullIndices[21], fullIndices[22], fullIndices[23],
                fullIndices[24], fullIndices[25], fullIndices[26], fullIndices[27], fullIndices[28], fullIndices[29]
            };
            int[] shapeIndices = testCandidate.GetShapeIndices();

            Assert.That(shapeIndices, Is.EqualTo(expectedIndices));
        }     

        [Test]
        public void TestThatIndexBufferHasReducedIndicesIfTopFaceIsHidden()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            GrassyEarthBlock blockToRender = GrassyEarthBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetIndexBufferOffsetInChunk(21);
            testCandidate.SetTopFaceOfBlockIsHidden(true);

            testCandidate.Build();

            int[] fullIndices = CalculateExpectedIndicesBasedOnBlockNumberInChunk(21);
            int[] expectedIndices = {
                fullIndices[0], fullIndices[1], fullIndices[2], fullIndices[3], fullIndices[4], fullIndices[5],
                fullIndices[6], fullIndices[7], fullIndices[8], fullIndices[9], fullIndices[10], fullIndices[11],
                fullIndices[12], fullIndices[13], fullIndices[14], fullIndices[15], fullIndices[16], fullIndices[17],
                fullIndices[18], fullIndices[19], fullIndices[20], fullIndices[21], fullIndices[22], fullIndices[23],
                fullIndices[24], fullIndices[25], fullIndices[26], fullIndices[27], fullIndices[28], fullIndices[29]
            };
            int[] shapeIndices = testCandidate.GetShapeIndices();

            Assert.That(shapeIndices, Is.EqualTo(expectedIndices));
        }         

        [Test]       
        public void TestThatIndexBufferHasReducedIndicesForFourHiddenFaces()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            GrassyEarthBlock blockToRender = GrassyEarthBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetIndexBufferOffsetInChunk(4);
            testCandidate.SetTopFaceOfBlockIsHidden(true);
            testCandidate.SetBackFaceOfBlockIsHidden(true);
            testCandidate.SetLeftFaceOfBlockIsHidden(true);
            testCandidate.SetRightFaceOfBlockIsHidden(true);

            testCandidate.Build();

            int[] fullIndices = CalculateExpectedIndicesBasedOnBlockNumberInChunk(4);
            int[] expectedIndices = {
                fullIndices[0], fullIndices[1], fullIndices[2], fullIndices[3], fullIndices[4], fullIndices[5],
                fullIndices[6], fullIndices[7], fullIndices[8], fullIndices[9], fullIndices[10], fullIndices[11]
            };
            int[] shapeIndices = testCandidate.GetShapeIndices();

            Assert.That(shapeIndices, Is.EqualTo(expectedIndices));
        }                 

        private float[] CalculateExpectedVertexPositionsBasedOnBlockPosition(BlockPosition blockPosition)
        {
            int x = blockPosition.X;
            int y = blockPosition.Y;
            int z = blockPosition.Z;

            float[] result = {
                x * 0.5f + 0.5f, y * 0.5f, z * 0.5f + 0.5f, x * 0.5f + 0.5f, y * 0.5f + 0.5f, z * 0.5f + 0.5f, x * 0.5f, y * 0.5f + 0.5f, z * 0.5f + 0.5f, x * 0.5f, y * 0.5f, z * 0.5f + 0.5f,
                x * 0.5f + 0.5f, y * 0.5f, z * 0.5f, x * 0.5f + 0.5f, y * 0.5f + 0.5f, z * 0.5f, x * 0.5f + 0.5f, y * 0.5f + 0.5f, z * 0.5f + 0.5f, x * 0.5f + 0.5f, y * 0.5f, z * 0.5f + 0.5f,
                x * 0.5f, y * 0.5f, z * 0.5f, x * 0.5f, y * 0.5f + 0.5f, z * 0.5f, x * 0.5f + 0.5f, y * 0.5f + 0.5f, z * 0.5f, x * 0.5f + 0.5f, y * 0.5f, z * 0.5f,
                x * 0.5f, y * 0.5f, z * 0.5f + 0.5f, x * 0.5f, y * 0.5f + 0.5f, z * 0.5f + 0.5f, x * 0.5f, y * 0.5f + 0.5f, z * 0.5f, x * 0.5f, y * 0.5f, z * 0.5f,
                x * 0.5f + 0.5f, y * 0.5f, z * 0.5f, x * 0.5f + 0.5f, y * 0.5f, z * 0.5f + 0.5f, x * 0.5f, y * 0.5f, z * 0.5f + 0.5f, x * 0.5f, y * 0.5f, z * 0.5f,
                x * 0.5f + 0.5f, y * 0.5f + 0.5f, z * 0.5f + 0.5f, x * 0.5f + 0.5f, y * 0.5f + 0.5f, z * 0.5f, x * 0.5f, y * 0.5f + 0.5f, z * 0.5f, x * 0.5f, y * 0.5f + 0.5f, z * 0.5f + 0.5f
            };  

            return result;          
        }

        private int[] CalculateExpectedIndicesBasedOnBlockNumberInChunk(int blockNumberInChunk)
        {
            int indexOffset = blockNumberInChunk * 24;

            int[] result = {
                blockNumberInChunk + 0, blockNumberInChunk + 1, blockNumberInChunk + 2, blockNumberInChunk + 2, blockNumberInChunk + 3, blockNumberInChunk + 0,
                blockNumberInChunk + 4, blockNumberInChunk + 5, blockNumberInChunk + 6, blockNumberInChunk + 6, blockNumberInChunk + 7, blockNumberInChunk + 4,
                blockNumberInChunk + 8, blockNumberInChunk + 9, blockNumberInChunk + 10, blockNumberInChunk + 10, blockNumberInChunk + 11, blockNumberInChunk + 8,
                blockNumberInChunk + 12, blockNumberInChunk + 13, blockNumberInChunk + 14, blockNumberInChunk + 14, blockNumberInChunk + 15, blockNumberInChunk + 12,
                blockNumberInChunk + 16, blockNumberInChunk + 17, blockNumberInChunk + 18, blockNumberInChunk + 18, blockNumberInChunk + 19, blockNumberInChunk + 16,
                blockNumberInChunk + 20, blockNumberInChunk + 21, blockNumberInChunk + 22, blockNumberInChunk + 22, blockNumberInChunk + 23, blockNumberInChunk + 20                
            };

            return result;
        }
    }
}
