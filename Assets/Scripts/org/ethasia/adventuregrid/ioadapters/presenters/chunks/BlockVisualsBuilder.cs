using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public abstract class BlockVisualsBuilder
    {
        public const float BLOCK_HALF_EDGE_LENGTH_IN_ENGINE_UNITS = 0.25f;

        private static StandardBlockVisualsBuilder standardBlockVisualsBuilder = new StandardBlockVisualsBuilder();

        public static BlockVisualsBuilder FromBlockType(BlockTypes blockType)
        {
            return standardBlockVisualsBuilder;
        }

        public abstract StandardBlockVisualsBuilder SetBlockToCreateDataFrom(Block value);
        public abstract StandardBlockVisualsBuilder SetPositionOfBlockInChunk(BlockPosition value);
        public abstract StandardBlockVisualsBuilder SetFrontFaceOfBlockIsHidden(bool value);
        public abstract StandardBlockVisualsBuilder SetRightFaceOfBlockIsHidden(bool value);
        public abstract StandardBlockVisualsBuilder SetBackFaceOfBlockIsHidden(bool value);
        public abstract StandardBlockVisualsBuilder SetLeftFaceOfBlockIsHidden(bool value);
        public abstract StandardBlockVisualsBuilder SetBottomFaceOfBlockIsHidden(bool value);
        public abstract StandardBlockVisualsBuilder SetTopFaceOfBlockIsHidden(bool value);
        public abstract StandardBlockVisualsBuilder SetIndexBufferOffsetInChunk(int value);

        public abstract void Build();
        public abstract float[] GetShapePositions();
        public abstract int[] GetShapeIndices();
        public abstract float[] GetShapeNormals();
        public abstract float[] GetShapeUvCoordinates();
        public abstract int GetNumberOfAddedVertices();
    }   
}