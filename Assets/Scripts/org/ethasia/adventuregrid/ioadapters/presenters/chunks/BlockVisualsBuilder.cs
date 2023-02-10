﻿using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public abstract class BlockVisualsBuilder
    {
        public const float BLOCK_HALF_EDGE_LENGTH_IN_ENGINE_UNITS = 0.25f;

        private static StandardBlockVisualsBuilder standardBlockVisualsBuilder = new StandardBlockVisualsBuilder();
        private static PoleBlockVisualsBuilder poleBlockVisualsBuilder = new PoleBlockVisualsBuilder();

        public static BlockVisualsBuilder FromBlockType(BlockTypes blockType)
        {
            switch (blockType)
            {
                case BlockTypes.WALNUT_WOOD_POLE:
                    return poleBlockVisualsBuilder;
                default:
                    return standardBlockVisualsBuilder;
            }
        }

        public abstract BlockVisualsBuilder SetBlockToCreateDataFrom(Block value);
        public abstract BlockVisualsBuilder SetPositionOfBlockInChunk(BlockPosition value);
        public abstract BlockVisualsBuilder SetFrontFaceOfBlockIsHidden(bool value);
        public abstract BlockVisualsBuilder SetRightFaceOfBlockIsHidden(bool value);
        public abstract BlockVisualsBuilder SetBackFaceOfBlockIsHidden(bool value);
        public abstract BlockVisualsBuilder SetLeftFaceOfBlockIsHidden(bool value);
        public abstract BlockVisualsBuilder SetBottomFaceOfBlockIsHidden(bool value);
        public abstract BlockVisualsBuilder SetTopFaceOfBlockIsHidden(bool value);
        public abstract BlockVisualsBuilder SetIndexBufferOffsetInChunk(int value);

        public abstract void Build();
        public abstract float[] GetShapePositions();
        public abstract int[] GetShapeIndices();
        public abstract float[] GetShapeNormals();
        public abstract float[] GetShapeUvCoordinates();
        public abstract int GetNumberOfAddedVertices();
    }   
}