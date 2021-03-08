using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public class StandardBlockVisualsBuilder
    {

        // Base vertices
        private static readonly Vector3[] BV;

        static StandardBlockVisualsBuilder()
        {
            Vector3[] blockHalfAxes = {
                Vector3.UNIT_X.ScaleImmutable(0.25f),
                Vector3.UNIT_Y.ScaleImmutable(0.25f),
                Vector3.UNIT_Z.ScaleImmutable(0.25f)
            };

            Vector3 origin = new Vector3(0, 0, 0);

            BV = new Vector3[] {
                origin.AddImmutable(blockHalfAxes[0]).Subtract(blockHalfAxes[1]).Add(blockHalfAxes[2]),
                origin.AddImmutable(blockHalfAxes[0]).Add(blockHalfAxes[1]).Add(blockHalfAxes[2]),
                origin.SubtractImmutable(blockHalfAxes[0]).Add(blockHalfAxes[1]).Add(blockHalfAxes[2]),
                origin.SubtractImmutable(blockHalfAxes[0]).Subtract(blockHalfAxes[1]).Add(blockHalfAxes[2]),
                origin.SubtractImmutable(blockHalfAxes[0]).Subtract(blockHalfAxes[1]).Subtract(blockHalfAxes[2]),
                origin.SubtractImmutable(blockHalfAxes[0]).Add(blockHalfAxes[1]).Subtract(blockHalfAxes[2]),
                origin.AddImmutable(blockHalfAxes[0]).Add(blockHalfAxes[1]).Subtract(blockHalfAxes[2]),
                origin.AddImmutable(blockHalfAxes[0]).Subtract(blockHalfAxes[1]).Subtract(blockHalfAxes[2])
            };
        }

        private Block blockToRender;
        private BlockPosition blockPosition;

        private float[] positionsBuffer;
        private int[] indexBuffer;
        private float[] normalsBuffer;
        private float[] uvBuffer;

        public StandardBlockVisualsBuilder SetBlockToCreateDataFrom(Block value)
        {
            blockToRender = value;
            return this;
        }

        public StandardBlockVisualsBuilder SetPositionOfBlockInChunk(BlockPosition value)
        {
            blockPosition = value;
            return this;
        }

        public void Build() 
        {
            if (null == blockToRender)
            {
                positionsBuffer = new float[0];
                indexBuffer = new int[0];
                normalsBuffer = new float[0];
                uvBuffer = new float[0];
            }
            else
            {
                BuildPositionsBuffer();
            }
        }

        public float[] GetShapePositions() 
        {
            return positionsBuffer;
        }

        public int[] GetShapeIndices() 
        {
            return indexBuffer;
        }

        public float[] GetShapeNormals()
        {
            return normalsBuffer;
        }

        public float[] GetShapeUvCoordinates()
        {
            return uvBuffer;
        }

        private void BuildPositionsBuffer()
        {
            TranslateVertices();
        }

        private void TranslateVertices()
        {
            Position3 cubeCenter = new Position3(0.25f + 0.5f * blockPosition.X,
                0.25f + 0.5f * blockPosition.Y,
                0.25f + 0.5f * blockPosition.Z);

            BV[0].AddImmutableBufferResult(cubeCenter);
            BV[1].AddImmutableBufferResult(cubeCenter);
            BV[2].AddImmutableBufferResult(cubeCenter);
            BV[3].AddImmutableBufferResult(cubeCenter);
            BV[4].AddImmutableBufferResult(cubeCenter);
            BV[5].AddImmutableBufferResult(cubeCenter);
            BV[6].AddImmutableBufferResult(cubeCenter);
            BV[7].AddImmutableBufferResult(cubeCenter);
        }
    }
}