using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public class AttachmentPoleBlockVisualsBuilder : BlockVisualsBuilder
    {
        // Base vertices
        private static readonly Vector3f[] BV;
        private static readonly Vector3f[] BVLeftAttachment;
        private static readonly Vector3f[] BVFrontAttachment;
        private static readonly Vector3f[] BVRightAttachment;
        private static readonly Vector3f[] BVBackAttachment;

        static AttachmentPoleBlockVisualsBuilder()
        {
            Vector3f[] blockHalfAxes = {
                Vector3f.UNIT_X.ScaleImmutable(0.075f),
                Vector3f.UNIT_Y.ScaleImmutable(BLOCK_HALF_EDGE_LENGTH_IN_ENGINE_UNITS),
                Vector3f.UNIT_Z.ScaleImmutable(0.075f)
            };

            Vector3f[] blockFrontBackAttachmentHalfAxes = {
                Vector3f.UNIT_X.ScaleImmutable(0.025f),
                Vector3f.UNIT_Y.ScaleImmutable(0.15f),
                Vector3f.UNIT_Z.ScaleImmutable(BLOCK_HALF_EDGE_LENGTH_IN_ENGINE_UNITS)
            };          

            Vector3f[] blockLeftRightAttachmentHalfAxes = {
                Vector3f.UNIT_X.ScaleImmutable(BLOCK_HALF_EDGE_LENGTH_IN_ENGINE_UNITS),
                Vector3f.UNIT_Y.ScaleImmutable(0.15f),
                Vector3f.UNIT_Z.ScaleImmutable(0.025f)
            };   

            Vector3f origin = new Vector3f(0, 0, 0);

            BV = new Vector3f[] {
                origin.SubtractImmutable(blockHalfAxes[0]).Subtract(blockHalfAxes[1]).Add(blockHalfAxes[2]),
                origin.SubtractImmutable(blockHalfAxes[0]).Add(blockHalfAxes[1]).Add(blockHalfAxes[2]),
                origin.AddImmutable(blockHalfAxes[0]).Add(blockHalfAxes[1]).Add(blockHalfAxes[2]),
                origin.AddImmutable(blockHalfAxes[0]).Subtract(blockHalfAxes[1]).Add(blockHalfAxes[2]),
                origin.AddImmutable(blockHalfAxes[0]).Subtract(blockHalfAxes[1]).Subtract(blockHalfAxes[2]),
                origin.AddImmutable(blockHalfAxes[0]).Add(blockHalfAxes[1]).Subtract(blockHalfAxes[2]),
                origin.SubtractImmutable(blockHalfAxes[0]).Add(blockHalfAxes[1]).Subtract(blockHalfAxes[2]),
                origin.SubtractImmutable(blockHalfAxes[0]).Subtract(blockHalfAxes[1]).Subtract(blockHalfAxes[2])
            };

            BVLeftAttachment = new Vector3f[] {
                origin.AddImmutable(blockHalfAxes[0]).Subtract(blockLeftRightAttachmentHalfAxes[1]).Add(blockLeftRightAttachmentHalfAxes[2]),
                origin.AddImmutable(blockHalfAxes[0]).Add(blockLeftRightAttachmentHalfAxes[1]).Add(blockLeftRightAttachmentHalfAxes[2]),
                origin.AddImmutable(blockLeftRightAttachmentHalfAxes[0]).Add(blockLeftRightAttachmentHalfAxes[1]).Add(blockLeftRightAttachmentHalfAxes[2]),
                origin.AddImmutable(blockLeftRightAttachmentHalfAxes[0]).Subtract(blockLeftRightAttachmentHalfAxes[1]).Add(blockLeftRightAttachmentHalfAxes[2]),  
                origin.AddImmutable(blockLeftRightAttachmentHalfAxes[0]).Subtract(blockLeftRightAttachmentHalfAxes[1]).Subtract(blockLeftRightAttachmentHalfAxes[2]),
                origin.AddImmutable(blockLeftRightAttachmentHalfAxes[0]).Add(blockLeftRightAttachmentHalfAxes[1]).Subtract(blockLeftRightAttachmentHalfAxes[2]),
                origin.AddImmutable(blockHalfAxes[0]).Add(blockLeftRightAttachmentHalfAxes[1]).Subtract(blockLeftRightAttachmentHalfAxes[2]),
                origin.AddImmutable(blockHalfAxes[0]).Subtract(blockLeftRightAttachmentHalfAxes[1]).Subtract(blockLeftRightAttachmentHalfAxes[2])                              
            };            

            BVFrontAttachment = new Vector3f[] {
                origin.SubtractImmutable(blockFrontBackAttachmentHalfAxes[0]).Subtract(blockFrontBackAttachmentHalfAxes[1]).Add(blockFrontBackAttachmentHalfAxes[2]),
                origin.SubtractImmutable(blockFrontBackAttachmentHalfAxes[0]).Add(blockFrontBackAttachmentHalfAxes[1]).Add(blockFrontBackAttachmentHalfAxes[2]),
                origin.AddImmutable(blockFrontBackAttachmentHalfAxes[0]).Add(blockFrontBackAttachmentHalfAxes[1]).Add(blockFrontBackAttachmentHalfAxes[2]),
                origin.AddImmutable(blockFrontBackAttachmentHalfAxes[0]).Subtract(blockFrontBackAttachmentHalfAxes[1]).Add(blockFrontBackAttachmentHalfAxes[2]),  
                origin.AddImmutable(blockFrontBackAttachmentHalfAxes[0]).Subtract(blockFrontBackAttachmentHalfAxes[1]).Add(blockHalfAxes[2]),
                origin.AddImmutable(blockFrontBackAttachmentHalfAxes[0]).Add(blockFrontBackAttachmentHalfAxes[1]).Add(blockHalfAxes[2]),
                origin.SubtractImmutable(blockFrontBackAttachmentHalfAxes[0]).Add(blockFrontBackAttachmentHalfAxes[1]).Add(blockHalfAxes[2]),
                origin.SubtractImmutable(blockFrontBackAttachmentHalfAxes[0]).Subtract(blockFrontBackAttachmentHalfAxes[1]).Add(blockHalfAxes[2])                              
            };

            BVRightAttachment = new Vector3f[] {
                origin.SubtractImmutable(blockLeftRightAttachmentHalfAxes[0]).Subtract(blockLeftRightAttachmentHalfAxes[1]).Add(blockLeftRightAttachmentHalfAxes[2]),
                origin.SubtractImmutable(blockLeftRightAttachmentHalfAxes[0]).Add(blockLeftRightAttachmentHalfAxes[1]).Add(blockLeftRightAttachmentHalfAxes[2]),
                origin.SubtractImmutable(blockHalfAxes[0]).Add(blockLeftRightAttachmentHalfAxes[1]).Add(blockLeftRightAttachmentHalfAxes[2]),
                origin.SubtractImmutable(blockHalfAxes[0]).Subtract(blockLeftRightAttachmentHalfAxes[1]).Add(blockLeftRightAttachmentHalfAxes[2]),  
                origin.SubtractImmutable(blockHalfAxes[0]).Subtract(blockLeftRightAttachmentHalfAxes[1]).Subtract(blockLeftRightAttachmentHalfAxes[2]),
                origin.SubtractImmutable(blockHalfAxes[0]).Add(blockLeftRightAttachmentHalfAxes[1]).Subtract(blockLeftRightAttachmentHalfAxes[2]),
                origin.SubtractImmutable(blockLeftRightAttachmentHalfAxes[0]).Add(blockLeftRightAttachmentHalfAxes[1]).Subtract(blockLeftRightAttachmentHalfAxes[2]),
                origin.SubtractImmutable(blockLeftRightAttachmentHalfAxes[0]).Subtract(blockLeftRightAttachmentHalfAxes[1]).Subtract(blockLeftRightAttachmentHalfAxes[2])                              
            };            

            BVBackAttachment = new Vector3f[] {
                origin.SubtractImmutable(blockFrontBackAttachmentHalfAxes[0]).Subtract(blockFrontBackAttachmentHalfAxes[1]).Subtract(blockHalfAxes[2]),
                origin.SubtractImmutable(blockFrontBackAttachmentHalfAxes[0]).Add(blockFrontBackAttachmentHalfAxes[1]).Subtract(blockHalfAxes[2]),
                origin.AddImmutable(blockFrontBackAttachmentHalfAxes[0]).Add(blockFrontBackAttachmentHalfAxes[1]).Subtract(blockHalfAxes[2]),
                origin.AddImmutable(blockFrontBackAttachmentHalfAxes[0]).Subtract(blockFrontBackAttachmentHalfAxes[1]).Subtract(blockHalfAxes[2]),  
                origin.AddImmutable(blockFrontBackAttachmentHalfAxes[0]).Subtract(blockFrontBackAttachmentHalfAxes[1]).Subtract(blockFrontBackAttachmentHalfAxes[2]),
                origin.AddImmutable(blockFrontBackAttachmentHalfAxes[0]).Add(blockFrontBackAttachmentHalfAxes[1]).Subtract(blockFrontBackAttachmentHalfAxes[2]),
                origin.SubtractImmutable(blockFrontBackAttachmentHalfAxes[0]).Add(blockFrontBackAttachmentHalfAxes[1]).Subtract(blockFrontBackAttachmentHalfAxes[2]),
                origin.SubtractImmutable(blockFrontBackAttachmentHalfAxes[0]).Subtract(blockFrontBackAttachmentHalfAxes[1]).Subtract(blockFrontBackAttachmentHalfAxes[2])                              
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
            InitPositionsBuffer();
            SetupPositionsBuffer();
        }

        private void InitPositionsBuffer()
        {
            int amountOfUncoveredFaces = GetAmountOfUncoveredFaces();
            positionsBuffer = new float[4 * 3 * amountOfUncoveredFaces];            
        }

        private void SetupPositionsBuffer()
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

            AddNextFaceIndicesToBuffer(currentBufferIndex, faceOffset);
            currentBufferIndex += 6;
            faceOffset += 4;

            AddNextFaceIndicesToBuffer(currentBufferIndex, faceOffset);
            currentBufferIndex += 6;
            faceOffset += 4;

            AddNextFaceIndicesToBuffer(currentBufferIndex, faceOffset);
            currentBufferIndex += 6;
            faceOffset += 4;

            AddNextFaceIndicesToBuffer(currentBufferIndex, faceOffset);
            currentBufferIndex += 6;
            faceOffset += 4;

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

            if (attachmentState.IsAttachedToLeftNeighbor)
            {
                BuildIndicesBufferForAttachment(currentBufferIndex, faceOffset);
                currentBufferIndex += 24;
                faceOffset += 16;
            }

            if (attachmentState.IsAttachedToFrontNeighbor)
            {
                BuildIndicesBufferForAttachment(currentBufferIndex, faceOffset);
                currentBufferIndex += 24;
                faceOffset += 16;
            }             

            if (attachmentState.IsAttachedToRightNeighbor)
            {
                BuildIndicesBufferForAttachment(currentBufferIndex, faceOffset);
                currentBufferIndex += 24;
                faceOffset += 16;
            }  

            if (attachmentState.IsAttachedToBackNeighbor)
            {
                BuildIndicesBufferForAttachment(currentBufferIndex, faceOffset);
                currentBufferIndex += 24;
                faceOffset += 16;
            }             
        }

        private void BuildIndicesBufferForAttachment(int currentBufferIndex, int faceOffset)
        {
            for (int i = 0; i < 4; i++)
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
                currentBufferIndex += 12;  
            }

            if (attachmentState.IsAttachedToLeftNeighbor)
            {
                BuildNormalsBufferForLeftOrRightAttachment(currentBufferIndex);
                currentBufferIndex += 48;  
            }

            if (attachmentState.IsAttachedToFrontNeighbor)
            {
                BuildNormalsBufferForFrontOrBackAttachment(currentBufferIndex);
                currentBufferIndex += 48;
            }             

            if (attachmentState.IsAttachedToRightNeighbor)
            {
                BuildNormalsBufferForLeftOrRightAttachment(currentBufferIndex);
                currentBufferIndex += 48;
            }  

            if (attachmentState.IsAttachedToBackNeighbor)
            {
                BuildNormalsBufferForFrontOrBackAttachment(currentBufferIndex);
            }             
        }

        private void TranslateVertices()
        {
            Vector3f[] BV = GetBaseVertices();

            TranslateVertices(BV);

            if (attachmentState.IsAttachedToLeftNeighbor)
            {
                TranslateVertices(BVLeftAttachment);
            }

            if (attachmentState.IsAttachedToFrontNeighbor)
            {
                TranslateVertices(BVFrontAttachment);
            }             

            if (attachmentState.IsAttachedToRightNeighbor)
            {
                TranslateVertices(BVRightAttachment);
            }  

            if (attachmentState.IsAttachedToBackNeighbor)
            {
                TranslateVertices(BVBackAttachment);
            }              
        }

        private void TranslateVertices(Vector3f[] vertices)
        {
            Position3 cubeCenter = new Position3(0.25f + 0.5f * blockPosition.X,
                0.25f + 0.5f * blockPosition.Y,
                0.25f + 0.5f * blockPosition.Z);

            vertices[0].AddImmutableBufferResult(cubeCenter);
            vertices[1].AddImmutableBufferResult(cubeCenter);
            vertices[2].AddImmutableBufferResult(cubeCenter);
            vertices[3].AddImmutableBufferResult(cubeCenter);
            vertices[4].AddImmutableBufferResult(cubeCenter);
            vertices[5].AddImmutableBufferResult(cubeCenter);
            vertices[6].AddImmutableBufferResult(cubeCenter);
            vertices[7].AddImmutableBufferResult(cubeCenter);                
        }

        private Vector3f[] GetBaseVertices()
        {
            return BV;
        }        

        private void FillPositionsBuffer()
        {
            int currentBufferPosition = 0;
            Vector3f[] BV = GetBaseVertices();

            SetFrontFaceVertices(currentBufferPosition, BV);
            currentBufferPosition += 12;

            SetRightFaceVertices(currentBufferPosition, BV);
            currentBufferPosition += 12;

            SetBackFaceVertices(currentBufferPosition, BV);
            currentBufferPosition += 12;

            SetLeftFaceVertices(currentBufferPosition, BV);
            currentBufferPosition += 12;

            if (!bottomFaceOfBlockIsHidden)
            {
                SetBottomFaceVertices(currentBufferPosition, BV);
                currentBufferPosition += 12;
            }

            if (!topFaceOfBlockIsHidden)
            {
                SetTopFaceVertices(currentBufferPosition, BV);
                currentBufferPosition += 12;
            }

            if (attachmentState.IsAttachedToLeftNeighbor)
            {
                FillPositionsBufferLeftAttachment(currentBufferPosition);
                currentBufferPosition += 48;
            }

            if (attachmentState.IsAttachedToFrontNeighbor)
            {
                FillPositionsBufferFrontAttachment(currentBufferPosition);
                currentBufferPosition += 48;
            } 

            if (attachmentState.IsAttachedToRightNeighbor)
            {
                FillPositionsBufferRightAttachment(currentBufferPosition);
                currentBufferPosition += 48;
            }          

            if (attachmentState.IsAttachedToBackNeighbor)
            {
                FillPositionsBufferBackAttachment(currentBufferPosition);
            }                           
        }

        private void FillPositionsBufferLeftAttachment(int currentBufferPosition)
        {
            SetFrontFaceVertices(currentBufferPosition, BVLeftAttachment);
            currentBufferPosition += 12;

            SetBackFaceVertices(currentBufferPosition, BVLeftAttachment);
            currentBufferPosition += 12;

            SetBottomFaceVertices(currentBufferPosition, BVLeftAttachment);
            currentBufferPosition += 12;

            SetTopFaceVertices(currentBufferPosition, BVLeftAttachment);
            currentBufferPosition += 12;
        }

        private void FillPositionsBufferFrontAttachment(int currentBufferPosition)
        {
            SetRightFaceVertices(currentBufferPosition, BVFrontAttachment);
            currentBufferPosition += 12;

            SetLeftFaceVertices(currentBufferPosition, BVFrontAttachment);
            currentBufferPosition += 12;

            SetBottomFaceVertices(currentBufferPosition, BVFrontAttachment);
            currentBufferPosition += 12;

            SetTopFaceVertices(currentBufferPosition, BVFrontAttachment);
            currentBufferPosition += 12;
        }        

        private void FillPositionsBufferRightAttachment(int currentBufferPosition)
        {
            SetFrontFaceVertices(currentBufferPosition, BVRightAttachment);
            currentBufferPosition += 12;

            SetBackFaceVertices(currentBufferPosition, BVRightAttachment);
            currentBufferPosition += 12;

            SetBottomFaceVertices(currentBufferPosition, BVRightAttachment);
            currentBufferPosition += 12;

            SetTopFaceVertices(currentBufferPosition, BVRightAttachment);
            currentBufferPosition += 12;
        }      

        private void FillPositionsBufferBackAttachment(int currentBufferPosition)
        {
            SetRightFaceVertices(currentBufferPosition, BVBackAttachment);
            currentBufferPosition += 12;

            SetLeftFaceVertices(currentBufferPosition, BVBackAttachment);
            currentBufferPosition += 12;

            SetBottomFaceVertices(currentBufferPosition, BVBackAttachment);
            currentBufferPosition += 12;

            SetTopFaceVertices(currentBufferPosition, BVBackAttachment);
            currentBufferPosition += 12;
        }           

        private void SetFrontFaceVertices(int currentBufferPosition, Vector3f[] BV) 
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

        private void SetRightFaceVertices(int currentBufferPosition, Vector3f[] BV)
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

        private void SetBackFaceVertices(int currentBufferPosition, Vector3f[] BV) 
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

        private void SetLeftFaceVertices(int currentBufferPosition, Vector3f[] BV)
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

        private void SetBottomFaceVertices(int currentBufferPosition, Vector3f[] BV)
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

        private void SetTopFaceVertices(int currentBufferPosition, Vector3f[] BV)
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
            indexBuffer[currentBufferIndex + 1] = 3 + faceOffset + indexBufferOffsetInChunk;
            indexBuffer[currentBufferIndex + 2] = 2 + faceOffset + indexBufferOffsetInChunk;
            indexBuffer[currentBufferIndex + 3] = 2 + faceOffset + indexBufferOffsetInChunk;
            indexBuffer[currentBufferIndex + 4] = 1 + faceOffset + indexBufferOffsetInChunk;
            indexBuffer[currentBufferIndex + 5] = 0 + faceOffset + indexBufferOffsetInChunk;  
        }

        private void AddNormalForFaceWithGivenValuesStartingAtIndex(float normalX, float normalY, float normalZ, int startIndex)
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

        private void BuildNormalsBufferForLeftOrRightAttachment(int currentBufferIndex)
        {
            AddNormalForFaceWithGivenValuesStartingAtIndex(0.0f, 0.0f, 1.0f, currentBufferIndex); 
            currentBufferIndex += 12;

            AddNormalForFaceWithGivenValuesStartingAtIndex(0.0f, 0.0f, -1.0f, currentBufferIndex); 
            currentBufferIndex += 12;         

            AddNormalForFaceWithGivenValuesStartingAtIndex(0.0f, -1.0f, 0.0f, currentBufferIndex); 
            currentBufferIndex += 12;         

            AddNormalForFaceWithGivenValuesStartingAtIndex(0.0f, 1.0f, 0.0f, currentBufferIndex); 
        }

        private void BuildNormalsBufferForFrontOrBackAttachment(int currentBufferIndex)
        {
            AddNormalForFaceWithGivenValuesStartingAtIndex(-1.0f, 0.0f, 0.0f, currentBufferIndex); 
            currentBufferIndex += 12;

            AddNormalForFaceWithGivenValuesStartingAtIndex(1.0f, 0.0f, 0.0f, currentBufferIndex); 
            currentBufferIndex += 12;         

            AddNormalForFaceWithGivenValuesStartingAtIndex(0.0f, -1.0f, 0.0f, currentBufferIndex); 
            currentBufferIndex += 12;         

            AddNormalForFaceWithGivenValuesStartingAtIndex(0.0f, 1.0f, 0.0f, currentBufferIndex); 
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

                    currentTargetBufferIndex += amountOfUvFloatsPerFace;
                }      

                float[] attachmentBlocksUvCoordinates = BlockUvCoordinates.FromBlockType(blockToRender.GetBlockType()).GetUvCoordinatesForAttachmentState(attachmentState);

                for (int i = 0; i < attachmentBlocksUvCoordinates.Length; i++)
                {
                    uvBuffer[currentTargetBufferIndex + i] = attachmentBlocksUvCoordinates[i];
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
            int result = 4;

            if (attachmentState.IsAttachedToLeftNeighbor)
            {
                result += 4;
            }

            if (attachmentState.IsAttachedToFrontNeighbor)
            {
                result += 4;
            }             

            if (attachmentState.IsAttachedToRightNeighbor)
            {
                result += 4;
            }  

            if (attachmentState.IsAttachedToBackNeighbor)
            {
                result += 4;
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