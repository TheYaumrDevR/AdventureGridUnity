using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public abstract class BlockVisualsBuilder
    {
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