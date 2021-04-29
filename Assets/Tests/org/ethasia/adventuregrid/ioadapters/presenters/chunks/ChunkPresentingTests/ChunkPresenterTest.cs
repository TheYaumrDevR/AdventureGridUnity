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
        }
    }
}