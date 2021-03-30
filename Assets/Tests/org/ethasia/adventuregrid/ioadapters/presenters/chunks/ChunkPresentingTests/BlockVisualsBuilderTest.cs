using NUnit.Framework;

using Org.Ethasia.Adventuregrid.Core.Environment;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks.ChunkPresentingTests
{
    public class BlockVisualsBuilderTest
    {
        [Test]
        public void TestThatBlockVisualsBuilderBasedOnBlockTypeIsReturned()
        {
            BlockVisualsBuilder blockVisualsBuilder = BlockVisualsBuilder.FromBlockType(BlockTypes.EARTH);

            bool blockVisualsBuilderIsStandardBlockVisualsBuilder = blockVisualsBuilder is StandardBlockVisualsBuilder;

            Assert.That(blockVisualsBuilderIsStandardBlockVisualsBuilder, Is.EqualTo(true));
        }   
    }
}