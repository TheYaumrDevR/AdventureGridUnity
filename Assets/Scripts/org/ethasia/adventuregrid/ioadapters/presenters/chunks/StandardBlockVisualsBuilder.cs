﻿using Org.Ethasia.Adventuregrid.Core.Environment;
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
        private int indexBufferOffsetInChunk;

        private bool frontFaceOfBlockIsHidden;
        private bool rightFaceOfBlockIsHidden;
        private bool backFaceOfBlockIsHidden;
        private bool leftFaceOfBlockIsHidden;
        private bool bottomFaceOfBlockIsHidden;
        private bool topFaceOfBlockIsHidden;

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

        public StandardBlockVisualsBuilder SetFrontFaceOfBlockIsHidden(bool value)
        {
            frontFaceOfBlockIsHidden = value;
            return this;
        }

        public StandardBlockVisualsBuilder SetRightFaceOfBlockIsHidden(bool value)
        {
            rightFaceOfBlockIsHidden = value;
            return this;
        }

        public StandardBlockVisualsBuilder SetBackFaceOfBlockIsHidden(bool value)
        {
            backFaceOfBlockIsHidden = value;
            return this;
        }

        public StandardBlockVisualsBuilder SetLeftFaceOfBlockIsHidden(bool value)
        {
            leftFaceOfBlockIsHidden = value;
            return this;
        }

        public StandardBlockVisualsBuilder SetBottomFaceOfBlockIsHidden(bool value)
        {
            bottomFaceOfBlockIsHidden = value;
            return this;
        }

        public StandardBlockVisualsBuilder SetTopFaceOfBlockIsHidden(bool value)
        {
            topFaceOfBlockIsHidden = value;
            return this;
        }

        public StandardBlockVisualsBuilder SetIndexBufferOffsetInChunk(int value)
        {
            indexBufferOffsetInChunk = value;
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
                BuildIndicesBuffer();
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
            FillPositionsBuffer();
        }

        private void BuildIndicesBuffer()
        {
            int amountOfUncoveredFaces = GetAmountOfUncoveredFaces();
            indexBuffer = new int[amountOfUncoveredFaces * 6];

            int faceOffset = 0;
            int currentBufferIndex = 0;

            if (!frontFaceOfBlockIsHidden)
            {
                AddNextFaceIndicesToBuffer(currentBufferIndex, faceOffset);
                currentBufferIndex += 6;
                faceOffset += 4;
            }

            if (!rightFaceOfBlockIsHidden)
            {
                AddNextFaceIndicesToBuffer(currentBufferIndex, faceOffset);
                currentBufferIndex += 6;
                faceOffset += 4;
            }

            if (!backFaceOfBlockIsHidden)
            {
                AddNextFaceIndicesToBuffer(currentBufferIndex, faceOffset);
                currentBufferIndex += 6;
                faceOffset += 4;
            }

            if (!leftFaceOfBlockIsHidden)
            {
                AddNextFaceIndicesToBuffer(currentBufferIndex, faceOffset);
                currentBufferIndex += 6;
                faceOffset += 4;
            }

            if (!bottomFaceOfBlockIsHidden)
            {
                AddNextFaceIndicesToBuffer(currentBufferIndex, faceOffset);
                currentBufferIndex += 6;
                faceOffset += 4;
            }

            if (!topFaceOfBlockIsHidden)
            {
                AddNextFaceIndicesToBuffer(currentBufferIndex, faceOffset);
                currentBufferIndex += 6;
                faceOffset += 4;
            }
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

        private void FillPositionsBuffer()
        {
            int amountOfUncoveredFaces = GetAmountOfUncoveredFaces();
            positionsBuffer = new float[4 * 3 * amountOfUncoveredFaces];
            int currentBufferPosition = 0;

            if (!frontFaceOfBlockIsHidden)
            {
                SetFrontFaceVertices(currentBufferPosition);
                currentBufferPosition += 12;
            }

            if (!rightFaceOfBlockIsHidden) 
            {
                SetRightFaceVertices(currentBufferPosition);
                currentBufferPosition += 12;
            }

            if (!backFaceOfBlockIsHidden) 
            {
                SetBackFaceVertices(currentBufferPosition);
                currentBufferPosition += 12;
            }

            if (!leftFaceOfBlockIsHidden)
            {
                SetLeftFaceVertices(currentBufferPosition);
                currentBufferPosition += 12;
            }

            if (!bottomFaceOfBlockIsHidden)
            {
                SetBottomFaceVertices(currentBufferPosition);
                currentBufferPosition += 12;
            }

            if (!topFaceOfBlockIsHidden)
            {
                SetTopFaceVertices(currentBufferPosition);
            }
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

        private void AddNextFaceIndicesToBuffer(int currentBufferIndex, int faceOffset)
        {
            indexBuffer[currentBufferIndex] = 0 + faceOffset + indexBufferOffsetInChunk;
            indexBuffer[currentBufferIndex + 1] = 1 + faceOffset + indexBufferOffsetInChunk;
            indexBuffer[currentBufferIndex + 2] = 2 + faceOffset + indexBufferOffsetInChunk;
            indexBuffer[currentBufferIndex + 3] = 2 + faceOffset + indexBufferOffsetInChunk;
            indexBuffer[currentBufferIndex + 4] = 3 + faceOffset + indexBufferOffsetInChunk;
            indexBuffer[currentBufferIndex + 5] = 0 + faceOffset + indexBufferOffsetInChunk;  
        }

        private int GetAmountOfUncoveredFaces()
        {
            int result = 0;

            if (!frontFaceOfBlockIsHidden) 
            {
                result++;
            }

            if (!rightFaceOfBlockIsHidden)
            {
                result++;
            }

            if (!backFaceOfBlockIsHidden)
            {
                result++;
            }

            if (!leftFaceOfBlockIsHidden)
            {
                result++;
            }

            if (!bottomFaceOfBlockIsHidden)
            {
                result++;
            }
            
            if (!topFaceOfBlockIsHidden)
            {
                result++;
            }

            return result;
        }
    }
}