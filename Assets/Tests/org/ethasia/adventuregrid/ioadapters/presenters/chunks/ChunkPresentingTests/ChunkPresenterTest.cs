using NUnit.Framework;

using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks.ChunkPresentingTests
{
    public class ChunkPresenterTest
    {
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
        }
    }
}