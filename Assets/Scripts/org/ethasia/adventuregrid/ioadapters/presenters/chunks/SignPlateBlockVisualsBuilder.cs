using Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators;
using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public class SignPlateBlockVisualsBuilder : CuboidBlockVisualsBuilder
    {
        // Base vertices
        private static readonly Vector3f[] BV;
        private static readonly Vector3f[] BVBackUp;
        private static readonly Vector3f[] BVRightUp;
        private static readonly Vector3f[] BVLeftUp;

        static SignPlateBlockVisualsBuilder()
        {
            Vector3f[] blockHalfAxes = {
                Vector3f.UNIT_X.ScaleImmutable(BLOCK_HALF_EDGE_LENGTH_IN_ENGINE_UNITS),
                Vector3f.UNIT_Y.ScaleImmutable(0.15f),
                Vector3f.UNIT_Z.ScaleImmutable(0.025f)
            };

            Vector3f[] blockHalfAxesNinetyDegRotated = {
                Vector3f.UNIT_X.ScaleImmutable(0.025f),
                Vector3f.UNIT_Y.ScaleImmutable(0.15f),
                Vector3f.UNIT_Z.ScaleImmutable(BLOCK_HALF_EDGE_LENGTH_IN_ENGINE_UNITS)
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

            BVBackUp = new Vector3f[] {
                origin.AddImmutable(blockHalfAxes[0]).Subtract(blockHalfAxes[1]).Subtract(blockHalfAxes[2]),
                origin.AddImmutable(blockHalfAxes[0]).Add(blockHalfAxes[1]).Subtract(blockHalfAxes[2]),
                origin.SubtractImmutable(blockHalfAxes[0]).Add(blockHalfAxes[1]).Subtract(blockHalfAxes[2]),
                origin.SubtractImmutable(blockHalfAxes[0]).Subtract(blockHalfAxes[1]).Subtract(blockHalfAxes[2]),
                origin.SubtractImmutable(blockHalfAxes[0]).Subtract(blockHalfAxes[1]).Add(blockHalfAxes[2]),
                origin.SubtractImmutable(blockHalfAxes[0]).Add(blockHalfAxes[1]).Add(blockHalfAxes[2]),
                origin.AddImmutable(blockHalfAxes[0]).Add(blockHalfAxes[1]).Add(blockHalfAxes[2]),
                origin.AddImmutable(blockHalfAxes[0]).Subtract(blockHalfAxes[1]).Add(blockHalfAxes[2])                
            };   

            BVRightUp = new Vector3f[] {
                origin.SubtractImmutable(blockHalfAxesNinetyDegRotated[0]).Subtract(blockHalfAxesNinetyDegRotated[1]).Subtract(blockHalfAxesNinetyDegRotated[2]),
                origin.SubtractImmutable(blockHalfAxesNinetyDegRotated[0]).Add(blockHalfAxesNinetyDegRotated[1]).Subtract(blockHalfAxesNinetyDegRotated[2]),
                origin.SubtractImmutable(blockHalfAxesNinetyDegRotated[0]).Add(blockHalfAxesNinetyDegRotated[1]).Add(blockHalfAxesNinetyDegRotated[2]),
                origin.SubtractImmutable(blockHalfAxesNinetyDegRotated[0]).Subtract(blockHalfAxesNinetyDegRotated[1]).Add(blockHalfAxesNinetyDegRotated[2]),
                origin.AddImmutable(blockHalfAxesNinetyDegRotated[0]).Subtract(blockHalfAxesNinetyDegRotated[1]).Add(blockHalfAxesNinetyDegRotated[2]),
                origin.AddImmutable(blockHalfAxesNinetyDegRotated[0]).Add(blockHalfAxesNinetyDegRotated[1]).Add(blockHalfAxesNinetyDegRotated[2]),
                origin.AddImmutable(blockHalfAxesNinetyDegRotated[0]).Add(blockHalfAxesNinetyDegRotated[1]).Subtract(blockHalfAxesNinetyDegRotated[2]),
                origin.AddImmutable(blockHalfAxesNinetyDegRotated[0]).Subtract(blockHalfAxesNinetyDegRotated[1]).Subtract(blockHalfAxesNinetyDegRotated[2])
            };  

            BVLeftUp = new Vector3f[] {
                origin.AddImmutable(blockHalfAxesNinetyDegRotated[0]).Subtract(blockHalfAxesNinetyDegRotated[1]).Add(blockHalfAxesNinetyDegRotated[2]),
                origin.AddImmutable(blockHalfAxesNinetyDegRotated[0]).Add(blockHalfAxesNinetyDegRotated[1]).Add(blockHalfAxesNinetyDegRotated[2]),
                origin.AddImmutable(blockHalfAxesNinetyDegRotated[0]).Add(blockHalfAxesNinetyDegRotated[1]).Subtract(blockHalfAxesNinetyDegRotated[2]),
                origin.AddImmutable(blockHalfAxesNinetyDegRotated[0]).Subtract(blockHalfAxesNinetyDegRotated[1]).Subtract(blockHalfAxesNinetyDegRotated[2]),
                origin.SubtractImmutable(blockHalfAxesNinetyDegRotated[0]).Subtract(blockHalfAxesNinetyDegRotated[1]).Subtract(blockHalfAxesNinetyDegRotated[2]),
                origin.SubtractImmutable(blockHalfAxesNinetyDegRotated[0]).Add(blockHalfAxesNinetyDegRotated[1]).Subtract(blockHalfAxesNinetyDegRotated[2]),
                origin.SubtractImmutable(blockHalfAxesNinetyDegRotated[0]).Add(blockHalfAxesNinetyDegRotated[1]).Add(blockHalfAxesNinetyDegRotated[2]),
                origin.SubtractImmutable(blockHalfAxesNinetyDegRotated[0]).Subtract(blockHalfAxesNinetyDegRotated[1]).Add(blockHalfAxesNinetyDegRotated[2])
            };                                  
        }

        public override Vector3f[] GetBaseVertices()
        {
            switch(rotationState)
            {
                case RotationStates.RIGHT_POINTING_UP:
                    return BVRightUp;
                case RotationStates.BACK_POINTING_UP:
                    return BVBackUp;
                case RotationStates.LEFT_POINTING_UP:
                    return BVLeftUp;
                default:
                    return BV;                                        
            }
        }

        protected override void FillNormalsBuffer()
        {
            switch(rotationState)
            {
                case RotationStates.RIGHT_POINTING_UP:
                    FillNormalsBufferForRightFacingRotation();
                    break;
                case RotationStates.BACK_POINTING_UP:
                    FillNormalsBufferForBackFacingRotation();
                    break;
                case RotationStates.LEFT_POINTING_UP:
                    FillNormalsBufferForLeftFacingRotation();
                    break;
                default:
                    base.FillNormalsBuffer();      
                    break;                                  
            }                        
        }

        private void FillNormalsBufferForRightFacingRotation()
        {
            int currentBufferIndex = 0;

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

            if (!frontFaceOfBlockIsHidden)
            {
                AddNormalForFaceWithGivenValuesStartingAtIndex(0.0f, 0.0f, 1.0f, currentBufferIndex); 
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

        private void FillNormalsBufferForBackFacingRotation()
        {
            int currentBufferIndex = 0;

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

        private void FillNormalsBufferForLeftFacingRotation()
        {
            int currentBufferIndex = 0;

            if (!leftFaceOfBlockIsHidden)
            {
                AddNormalForFaceWithGivenValuesStartingAtIndex(1.0f, 0.0f, 0.0f, currentBufferIndex); 
                currentBufferIndex += 12;   
            }  

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
    }
}