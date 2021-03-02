using NUnit.Framework;

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
    }
}
