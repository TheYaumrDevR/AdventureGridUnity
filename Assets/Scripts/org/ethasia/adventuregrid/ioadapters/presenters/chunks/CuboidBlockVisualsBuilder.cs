using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public abstract class CuboidBlockVisualsBuilder : BlockVisualsBuilder
    {
        private Block blockToRender;
        private BlockPosition blockPosition;
        private int indexBufferOffsetInChunk;

        protected bool frontFaceOfBlockIsHidden;
        protected bool rightFaceOfBlockIsHidden;
        protected bool backFaceOfBlockIsHidden;
        protected bool leftFaceOfBlockIsHidden;
        protected bool bottomFaceOfBlockIsHidden;
        protected bool topFaceOfBlockIsHidden;

        private float[] positionsBuffer;
        private int[] indexBuffer;
        private float[] normalsBuffer;
        private float[] uvBuffer;

        public abstract Vector3f[] GetBaseVertices();

        public override BlockVisualsBuilder SetBlockToCreateDataFrom(Block value)
        {
            blockToRender = value;
            return this;
        }

        public override BlockVisualsBuilder SetPositionOfBlockInChunk(BlockPosition value)
        {
            blockPosition = value;
            return this;
        }

        public override BlockVisualsBuilder SetFrontFaceOfBlockIsHidden(bool value)
        {
            frontFaceOfBlockIsHidden = value;
            return this;
        }

        public override BlockVisualsBuilder SetRightFaceOfBlockIsHidden(bool value)
        {
            rightFaceOfBlockIsHidden = value;
            return this;
        }

        public override BlockVisualsBuilder SetBackFaceOfBlockIsHidden(bool value)
        {
            backFaceOfBlockIsHidden = value;
            return this;
        }

        public override BlockVisualsBuilder SetLeftFaceOfBlockIsHidden(bool value)
        {
            leftFaceOfBlockIsHidden = value;
            return this;
        }

        public override BlockVisualsBuilder SetBottomFaceOfBlockIsHidden(bool value)
        {
            bottomFaceOfBlockIsHidden = value;
            return this;
        }

        public override BlockVisualsBuilder SetTopFaceOfBlockIsHidden(bool value)
        {
            topFaceOfBlockIsHidden = value;
            return this;
        }

        public override BlockVisualsBuilder SetIndexBufferOffsetInChunk(int value)
        {
            indexBufferOffsetInChunk = value;
            return this;
        }

        public override void Build() 
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
                BuildNormalsBuffer();
                BuildUvBuffer();
            }
        }

        public override float[] GetShapePositions() 
        {
            return positionsBuffer;
        }

        public override int[] GetShapeIndices() 
        {
            return indexBuffer;
        }

        public override float[] GetShapeNormals()
        {
            return normalsBuffer;
        }

        public override float[] GetShapeUvCoordinates()
        {
            return uvBuffer;
        }

        public override int GetNumberOfAddedVertices()
        {
            return GetAmountOfUncoveredFaces() * 4;
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

        private void BuildNormalsBuffer()
        {
            int amountOfUncoveredFaces = GetAmountOfUncoveredFaces();
            int vectorsPerFace = 4;

            normalsBuffer = new float[amountOfUncoveredFaces * vectorsPerFace * 3];

            FillNormalsBuffer();
        }

        protected virtual void FillNormalsBuffer()
        {
            int currentBufferIndex = 0;

            if (!frontFaceOfBlockIsHidden)
            {
                AddNormalForFaceWithGivenValuesStartingAtIndex(0.0f, 0.0f, 1.0f, currentBufferIndex); 
                currentBufferIndex += 12;
            }

            if (!rightFaceOfBlockIsHidden)
            {
                AddNormalForFaceWithGivenValuesStartingAtIndex(-1.0f, 0.0f, 0.0f, currentBufferIndex); 
                currentBufferIndex += 12;
            }

            if (!backFaceOfBlockIsHidden)
            {
                AddNormalForFaceWithGivenValuesStartingAtIndex(0.0f, 0.0f, -1.0f, currentBufferIndex); 
                currentBufferIndex += 12;  
            }     

            if (!leftFaceOfBlockIsHidden)
            {
                AddNormalForFaceWithGivenValuesStartingAtIndex(1.0f, 0.0f, 0.0f, currentBufferIndex); 
                currentBufferIndex += 12;   
            }    

            if (!bottomFaceOfBlockIsHidden)
            {
                AddNormalForFaceWithGivenValuesStartingAtIndex(0.0f, -1.0f, 0.0f, currentBufferIndex); 
                currentBufferIndex += 12;  
            }        

            if (!topFaceOfBlockIsHidden)
            {
                AddNormalForFaceWithGivenValuesStartingAtIndex(0.0f, 1.0f, 0.0f, currentBufferIndex); 
            }
        }

        private void TranslateVertices()
        {
            Position3 cubeCenter = new Position3(0.25f + 0.5f * blockPosition.X,
                0.25f + 0.5f * blockPosition.Y,
                0.25f + 0.5f * blockPosition.Z);

            Vector3f[] BV = GetBaseVertices();

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
            Vector3f[] BV = GetBaseVertices();

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
            Vector3f[] BV = GetBaseVertices();

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
            Vector3f[] BV = GetBaseVertices();

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
            Vector3f[] BV = GetBaseVertices();

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
            Vector3f[] BV = GetBaseVertices();

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
            Vector3f[] BV = GetBaseVertices();

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
            indexBuffer[currentBufferIndex + 1] = 3 + faceOffset + indexBufferOffsetInChunk;
            indexBuffer[currentBufferIndex + 2] = 2 + faceOffset + indexBufferOffsetInChunk;
            indexBuffer[currentBufferIndex + 3] = 2 + faceOffset + indexBufferOffsetInChunk;
            indexBuffer[currentBufferIndex + 4] = 1 + faceOffset + indexBufferOffsetInChunk;
            indexBuffer[currentBufferIndex + 5] = 0 + faceOffset + indexBufferOffsetInChunk;  
        }

        protected void AddNormalForFaceWithGivenValuesStartingAtIndex(float normalX, float normalY, float normalZ, int startIndex)
        {
            normalsBuffer[startIndex] = normalX;
            normalsBuffer[startIndex + 1] = normalY;
            normalsBuffer[startIndex + 2] = normalZ;
            normalsBuffer[startIndex + 3] = normalX;
            normalsBuffer[startIndex + 4] = normalY;
            normalsBuffer[startIndex + 5] = normalZ;
            normalsBuffer[startIndex + 6] = normalX;
            normalsBuffer[startIndex + 7] = normalY;
            normalsBuffer[startIndex + 8] = normalZ;
            normalsBuffer[startIndex + 9] = normalX;
            normalsBuffer[startIndex + 10] = normalY;
            normalsBuffer[startIndex + 11] = normalZ;    
        }

        private void BuildUvBuffer()
        {
            int faces = GetAmountOfUncoveredFaces();
            int uvPerFace = 4;
            int amountOfUvFloatsPerFace = 3 * uvPerFace;
            float[] blockUvCoordinates = BlockUvCoordinates.FromBlockType(blockToRender.GetBlockType()).GetUvCoordinates();

            if (6 == faces) 
            {
                uvBuffer = blockUvCoordinates;
            }
            else
            {
                uvBuffer = new float[faces * amountOfUvFloatsPerFace];
                int currentTargetBufferIndex = 0;
                int currentSourceBufferIndex = 0;

                if (!frontFaceOfBlockIsHidden) 
                {
                    CopyUvCoordinatesFromSourceBufferToUvBuffer(currentTargetBufferIndex, blockUvCoordinates, currentSourceBufferIndex);
                
                    currentTargetBufferIndex += amountOfUvFloatsPerFace;
                }

                if (!rightFaceOfBlockIsHidden) 
                {
                    currentSourceBufferIndex = amountOfUvFloatsPerFace * 1;
                    CopyUvCoordinatesFromSourceBufferToUvBuffer(currentTargetBufferIndex, blockUvCoordinates, currentSourceBufferIndex);
                
                    currentTargetBufferIndex += amountOfUvFloatsPerFace;
                }

                if (!backFaceOfBlockIsHidden) 
                {
                    currentSourceBufferIndex = amountOfUvFloatsPerFace * 2;
                    CopyUvCoordinatesFromSourceBufferToUvBuffer(currentTargetBufferIndex, blockUvCoordinates, currentSourceBufferIndex);
                
                    currentTargetBufferIndex += amountOfUvFloatsPerFace;
                }

                if (!leftFaceOfBlockIsHidden) 
                {
                    currentSourceBufferIndex = amountOfUvFloatsPerFace * 3;
                    CopyUvCoordinatesFromSourceBufferToUvBuffer(currentTargetBufferIndex, blockUvCoordinates, currentSourceBufferIndex);
                
                    currentTargetBufferIndex += amountOfUvFloatsPerFace;   
                }  

                if (!bottomFaceOfBlockIsHidden) 
                {
                    currentSourceBufferIndex = amountOfUvFloatsPerFace * 4;
                    CopyUvCoordinatesFromSourceBufferToUvBuffer(currentTargetBufferIndex, blockUvCoordinates, currentSourceBufferIndex);
                
                    currentTargetBufferIndex += amountOfUvFloatsPerFace;
                }

                if (!topFaceOfBlockIsHidden) 
                {
                    currentSourceBufferIndex = amountOfUvFloatsPerFace * 5;
                    CopyUvCoordinatesFromSourceBufferToUvBuffer(currentTargetBufferIndex, blockUvCoordinates, currentSourceBufferIndex);   
                }                                                        
            }
        }

        private void CopyUvCoordinatesFromSourceBufferToUvBuffer(int destintationBufferStartingIndex, float[] sourceBuffer, int sourceDataStartingIndex) 
        {
            uvBuffer[destintationBufferStartingIndex] = sourceBuffer[sourceDataStartingIndex];
            uvBuffer[destintationBufferStartingIndex + 1] = sourceBuffer[sourceDataStartingIndex + 1];
            uvBuffer[destintationBufferStartingIndex + 2] = sourceBuffer[sourceDataStartingIndex + 2];
            uvBuffer[destintationBufferStartingIndex + 3] = sourceBuffer[sourceDataStartingIndex + 3];
            uvBuffer[destintationBufferStartingIndex + 4] = sourceBuffer[sourceDataStartingIndex + 4];
            uvBuffer[destintationBufferStartingIndex + 5] = sourceBuffer[sourceDataStartingIndex + 5];
            uvBuffer[destintationBufferStartingIndex + 6] = sourceBuffer[sourceDataStartingIndex + 6];
            uvBuffer[destintationBufferStartingIndex + 7] = sourceBuffer[sourceDataStartingIndex + 7];    
            uvBuffer[destintationBufferStartingIndex + 8] = sourceBuffer[sourceDataStartingIndex + 8]; 
            uvBuffer[destintationBufferStartingIndex + 9] = sourceBuffer[sourceDataStartingIndex + 9]; 
            uvBuffer[destintationBufferStartingIndex + 10] = sourceBuffer[sourceDataStartingIndex + 10]; 
            uvBuffer[destintationBufferStartingIndex + 11] = sourceBuffer[sourceDataStartingIndex + 11];     
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