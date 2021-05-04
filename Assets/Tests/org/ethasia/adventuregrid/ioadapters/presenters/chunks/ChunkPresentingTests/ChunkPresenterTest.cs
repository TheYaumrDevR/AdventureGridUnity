using NUnit.Framework;

using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks.ChunkPresentingTests.Mocks;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks.ChunkPresentingTests
{
    [TestFixture]
    public class ChunkPresenterTest
    {

        [OneTimeSetUp]
        public void InitDependencies()
        {
            TechnicalsFactory.SetInstance(new TechnicalsMockFactory());
        }

        [SetUp]
        public void ResetMocks()
        {
            ChunkRendererMock.ResetMock();
        }

        [Test]
        public void TestThatRenderingBlocksInZeroZeroChunkIsDoneProperly()
        {
            Island islandToRender = new Island(16);

            islandToRender.PlaceBlockAt(GrassyEarthBlock.GetInstance(), new BlockPosition(2, 2, 2));
            islandToRender.PlaceBlockAt(GrassyEarthBlock.GetInstance(), new BlockPosition(3, 2, 2));
            islandToRender.PlaceBlockAt(GrassyEarthBlock.GetInstance(), new BlockPosition(2, 2, 3));
            islandToRender.PlaceBlockAt(GrassyEarthBlock.GetInstance(), new BlockPosition(3, 2, 3));
            islandToRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(2, 1, 2));
            islandToRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(3, 1, 2));
            islandToRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(2, 1, 3));
            islandToRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(3, 1, 3));

            ChunkPresenter testCandidate = new ChunkPresenter();

            testCandidate.PresentChunk(islandToRender, 0, 0);

            VisualChunkData lastRenderedChunkData = ChunkRendererMock.GetLastRenderChunkCallData();

            Assert.That(lastRenderedChunkData, Is.Not.Null);
            Assert.That(lastRenderedChunkData.GetWorldX(), Is.EqualTo(0));
            Assert.That(lastRenderedChunkData.GetWorldY(), Is.EqualTo(0));
            Assert.That(lastRenderedChunkData.GetVertices().Length, Is.EqualTo(288));
            Assert.That(lastRenderedChunkData.GetIndices().Length, Is.EqualTo(144));
            Assert.That(lastRenderedChunkData.GetNormals().Length, Is.EqualTo(288));
            Assert.That(lastRenderedChunkData.GetUvCoordinates().Length, Is.EqualTo(192));
        }

        [Test]
        public void TestThatRenderingBlocksInOnePointOneChunkIsDoneProperly()
        {
            Island islandToRender = new Island(31);

            islandToRender.PlaceBlockAt(GrassyEarthBlock.GetInstance(), new BlockPosition(18, 2, 18));
            islandToRender.PlaceBlockAt(GrassyEarthBlock.GetInstance(), new BlockPosition(19, 2, 18));
            islandToRender.PlaceBlockAt(GrassyEarthBlock.GetInstance(), new BlockPosition(18, 2, 19));
            islandToRender.PlaceBlockAt(GrassyEarthBlock.GetInstance(), new BlockPosition(19, 2, 19));
            islandToRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(18, 1, 18));
            islandToRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(19, 1, 18));
            islandToRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(18, 1, 19));
            islandToRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(19, 1, 19));

            ChunkPresenter testCandidate = new ChunkPresenter();

            testCandidate.PresentChunk(islandToRender, 1, 1);

            VisualChunkData lastRenderedChunkData = ChunkRendererMock.GetLastRenderChunkCallData();

            Assert.That(lastRenderedChunkData, Is.Not.Null);
            Assert.That(lastRenderedChunkData.GetWorldX(), Is.EqualTo(1));
            Assert.That(lastRenderedChunkData.GetWorldY(), Is.EqualTo(1));
            Assert.That(lastRenderedChunkData.GetVertices().Length, Is.EqualTo(288));
            Assert.That(lastRenderedChunkData.GetIndices().Length, Is.EqualTo(144));
            Assert.That(lastRenderedChunkData.GetNormals().Length, Is.EqualTo(288));
            Assert.That(lastRenderedChunkData.GetUvCoordinates().Length, Is.EqualTo(192));            
        }

        [Test]
        public void TestThatCoveredMiddleBlockIsNotRendered() {
            Island islandToRender = new Island(46);  
        
            islandToRender.PlaceBlockAt(GrassyEarthBlock.GetInstance(), new BlockPosition(34, 3, 18));
            islandToRender.PlaceBlockAt(GrassyEarthBlock.GetInstance(), new BlockPosition(35, 3, 18));
            islandToRender.PlaceBlockAt(GrassyEarthBlock.GetInstance(), new BlockPosition(36, 3, 18));
            islandToRender.PlaceBlockAt(GrassyEarthBlock.GetInstance(), new BlockPosition(34, 3, 19));
            islandToRender.PlaceBlockAt(GrassyEarthBlock.GetInstance(), new BlockPosition(35, 3, 19));
            islandToRender.PlaceBlockAt(GrassyEarthBlock.GetInstance(), new BlockPosition(36, 3, 19)); 
            islandToRender.PlaceBlockAt(GrassyEarthBlock.GetInstance(), new BlockPosition(34, 3, 20));
            islandToRender.PlaceBlockAt(GrassyEarthBlock.GetInstance(), new BlockPosition(35, 3, 20));
            islandToRender.PlaceBlockAt(GrassyEarthBlock.GetInstance(), new BlockPosition(36, 3, 20)); 
        
            islandToRender.PlaceBlockAt(EarthBlock.GetInstance(), new BlockPosition(34, 2, 18));
            islandToRender.PlaceBlockAt(EarthBlock.GetInstance(), new BlockPosition(35, 2, 18));
            islandToRender.PlaceBlockAt(EarthBlock.GetInstance(), new BlockPosition(36, 2, 18));
            islandToRender.PlaceBlockAt(EarthBlock.GetInstance(), new BlockPosition(34, 2, 19));
            islandToRender.PlaceBlockAt(EarthBlock.GetInstance(), new BlockPosition(35, 2, 19));
            islandToRender.PlaceBlockAt(EarthBlock.GetInstance(), new BlockPosition(36, 2, 19)); 
            islandToRender.PlaceBlockAt(EarthBlock.GetInstance(), new BlockPosition(34, 2, 20));
            islandToRender.PlaceBlockAt(EarthBlock.GetInstance(), new BlockPosition(35, 2, 20));
            islandToRender.PlaceBlockAt(EarthBlock.GetInstance(), new BlockPosition(36, 2, 20));          

            islandToRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(34, 1, 18));
            islandToRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(35, 1, 18));
            islandToRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(36, 1, 18));
            islandToRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(34, 1, 19));
            islandToRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(35, 1, 19));
            islandToRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(36, 1, 19)); 
            islandToRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(34, 1, 20));
            islandToRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(35, 1, 20));
            islandToRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(36, 1, 20)); 
        
            ChunkPresenter testCandidate = new ChunkPresenter();
        
            testCandidate.PresentChunk(islandToRender, 2, 1);
        
            VisualChunkData lastRenderedChunkData = ChunkRendererMock.GetLastRenderChunkCallData();     
        
            Assert.That(lastRenderedChunkData, Is.Not.Null);
            Assert.That(lastRenderedChunkData.GetWorldX(), Is.EqualTo(2));
            Assert.That(lastRenderedChunkData.GetWorldY(), Is.EqualTo(1));
            Assert.That(lastRenderedChunkData.GetVertices().Length, Is.EqualTo(648));
            Assert.That(lastRenderedChunkData.GetIndices().Length, Is.EqualTo(324));
            Assert.That(lastRenderedChunkData.GetNormals().Length, Is.EqualTo(648));
            Assert.That(lastRenderedChunkData.GetUvCoordinates().Length, Is.EqualTo(432));
        }         
    }
}