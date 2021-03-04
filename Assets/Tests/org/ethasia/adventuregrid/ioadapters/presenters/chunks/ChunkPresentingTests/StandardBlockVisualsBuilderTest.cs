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
