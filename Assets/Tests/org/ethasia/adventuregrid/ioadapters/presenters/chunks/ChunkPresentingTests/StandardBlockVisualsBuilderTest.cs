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

        [Test]
        public void TestThatCorrectNormalsAreSetForUncoveredBlock()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            RockBlock blockToRender = RockBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);

            testCandidate.Build();

            float[] shapeNormals = testCandidate.GetShapeNormals();
            float[] expectedNormals = CalculateExpectedShapeNormals();

            Assert.That(shapeNormals, Is.EqualTo(expectedNormals));
        }  

        [Test]
        public void TestThatCorrectNormalsAreSetForCoveredFrontFace()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            RockBlock blockToRender = RockBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetFrontFaceOfBlockIsHidden(true);

            testCandidate.Build();

            float[] shapeNormals = testCandidate.GetShapeNormals();
            float[] fullExpectedNormals = CalculateExpectedShapeNormals();
            float[] expectedNormals = {
                fullExpectedNormals[12], fullExpectedNormals[13], fullExpectedNormals[14], fullExpectedNormals[15], fullExpectedNormals[16], fullExpectedNormals[17], fullExpectedNormals[18], fullExpectedNormals[19], fullExpectedNormals[20], fullExpectedNormals[21], fullExpectedNormals[22], fullExpectedNormals[23],
                fullExpectedNormals[24], fullExpectedNormals[25], fullExpectedNormals[26], fullExpectedNormals[27], fullExpectedNormals[28], fullExpectedNormals[29], fullExpectedNormals[30], fullExpectedNormals[31], fullExpectedNormals[32], fullExpectedNormals[33], fullExpectedNormals[34], fullExpectedNormals[35],
                fullExpectedNormals[36], fullExpectedNormals[37], fullExpectedNormals[38], fullExpectedNormals[39], fullExpectedNormals[40], fullExpectedNormals[41], fullExpectedNormals[42], fullExpectedNormals[43], fullExpectedNormals[44], fullExpectedNormals[45], fullExpectedNormals[46], fullExpectedNormals[47],
                fullExpectedNormals[48], fullExpectedNormals[49], fullExpectedNormals[50], fullExpectedNormals[51], fullExpectedNormals[52], fullExpectedNormals[53], fullExpectedNormals[54], fullExpectedNormals[55], fullExpectedNormals[56], fullExpectedNormals[57], fullExpectedNormals[58], fullExpectedNormals[59],
                fullExpectedNormals[60], fullExpectedNormals[61], fullExpectedNormals[62], fullExpectedNormals[63], fullExpectedNormals[64], fullExpectedNormals[65], fullExpectedNormals[66], fullExpectedNormals[67], fullExpectedNormals[68], fullExpectedNormals[69], fullExpectedNormals[70], fullExpectedNormals[71]
            };

            Assert.That(shapeNormals, Is.EqualTo(expectedNormals));
        }  

        [Test]
        public void TestThatCorrectNormalsAreSetForCoveredRightFace()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            EarthBlock blockToRender = EarthBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetRightFaceOfBlockIsHidden(true);

            testCandidate.Build();

            float[] shapeNormals = testCandidate.GetShapeNormals();
            float[] fullExpectedNormals = CalculateExpectedShapeNormals();
            float[] expectedNormals = {
                fullExpectedNormals[0], fullExpectedNormals[1], fullExpectedNormals[2], fullExpectedNormals[3], fullExpectedNormals[4], fullExpectedNormals[5], fullExpectedNormals[6], fullExpectedNormals[7], fullExpectedNormals[8], fullExpectedNormals[9], fullExpectedNormals[10], fullExpectedNormals[11],
                fullExpectedNormals[24], fullExpectedNormals[25], fullExpectedNormals[26], fullExpectedNormals[27], fullExpectedNormals[28], fullExpectedNormals[29], fullExpectedNormals[30], fullExpectedNormals[31], fullExpectedNormals[32], fullExpectedNormals[33], fullExpectedNormals[34], fullExpectedNormals[35],
                fullExpectedNormals[36], fullExpectedNormals[37], fullExpectedNormals[38], fullExpectedNormals[39], fullExpectedNormals[40], fullExpectedNormals[41], fullExpectedNormals[42], fullExpectedNormals[43], fullExpectedNormals[44], fullExpectedNormals[45], fullExpectedNormals[46], fullExpectedNormals[47],
                fullExpectedNormals[48], fullExpectedNormals[49], fullExpectedNormals[50], fullExpectedNormals[51], fullExpectedNormals[52], fullExpectedNormals[53], fullExpectedNormals[54], fullExpectedNormals[55], fullExpectedNormals[56], fullExpectedNormals[57], fullExpectedNormals[58], fullExpectedNormals[59],
                fullExpectedNormals[60], fullExpectedNormals[61], fullExpectedNormals[62], fullExpectedNormals[63], fullExpectedNormals[64], fullExpectedNormals[65], fullExpectedNormals[66], fullExpectedNormals[67], fullExpectedNormals[68], fullExpectedNormals[69], fullExpectedNormals[70], fullExpectedNormals[71]
            };

            Assert.That(shapeNormals, Is.EqualTo(expectedNormals));
        }  

        [Test]
        public void TestThatCorrectNormalsAreSetForCoveredBackFace()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            GrassyEarthBlock blockToRender = GrassyEarthBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetBackFaceOfBlockIsHidden(true);

            testCandidate.Build();

            float[] shapeNormals = testCandidate.GetShapeNormals();
            float[] fullExpectedNormals = CalculateExpectedShapeNormals();
            float[] expectedNormals = {
                fullExpectedNormals[0], fullExpectedNormals[1], fullExpectedNormals[2], fullExpectedNormals[3], fullExpectedNormals[4], fullExpectedNormals[5], fullExpectedNormals[6], fullExpectedNormals[7], fullExpectedNormals[8], fullExpectedNormals[9], fullExpectedNormals[10], fullExpectedNormals[11],
                fullExpectedNormals[12], fullExpectedNormals[13], fullExpectedNormals[14], fullExpectedNormals[15], fullExpectedNormals[16], fullExpectedNormals[17], fullExpectedNormals[18], fullExpectedNormals[19], fullExpectedNormals[20], fullExpectedNormals[21], fullExpectedNormals[22], fullExpectedNormals[23],
                fullExpectedNormals[36], fullExpectedNormals[37], fullExpectedNormals[38], fullExpectedNormals[39], fullExpectedNormals[40], fullExpectedNormals[41], fullExpectedNormals[42], fullExpectedNormals[43], fullExpectedNormals[44], fullExpectedNormals[45], fullExpectedNormals[46], fullExpectedNormals[47],
                fullExpectedNormals[48], fullExpectedNormals[49], fullExpectedNormals[50], fullExpectedNormals[51], fullExpectedNormals[52], fullExpectedNormals[53], fullExpectedNormals[54], fullExpectedNormals[55], fullExpectedNormals[56], fullExpectedNormals[57], fullExpectedNormals[58], fullExpectedNormals[59],
                fullExpectedNormals[60], fullExpectedNormals[61], fullExpectedNormals[62], fullExpectedNormals[63], fullExpectedNormals[64], fullExpectedNormals[65], fullExpectedNormals[66], fullExpectedNormals[67], fullExpectedNormals[68], fullExpectedNormals[69], fullExpectedNormals[70], fullExpectedNormals[71]
            };

            Assert.That(shapeNormals, Is.EqualTo(expectedNormals));
        }    

        [Test]
        public void TestThatCorrectNormalsAreSetForCoveredLeftFace()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            GrassyEarthBlock blockToRender = GrassyEarthBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetLeftFaceOfBlockIsHidden(true);

            testCandidate.Build();

            float[] shapeNormals = testCandidate.GetShapeNormals();
            float[] fullExpectedNormals = CalculateExpectedShapeNormals();
            float[] expectedNormals = {
                fullExpectedNormals[0], fullExpectedNormals[1], fullExpectedNormals[2], fullExpectedNormals[3], fullExpectedNormals[4], fullExpectedNormals[5], fullExpectedNormals[6], fullExpectedNormals[7], fullExpectedNormals[8], fullExpectedNormals[9], fullExpectedNormals[10], fullExpectedNormals[11],
                fullExpectedNormals[12], fullExpectedNormals[13], fullExpectedNormals[14], fullExpectedNormals[15], fullExpectedNormals[16], fullExpectedNormals[17], fullExpectedNormals[18], fullExpectedNormals[19], fullExpectedNormals[20], fullExpectedNormals[21], fullExpectedNormals[22], fullExpectedNormals[23],
                fullExpectedNormals[24], fullExpectedNormals[25], fullExpectedNormals[26], fullExpectedNormals[27], fullExpectedNormals[28], fullExpectedNormals[29], fullExpectedNormals[30], fullExpectedNormals[31], fullExpectedNormals[32], fullExpectedNormals[33], fullExpectedNormals[34], fullExpectedNormals[35],
                fullExpectedNormals[48], fullExpectedNormals[49], fullExpectedNormals[50], fullExpectedNormals[51], fullExpectedNormals[52], fullExpectedNormals[53], fullExpectedNormals[54], fullExpectedNormals[55], fullExpectedNormals[56], fullExpectedNormals[57], fullExpectedNormals[58], fullExpectedNormals[59],
                fullExpectedNormals[60], fullExpectedNormals[61], fullExpectedNormals[62], fullExpectedNormals[63], fullExpectedNormals[64], fullExpectedNormals[65], fullExpectedNormals[66], fullExpectedNormals[67], fullExpectedNormals[68], fullExpectedNormals[69], fullExpectedNormals[70], fullExpectedNormals[71]
            };

            Assert.That(shapeNormals, Is.EqualTo(expectedNormals));
        } 

        [Test]
        public void TestThatCorrectNormalsAreSetForCoveredBottomFace()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            EarthBlock blockToRender = EarthBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetBottomFaceOfBlockIsHidden(true);

            testCandidate.Build();

            float[] shapeNormals = testCandidate.GetShapeNormals();
            float[] fullExpectedNormals = CalculateExpectedShapeNormals();
            float[] expectedNormals = {
                fullExpectedNormals[0], fullExpectedNormals[1], fullExpectedNormals[2], fullExpectedNormals[3], fullExpectedNormals[4], fullExpectedNormals[5], fullExpectedNormals[6], fullExpectedNormals[7], fullExpectedNormals[8], fullExpectedNormals[9], fullExpectedNormals[10], fullExpectedNormals[11],
                fullExpectedNormals[12], fullExpectedNormals[13], fullExpectedNormals[14], fullExpectedNormals[15], fullExpectedNormals[16], fullExpectedNormals[17], fullExpectedNormals[18], fullExpectedNormals[19], fullExpectedNormals[20], fullExpectedNormals[21], fullExpectedNormals[22], fullExpectedNormals[23],
                fullExpectedNormals[24], fullExpectedNormals[25], fullExpectedNormals[26], fullExpectedNormals[27], fullExpectedNormals[28], fullExpectedNormals[29], fullExpectedNormals[30], fullExpectedNormals[31], fullExpectedNormals[32], fullExpectedNormals[33], fullExpectedNormals[34], fullExpectedNormals[35],
                fullExpectedNormals[36], fullExpectedNormals[37], fullExpectedNormals[38], fullExpectedNormals[39], fullExpectedNormals[40], fullExpectedNormals[41], fullExpectedNormals[42], fullExpectedNormals[43], fullExpectedNormals[44], fullExpectedNormals[45], fullExpectedNormals[46], fullExpectedNormals[47],
                fullExpectedNormals[60], fullExpectedNormals[61], fullExpectedNormals[62], fullExpectedNormals[63], fullExpectedNormals[64], fullExpectedNormals[65], fullExpectedNormals[66], fullExpectedNormals[67], fullExpectedNormals[68], fullExpectedNormals[69], fullExpectedNormals[70], fullExpectedNormals[71]
            };

            Assert.That(shapeNormals, Is.EqualTo(expectedNormals));
        }   

        [Test]
        public void TestThatCorrectNormalsAreSetForCoveredTopFace()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();

            EarthBlock blockToRender = EarthBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetTopFaceOfBlockIsHidden(true);

            testCandidate.Build();

            float[] shapeNormals = testCandidate.GetShapeNormals();
            float[] fullExpectedNormals = CalculateExpectedShapeNormals();
            float[] expectedNormals = {
                fullExpectedNormals[0], fullExpectedNormals[1], fullExpectedNormals[2], fullExpectedNormals[3], fullExpectedNormals[4], fullExpectedNormals[5], fullExpectedNormals[6], fullExpectedNormals[7], fullExpectedNormals[8], fullExpectedNormals[9], fullExpectedNormals[10], fullExpectedNormals[11],
                fullExpectedNormals[12], fullExpectedNormals[13], fullExpectedNormals[14], fullExpectedNormals[15], fullExpectedNormals[16], fullExpectedNormals[17], fullExpectedNormals[18], fullExpectedNormals[19], fullExpectedNormals[20], fullExpectedNormals[21], fullExpectedNormals[22], fullExpectedNormals[23],
                fullExpectedNormals[24], fullExpectedNormals[25], fullExpectedNormals[26], fullExpectedNormals[27], fullExpectedNormals[28], fullExpectedNormals[29], fullExpectedNormals[30], fullExpectedNormals[31], fullExpectedNormals[32], fullExpectedNormals[33], fullExpectedNormals[34], fullExpectedNormals[35],
                fullExpectedNormals[36], fullExpectedNormals[37], fullExpectedNormals[38], fullExpectedNormals[39], fullExpectedNormals[40], fullExpectedNormals[41], fullExpectedNormals[42], fullExpectedNormals[43], fullExpectedNormals[44], fullExpectedNormals[45], fullExpectedNormals[46], fullExpectedNormals[47],
                fullExpectedNormals[48], fullExpectedNormals[49], fullExpectedNormals[50], fullExpectedNormals[51], fullExpectedNormals[52], fullExpectedNormals[53], fullExpectedNormals[54], fullExpectedNormals[55], fullExpectedNormals[56], fullExpectedNormals[57], fullExpectedNormals[58], fullExpectedNormals[59]
            };

            Assert.That(shapeNormals, Is.EqualTo(expectedNormals));
        }    

        [Test]
        public void TestThatUvCoordinatesAreEqualToBlockUvCoordinatesForUncoveredFaces()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();
            RockBlock blockToRender = RockBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);

            testCandidate.Build();

            float[] uvCoordinates = testCandidate.GetShapeUvCoordinates();
            float[] expectedUvCoordinates = BlockUvCoordinates.FromBlockType(blockToRender.GetBlockType()).GetUvCoordinates();

            Assert.That(uvCoordinates, Is.EqualTo(expectedUvCoordinates));
        }

        [Test]
        public void TestThatUvCoordinatesHaveAllUvCoordinatesExceptCoveredFrontFaceCoordinates()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();
            RockBlock blockToRender = RockBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetFrontFaceOfBlockIsHidden(true);

            testCandidate.Build();

            float[] uvCoordinates = testCandidate.GetShapeUvCoordinates();
            float[] allBlockCoordinates = BlockUvCoordinates.FromBlockType(blockToRender.GetBlockType()).GetUvCoordinates();
            float[] expectedUvCoordinates = {
                allBlockCoordinates[8], allBlockCoordinates[9], allBlockCoordinates[10], allBlockCoordinates[11], allBlockCoordinates[12], allBlockCoordinates[13], allBlockCoordinates[14], allBlockCoordinates[15],
                allBlockCoordinates[16], allBlockCoordinates[17], allBlockCoordinates[18], allBlockCoordinates[19], allBlockCoordinates[20], allBlockCoordinates[21], allBlockCoordinates[22], allBlockCoordinates[23],
                allBlockCoordinates[24], allBlockCoordinates[25], allBlockCoordinates[26], allBlockCoordinates[27], allBlockCoordinates[28], allBlockCoordinates[29], allBlockCoordinates[30], allBlockCoordinates[31],
                allBlockCoordinates[32], allBlockCoordinates[33], allBlockCoordinates[34], allBlockCoordinates[35], allBlockCoordinates[36], allBlockCoordinates[37], allBlockCoordinates[38], allBlockCoordinates[39],
                allBlockCoordinates[40], allBlockCoordinates[41], allBlockCoordinates[42], allBlockCoordinates[43], allBlockCoordinates[44], allBlockCoordinates[45], allBlockCoordinates[46], allBlockCoordinates[47]
            };

            Assert.That(uvCoordinates, Is.EqualTo(expectedUvCoordinates));
        } 

        [Test]
        public void TestThatUvCoordinatesHaveAllUvCoordinatesExceptCoveredRightFaceCoordinates()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();
            GrassyEarthBlock blockToRender = GrassyEarthBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetRightFaceOfBlockIsHidden(true);

            testCandidate.Build();

            float[] uvCoordinates = testCandidate.GetShapeUvCoordinates();
            float[] allBlockCoordinates = BlockUvCoordinates.FromBlockType(blockToRender.GetBlockType()).GetUvCoordinates();
            float[] expectedUvCoordinates = {
                allBlockCoordinates[0], allBlockCoordinates[1], allBlockCoordinates[2], allBlockCoordinates[3], allBlockCoordinates[4], allBlockCoordinates[5], allBlockCoordinates[6], allBlockCoordinates[7],
                allBlockCoordinates[16], allBlockCoordinates[17], allBlockCoordinates[18], allBlockCoordinates[19], allBlockCoordinates[20], allBlockCoordinates[21], allBlockCoordinates[22], allBlockCoordinates[23],
                allBlockCoordinates[24], allBlockCoordinates[25], allBlockCoordinates[26], allBlockCoordinates[27], allBlockCoordinates[28], allBlockCoordinates[29], allBlockCoordinates[30], allBlockCoordinates[31],
                allBlockCoordinates[32], allBlockCoordinates[33], allBlockCoordinates[34], allBlockCoordinates[35], allBlockCoordinates[36], allBlockCoordinates[37], allBlockCoordinates[38], allBlockCoordinates[39],
                allBlockCoordinates[40], allBlockCoordinates[41], allBlockCoordinates[42], allBlockCoordinates[43], allBlockCoordinates[44], allBlockCoordinates[45], allBlockCoordinates[46], allBlockCoordinates[47]
            };

            Assert.That(uvCoordinates, Is.EqualTo(expectedUvCoordinates));
        }

        [Test]
        public void TestThatUvCoordinatesHaveAllUvCoordinatesExceptCoveredBackFaceCoordinates()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();
            GrassyEarthBlock blockToRender = GrassyEarthBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetBackFaceOfBlockIsHidden(true);

            testCandidate.Build();

            float[] uvCoordinates = testCandidate.GetShapeUvCoordinates();
            float[] allBlockCoordinates = BlockUvCoordinates.FromBlockType(blockToRender.GetBlockType()).GetUvCoordinates();
            float[] expectedUvCoordinates = {
                allBlockCoordinates[0], allBlockCoordinates[1], allBlockCoordinates[2], allBlockCoordinates[3], allBlockCoordinates[4], allBlockCoordinates[5], allBlockCoordinates[6], allBlockCoordinates[7],
                allBlockCoordinates[8], allBlockCoordinates[9], allBlockCoordinates[10], allBlockCoordinates[11], allBlockCoordinates[12], allBlockCoordinates[13], allBlockCoordinates[14], allBlockCoordinates[15],
                allBlockCoordinates[24], allBlockCoordinates[25], allBlockCoordinates[26], allBlockCoordinates[27], allBlockCoordinates[28], allBlockCoordinates[29], allBlockCoordinates[30], allBlockCoordinates[31],
                allBlockCoordinates[32], allBlockCoordinates[33], allBlockCoordinates[34], allBlockCoordinates[35], allBlockCoordinates[36], allBlockCoordinates[37], allBlockCoordinates[38], allBlockCoordinates[39],
                allBlockCoordinates[40], allBlockCoordinates[41], allBlockCoordinates[42], allBlockCoordinates[43], allBlockCoordinates[44], allBlockCoordinates[45], allBlockCoordinates[46], allBlockCoordinates[47]
            };

            Assert.That(uvCoordinates, Is.EqualTo(expectedUvCoordinates));
        }   

        [Test]
        public void TestThatUvCoordinatesHaveAllUvCoordinatesExceptCoveredLeftFaceCoordinates()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();
            EarthBlock blockToRender = EarthBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetLeftFaceOfBlockIsHidden(true);

            testCandidate.Build();

            float[] uvCoordinates = testCandidate.GetShapeUvCoordinates();
            float[] allBlockCoordinates = BlockUvCoordinates.FromBlockType(blockToRender.GetBlockType()).GetUvCoordinates();
            float[] expectedUvCoordinates = {
                allBlockCoordinates[0], allBlockCoordinates[1], allBlockCoordinates[2], allBlockCoordinates[3], allBlockCoordinates[4], allBlockCoordinates[5], allBlockCoordinates[6], allBlockCoordinates[7],
                allBlockCoordinates[8], allBlockCoordinates[9], allBlockCoordinates[10], allBlockCoordinates[11], allBlockCoordinates[12], allBlockCoordinates[13], allBlockCoordinates[14], allBlockCoordinates[15],
                allBlockCoordinates[16], allBlockCoordinates[17], allBlockCoordinates[18], allBlockCoordinates[19], allBlockCoordinates[20], allBlockCoordinates[21], allBlockCoordinates[22], allBlockCoordinates[23],
                allBlockCoordinates[32], allBlockCoordinates[33], allBlockCoordinates[34], allBlockCoordinates[35], allBlockCoordinates[36], allBlockCoordinates[37], allBlockCoordinates[38], allBlockCoordinates[39],
                allBlockCoordinates[40], allBlockCoordinates[41], allBlockCoordinates[42], allBlockCoordinates[43], allBlockCoordinates[44], allBlockCoordinates[45], allBlockCoordinates[46], allBlockCoordinates[47]
            };

            Assert.That(uvCoordinates, Is.EqualTo(expectedUvCoordinates));
        } 

        [Test]
        public void TestThatUvCoordinatesHaveAllUvCoordinatesExceptCoveredBottomFaceCoordinates()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();
            EarthBlock blockToRender = EarthBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetBottomFaceOfBlockIsHidden(true);

            testCandidate.Build();

            float[] uvCoordinates = testCandidate.GetShapeUvCoordinates();
            float[] allBlockCoordinates = BlockUvCoordinates.FromBlockType(blockToRender.GetBlockType()).GetUvCoordinates();
            float[] expectedUvCoordinates = {
                allBlockCoordinates[0], allBlockCoordinates[1], allBlockCoordinates[2], allBlockCoordinates[3], allBlockCoordinates[4], allBlockCoordinates[5], allBlockCoordinates[6], allBlockCoordinates[7],
                allBlockCoordinates[8], allBlockCoordinates[9], allBlockCoordinates[10], allBlockCoordinates[11], allBlockCoordinates[12], allBlockCoordinates[13], allBlockCoordinates[14], allBlockCoordinates[15],
                allBlockCoordinates[16], allBlockCoordinates[17], allBlockCoordinates[18], allBlockCoordinates[19], allBlockCoordinates[20], allBlockCoordinates[21], allBlockCoordinates[22], allBlockCoordinates[23],
                allBlockCoordinates[24], allBlockCoordinates[25], allBlockCoordinates[26], allBlockCoordinates[27], allBlockCoordinates[28], allBlockCoordinates[29], allBlockCoordinates[30], allBlockCoordinates[31],
                allBlockCoordinates[40], allBlockCoordinates[41], allBlockCoordinates[42], allBlockCoordinates[43], allBlockCoordinates[44], allBlockCoordinates[45], allBlockCoordinates[46], allBlockCoordinates[47]
            };

            Assert.That(uvCoordinates, Is.EqualTo(expectedUvCoordinates));
        }     

        [Test]
        public void TestThatUvCoordinatesHaveAllUvCoordinatesExceptCoveredTopFaceCoordinates()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();
            RockBlock blockToRender = RockBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetTopFaceOfBlockIsHidden(true);

            testCandidate.Build();

            float[] uvCoordinates = testCandidate.GetShapeUvCoordinates();
            float[] allBlockCoordinates = BlockUvCoordinates.FromBlockType(blockToRender.GetBlockType()).GetUvCoordinates();
            float[] expectedUvCoordinates = {
                allBlockCoordinates[0], allBlockCoordinates[1], allBlockCoordinates[2], allBlockCoordinates[3], allBlockCoordinates[4], allBlockCoordinates[5], allBlockCoordinates[6], allBlockCoordinates[7],
                allBlockCoordinates[8], allBlockCoordinates[9], allBlockCoordinates[10], allBlockCoordinates[11], allBlockCoordinates[12], allBlockCoordinates[13], allBlockCoordinates[14], allBlockCoordinates[15],
                allBlockCoordinates[16], allBlockCoordinates[17], allBlockCoordinates[18], allBlockCoordinates[19], allBlockCoordinates[20], allBlockCoordinates[21], allBlockCoordinates[22], allBlockCoordinates[23],
                allBlockCoordinates[24], allBlockCoordinates[25], allBlockCoordinates[26], allBlockCoordinates[27], allBlockCoordinates[28], allBlockCoordinates[29], allBlockCoordinates[30], allBlockCoordinates[31],
                allBlockCoordinates[32], allBlockCoordinates[33], allBlockCoordinates[34], allBlockCoordinates[35], allBlockCoordinates[36], allBlockCoordinates[37], allBlockCoordinates[38], allBlockCoordinates[39],
            };

            Assert.That(uvCoordinates, Is.EqualTo(expectedUvCoordinates));
        }  

        [Test]
        public void TestNumberOfAddedVerticesIsCorrectForNoHiddenFace()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();
            GrassyEarthBlock blockToRender = GrassyEarthBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);

            testCandidate.Build();

            int numberOfAddedVertices = testCandidate.GetNumberOfAddedVertices();
            int expectedNumberOfAddedVertices = 4 * 6;

            Assert.That(numberOfAddedVertices, Is.EqualTo(expectedNumberOfAddedVertices));
        }  

        [Test]
        public void TestNumberOfAddedVerticesIsCorrectForOneHiddenFace()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();
            GrassyEarthBlock blockToRender = GrassyEarthBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetLeftFaceOfBlockIsHidden(true);

            testCandidate.Build();

            int numberOfAddedVertices = testCandidate.GetNumberOfAddedVertices();
            int expectedNumberOfAddedVertices = 4 * 5;

            Assert.That(numberOfAddedVertices, Is.EqualTo(expectedNumberOfAddedVertices));
        }  

        [Test]
        public void TestNumberOfAddedVerticesIsCorrectForTwoHiddenFace()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();
            EarthBlock blockToRender = EarthBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetRightFaceOfBlockIsHidden(true);
            testCandidate.SetTopFaceOfBlockIsHidden(true);

            testCandidate.Build();

            int numberOfAddedVertices = testCandidate.GetNumberOfAddedVertices();
            int expectedNumberOfAddedVertices = 4 * 4;

            Assert.That(numberOfAddedVertices, Is.EqualTo(expectedNumberOfAddedVertices));
        }                                                                                                   

        [Test]
        public void TestNumberOfAddedVerticesIsCorrectForThreeHiddenFace()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();
            EarthBlock blockToRender = EarthBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetBottomFaceOfBlockIsHidden(true);
            testCandidate.SetBackFaceOfBlockIsHidden(true);
            testCandidate.SetTopFaceOfBlockIsHidden(true);

            testCandidate.Build();

            int numberOfAddedVertices = testCandidate.GetNumberOfAddedVertices();
            int expectedNumberOfAddedVertices = 4 * 3;

            Assert.That(numberOfAddedVertices, Is.EqualTo(expectedNumberOfAddedVertices));
        }  

        [Test]
        public void TestNumberOfAddedVerticesIsCorrectForFourHiddenFace()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();
            RockBlock blockToRender = RockBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetBottomFaceOfBlockIsHidden(true);
            testCandidate.SetBackFaceOfBlockIsHidden(true);
            testCandidate.SetTopFaceOfBlockIsHidden(true);
            testCandidate.SetFrontFaceOfBlockIsHidden(true);

            testCandidate.Build();

            int numberOfAddedVertices = testCandidate.GetNumberOfAddedVertices();
            int expectedNumberOfAddedVertices = 4 * 2;

            Assert.That(numberOfAddedVertices, Is.EqualTo(expectedNumberOfAddedVertices));
        }   

        [Test]
        public void TestNumberOfAddedVerticesIsCorrectForFiveHiddenFace()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();
            RockBlock blockToRender = RockBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetBottomFaceOfBlockIsHidden(true);
            testCandidate.SetBackFaceOfBlockIsHidden(true);
            testCandidate.SetTopFaceOfBlockIsHidden(true);
            testCandidate.SetFrontFaceOfBlockIsHidden(true);
            testCandidate.SetRightFaceOfBlockIsHidden(true);

            testCandidate.Build();

            int numberOfAddedVertices = testCandidate.GetNumberOfAddedVertices();
            int expectedNumberOfAddedVertices = 4 * 1;

            Assert.That(numberOfAddedVertices, Is.EqualTo(expectedNumberOfAddedVertices));
        }          

        [Test]
        public void TestNumberOfAddedVerticesIsCorrectForAllHiddenFace()
        {
            StandardBlockVisualsBuilder testCandidate = new StandardBlockVisualsBuilder();
            EarthBlock blockToRender = EarthBlock.GetInstance();
            testCandidate.SetBlockToCreateDataFrom(blockToRender);
            testCandidate.SetBottomFaceOfBlockIsHidden(true);
            testCandidate.SetBackFaceOfBlockIsHidden(true);
            testCandidate.SetTopFaceOfBlockIsHidden(true);
            testCandidate.SetFrontFaceOfBlockIsHidden(true);
            testCandidate.SetRightFaceOfBlockIsHidden(true);
            testCandidate.SetLeftFaceOfBlockIsHidden(true);

            testCandidate.Build();

            int numberOfAddedVertices = testCandidate.GetNumberOfAddedVertices();
            int expectedNumberOfAddedVertices = 4 * 0;

            Assert.That(numberOfAddedVertices, Is.EqualTo(expectedNumberOfAddedVertices));
        }                 

        private float[] CalculateExpectedVertexPositionsBasedOnBlockPosition(BlockPosition blockPosition)
        {
            int x = blockPosition.X;
            int y = blockPosition.Y;
            int z = blockPosition.Z;

            float[] result = {
                x * 0.5f, y * 0.5f, z * 0.5f + 0.5f, x * 0.5f, y * 0.5f + 0.5f, z * 0.5f + 0.5f, x * 0.5f + 0.5f, y * 0.5f + 0.5f, z * 0.5f + 0.5f, x * 0.5f + 0.5f, y * 0.5f, z * 0.5f + 0.5f,
                x * 0.5f, y * 0.5f, z * 0.5f, x * 0.5f, y * 0.5f + 0.5f, z * 0.5f, x * 0.5f, y * 0.5f + 0.5f, z * 0.5f + 0.5f, x * 0.5f, y * 0.5f, z * 0.5f + 0.5f,
                x * 0.5f + 0.5f, y * 0.5f, z * 0.5f, x * 0.5f + 0.5f, y * 0.5f + 0.5f, z * 0.5f, x * 0.5f, y * 0.5f + 0.5f, z * 0.5f, x * 0.5f, y * 0.5f, z * 0.5f,
                x * 0.5f + 0.5f, y * 0.5f, z * 0.5f + 0.5f, x * 0.5f + 0.5f, y * 0.5f + 0.5f, z * 0.5f + 0.5f, x * 0.5f + 0.5f, y * 0.5f + 0.5f, z * 0.5f, x * 0.5f + 0.5f, y * 0.5f, z * 0.5f,
                x * 0.5f, y * 0.5f, z * 0.5f, x * 0.5f, y * 0.5f, z * 0.5f + 0.5f, x * 0.5f + 0.5f, y * 0.5f, z * 0.5f + 0.5f, x * 0.5f + 0.5f, y * 0.5f, z * 0.5f,
                x * 0.5f, y * 0.5f + 0.5f, z * 0.5f + 0.5f, x * 0.5f, y * 0.5f + 0.5f, z * 0.5f, x * 0.5f + 0.5f, y * 0.5f + 0.5f, z * 0.5f, x * 0.5f + 0.5f, y * 0.5f + 0.5f, z * 0.5f + 0.5f
            };  

            return result;          
        }

        private int[] CalculateExpectedIndicesBasedOnBlockNumberInChunk(int blockNumberInChunk)
        {
            int indexOffset = blockNumberInChunk * 24;

            int[] result = {
                blockNumberInChunk + 0, blockNumberInChunk + 3, blockNumberInChunk + 2, blockNumberInChunk + 2, blockNumberInChunk + 1, blockNumberInChunk + 0,
                blockNumberInChunk + 4, blockNumberInChunk + 7, blockNumberInChunk + 6, blockNumberInChunk + 6, blockNumberInChunk + 5, blockNumberInChunk + 4,
                blockNumberInChunk + 8, blockNumberInChunk + 11, blockNumberInChunk + 10, blockNumberInChunk + 10, blockNumberInChunk + 9, blockNumberInChunk + 8,
                blockNumberInChunk + 12, blockNumberInChunk + 15, blockNumberInChunk + 14, blockNumberInChunk + 14, blockNumberInChunk + 13, blockNumberInChunk + 12,
                blockNumberInChunk + 16, blockNumberInChunk + 19, blockNumberInChunk + 18, blockNumberInChunk + 18, blockNumberInChunk + 17, blockNumberInChunk + 16,
                blockNumberInChunk + 20, blockNumberInChunk + 23, blockNumberInChunk + 22, blockNumberInChunk + 22, blockNumberInChunk + 21, blockNumberInChunk + 20                
            };

            return result;
        }

        private float[] CalculateExpectedShapeNormals()
        {
            float[] result = {
                0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f,
                -1.0f, 0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f, 0.0f, 0.0f,
                0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f,
                1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f,
                0.0f, -1.0f, 0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f, 0.0f,
                0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 0.0f
            }; 

            return result;
        }
    }
}
