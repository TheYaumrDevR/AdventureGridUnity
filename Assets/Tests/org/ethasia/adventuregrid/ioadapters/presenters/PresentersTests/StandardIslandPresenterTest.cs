using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Mocks;

using NUnit.Framework;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.PresentersTests
{
    public class StandardIslandPresenterTest
    {

        [SetUp]
        public void InitDependencies()
        {
            TechnicalsFactory.SetInstance(new TechnicalsMockFactory());
        }

        [Test]
        public void TestThatIslandIsPresentedInChunks()
        {
            Island toRender = new Island(64);
            toRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(15, 0, 15));
            toRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(16, 0, 15));
            toRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(15, 0, 16));
            toRender.PlaceBlockAt(RockBlock.GetInstance(), new BlockPosition(16, 0, 16));

            StandardIslandPresenter testCandidate = new StandardIslandPresenter();
            testCandidate.PresentIsland(toRender);

            VisualChunkData lastRenderedChunkData = ChunkRendererMock.GetLastRenderChunkCallData();

            Assert.That(lastRenderedChunkData.GetWorldX(), Is.EqualTo(1));
        }
    }
}
