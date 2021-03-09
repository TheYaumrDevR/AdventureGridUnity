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
            FillVertexBuffer();
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

        private void FillVertexBuffer()
        {
            int amountOfUncoveredFaces = GetAmountOfUncoveredFaces();
            positionsBuffer = new float[4 * 3 * amountOfUncoveredFaces];
            int currentBufferPosition = 0;

            SetFrontFaceVertices(currentBufferPosition);
            currentBufferPosition += 12;

            SetRightFaceVertices(currentBufferPosition);
            currentBufferPosition += 12;

            SetBackFaceVertices(currentBufferPosition);
            currentBufferPosition += 12;

            SetLeftFaceVertices(currentBufferPosition);
            currentBufferPosition += 12;

            SetBottomFaceVertices(currentBufferPosition);
            currentBufferPosition += 12;

            SetTopFaceVertices(currentBufferPosition);
        }

        private void SetFrontFaceVertices(int currentBufferPosition) 
        {
            positionsBuffer[currentBufferPosition] = BV[0].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 1] = BV[0].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 2] = BV[0].GetBufferedResultZ();
        
            positionsBuffer[currentBufferPosition + 3] = BV[1].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 4] = BV[1].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 5] = BV[1].GetBufferedResultZ();
        
            positionsBuffer[currentBufferPosition + 6] = BV[2].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 7] = BV[2].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 8] = BV[2].GetBufferedResultZ();
        
            positionsBuffer[currentBufferPosition + 9] = BV[3].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 10] = BV[3].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 11] = BV[3].GetBufferedResultZ();              
        }

        private void SetRightFaceVertices(int currentBufferPosition)
        {
            positionsBuffer[currentBufferPosition] = BV[7].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 1] = BV[7].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 2] = BV[7].GetBufferedResultZ();
        
            positionsBuffer[currentBufferPosition + 3] = BV[6].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 4] = BV[6].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 5] = BV[6].GetBufferedResultZ();
        
            positionsBuffer[currentBufferPosition + 6] = BV[1].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 7] = BV[1].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 8] = BV[1].GetBufferedResultZ();
        
            positionsBuffer[currentBufferPosition + 9] = BV[0].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 10] = BV[0].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 11] = BV[0].GetBufferedResultZ();  
        }

        private void SetBackFaceVertices(int currentBufferPosition) 
        {
            positionsBuffer[currentBufferPosition] = BV[4].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 1] = BV[4].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 2] = BV[4].GetBufferedResultZ();
        
            positionsBuffer[currentBufferPosition + 3] = BV[5].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 4] = BV[5].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 5] = BV[5].GetBufferedResultZ();
        
            positionsBuffer[currentBufferPosition + 6] = BV[6].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 7] = BV[6].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 8] = BV[6].GetBufferedResultZ();
        
            positionsBuffer[currentBufferPosition + 9] = BV[7].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 10] = BV[7].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 11] = BV[7].GetBufferedResultZ();   
        }

        private void SetLeftFaceVertices(int currentBufferPosition)
        {
            positionsBuffer[currentBufferPosition] = BV[3].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 1] = BV[3].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 2] = BV[3].GetBufferedResultZ();
        
            positionsBuffer[currentBufferPosition + 3] = BV[2].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 4] = BV[2].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 5] = BV[2].GetBufferedResultZ();
        
            positionsBuffer[currentBufferPosition + 6] = BV[5].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 7] = BV[5].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 8] = BV[5].GetBufferedResultZ();
        
            positionsBuffer[currentBufferPosition + 9] = BV[4].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 10] = BV[4].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 11] = BV[4].GetBufferedResultZ();   
        }

        private void SetBottomFaceVertices(int currentBufferPosition)
        {
            positionsBuffer[currentBufferPosition] = BV[7].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 1] = BV[7].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 2] = BV[7].GetBufferedResultZ();
        
            positionsBuffer[currentBufferPosition + 3] = BV[0].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 4] = BV[0].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 5] = BV[0].GetBufferedResultZ();
        
            positionsBuffer[currentBufferPosition + 6] = BV[3].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 7] = BV[3].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 8] = BV[3].GetBufferedResultZ();
        
            positionsBuffer[currentBufferPosition + 9] = BV[4].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 10] = BV[4].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 11] = BV[4].GetBufferedResultZ();   
        }

        private void SetTopFaceVertices(int currentBufferPosition)
        {
            positionsBuffer[currentBufferPosition] = BV[1].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 1] = BV[1].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 2] = BV[1].GetBufferedResultZ();
        
            positionsBuffer[currentBufferPosition + 3] = BV[6].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 4] = BV[6].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 5] = BV[6].GetBufferedResultZ();
        
            positionsBuffer[currentBufferPosition + 6] = BV[5].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 7] = BV[5].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 8] = BV[5].GetBufferedResultZ();
        
            positionsBuffer[currentBufferPosition + 9] = BV[2].GetBufferedResultX();
            positionsBuffer[currentBufferPosition + 10] = BV[2].GetBufferedResultY();
            positionsBuffer[currentBufferPosition + 11] = BV[2].GetBufferedResultZ();      
        }

        private int GetAmountOfUncoveredFaces()
        {
            return 6;
        }
    }
}