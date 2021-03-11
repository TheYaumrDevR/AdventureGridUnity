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
    }
}
