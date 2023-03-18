namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public class WalnutAttachmentPoleBlockUvCoordinates : BlockUvCoordinates
    {
        private const int UV_BUFFER_LENGTH_FOR_ATTACHMENT = 48;

        private static WalnutAttachmentPoleBlockUvCoordinates instance;
        
        public static WalnutAttachmentPoleBlockUvCoordinates GetInstance() 
        {
            if (null == instance) 
            {
                instance = new WalnutAttachmentPoleBlockUvCoordinates();
            }
        
            return instance;
        } 

        private readonly float[] uvCoordinates = {
            0.65f, 0, 5, 0.65f, 1, 5, 0.35f, 1, 5, 0.35f, 0, 5, // Front 
            0.65f, 0, 5, 0.65f, 1, 5, 0.35f, 1, 5, 0.35f, 0, 5, // Right
            0.65f, 0, 5, 0.65f, 1, 5, 0.35f, 1, 5, 0.35f, 0, 5, // Back
            0.65f, 0, 5, 0.65f, 1, 5, 0.35f, 1, 5, 0.35f, 0, 5, // Left
            0.65f, 0.4f, 5, 0.65f, 0.6f, 5, 0.35f, 0.6f, 5, 0.35f, 0.4f, 5, // Bottom 
            0.65f, 0.4f, 5, 0.65f, 0.6f, 5, 0.35f, 0.6f, 5, 0.35f, 0.4f, 5 // Top
        };         

        private readonly float[] backUvCoordinates = {
            0.35f, 0, 5, 0.35f, 1, 5, 0.65f, 1, 5, 0.65f, 0, 5, // Front
            0.35f, 0, 5, 0.35f, 1, 5, 0.65f, 1, 5, 0.65f, 0, 5, // Right
            0.35f, 0, 5, 0.35f, 1, 5, 0.65f, 1, 5, 0.65f, 0, 5, // Back
            0.35f, 0, 5, 0.35f, 1, 5, 0.65f, 1, 5, 0.65f, 0, 5, // Left
            0.35f, 0.4f, 5, 0.35f, 0.6f, 5, 0.65f, 0.6f, 5, 0.65f, 0.4f, 5, // Bottom 
            0.35f, 0.4f, 5, 0.35f, 0.6f, 5, 0.65f, 0.6f, 5, 0.65f, 0.4f, 5 // Top
        }; 

        private readonly float[] uvCoordinatesLeftAttachment = {
            0.35f, 0.29f, 5, 0.35f, 0.65f, 5, 0, 0.65f, 5, 0, 0.29f, 5, // Front 
            0, 0.29f, 5, 0, 0.65f, 5, 0.35f, 0.65f, 5, 0.35f, 0.29f, 5,  // Back
            0.35f, 0.45f, 5, 0.35f, 0.55f, 5, 0, 0.55f, 5, 0, 0.45f, 5, // Bottom 
            0.35f, 0.45f, 5, 0.35f, 0.55f, 5, 0, 0.55f, 5, 0, 0.45f, 5 // Top
        };         

        private readonly float[] backUvCoordinatesLeftAttachment = {
            0, 0.29f, 5, 0, 0.65f, 5, 0.35f, 0.65f, 5, 0.35f, 0.29f, 5, // Front
            0.35f, 0.29f, 5, 0.35f, 0.65f, 5, 0, 0.65f, 5, 0, 0.29f, 5, // Back
            0, 0.45f, 5, 0, 0.55f, 5, 0.35f, 0.55f, 5, 0.35f, 0.45f, 5, // Bottom 
            0, 0.45f, 5, 0, 0.55f, 5, 0.35f, 0.55f, 5, 0.35f, 0.45f, 5 // Top
        };   

        private readonly float[] uvCoordinatesFrontAttachment = {
            0.35f, 0.29f, 5, 0.35f, 0.65f, 5, 0, 0.65f, 5, 0, 0.29f, 5, // Right
            0.35f, 0.29f, 5, 0.35f, 0.65f, 5, 0, 0.65f, 5, 0, 0.29f, 5, // Left
            0.35f, 0.45f, 5, 0.35f, 0.55f, 5, 0, 0.55f, 5, 0, 0.45f, 5, // Bottom 
            0.35f, 0.45f, 5, 0.35f, 0.55f, 5, 0, 0.55f, 5, 0, 0.45f, 5 // Top
        };         

        private readonly float[] backUvCoordinatesFrontAttachment = {
            0, 0.29f, 5, 0, 0.65f, 5, 0.35f, 0.65f, 5, 0.35f, 0.29f, 5, // Right
            0, 0.29f, 5, 0, 0.65f, 5, 0.35f, 0.65f, 5, 0.35f, 0.29f, 5, // Left
            0, 0.45f, 5, 0, 0.55f, 5, 0.35f, 0.55f, 5, 0.35f, 0.45f, 5, // Bottom 
            0, 0.45f, 5, 0, 0.55f, 5, 0.35f, 0.55f, 5, 0.35f, 0.45f, 5 // Top
        };         

        private readonly float[] uvCoordinatesRightAttachment = {
            1, 0.29f, 5, 1, 0.65f, 5, 0.65f, 0.65f, 5, 0.65f, 0.29f, 5, // Front 
            0.65f, 0.29f, 5, 0.65f, 0.65f, 5, 1, 0.65f, 5, 1, 0.29f, 5,  // Back
            1, 0.45f, 5, 1, 0.55f, 5, 0.65f, 0.55f, 5, 0.65f, 0.45f, 5, // Bottom 
            1, 0.45f, 5, 1, 0.55f, 5, 0.65f, 0.55f, 5, 0.65f, 0.45f, 5 // Top
        };         

        private readonly float[] backUvCoordinatesRightAttachment = {
            0.65f, 0.29f, 5, 0.65f, 0.65f, 5, 1, 0.65f, 5, 1, 0.29f, 5, // Front
            1, 0.29f, 5, 1, 0.65f, 5, 0.65f, 0.65f, 5, 0.65f, 0.29f, 5, // Back
            0.65f, 0.45f, 5, 0.65f, 0.55f, 5, 1, 0.55f, 5, 1, 0.45f, 5, // Bottom 
            0.65f, 0.45f, 5, 0.65f, 0.55f, 5, 1, 0.55f, 5, 1, 0.45f, 5 // Top
        };   

        private readonly float[] uvCoordinatesBackAttachment = {
            1, 0.29f, 5, 1, 0.65f, 5, 0, 0.65f, 5, 0, 0.29f, 5, // Right
            1, 0.29f, 5, 1, 0.65f, 5, 0, 0.65f, 5, 0, 0.29f, 5, // Left
            1, 0.45f, 5, 1, 0.55f, 5, 0, 0.55f, 5, 0, 0.45f, 5, // Bottom 
            1, 0.45f, 5, 1, 0.55f, 5, 0, 0.55f, 5, 0, 0.45f, 5 // Top
        };         

        private readonly float[] backUvCoordinatesBackAttachment = {
            0.65f, 0.29f, 5, 0.65f, 0.65f, 5, 1, 0.65f, 5, 1, 0.29f, 5, // Right
            0.65f, 0.29f, 5, 0.65f, 0.65f, 5, 1, 0.65f, 5, 1, 0.29f, 5, // Left
            0.65f, 0.45f, 5, 0.65f, 0.55f, 5, 1, 0.55f, 5, 1, 0.45f, 5, // Bottom 
            0.65f, 0.45f, 5, 0.65f, 0.55f, 5, 1, 0.55f, 5, 1, 0.45f, 5 // Top
        };         


        private WalnutAttachmentPoleBlockUvCoordinates() {}

        public override float[] GetUvCoordinates() 
        {
            return uvCoordinates;
        }
    
        public override float[] GetBackUvCoordinates() 
        {
            return backUvCoordinates;
        }

        public override float[] GetUvCoordinatesForAttachmentState(BlockAttachmentState attachmentState) 
        {
            float[] result = new float[GetAttachmentUvBufferSize(attachmentState)];
            int copyOffSet = 0;

            if (attachmentState.IsAttachedToLeftNeighbor)
            {
                CopyUvBufferForOneAttachment(result, uvCoordinatesLeftAttachment, copyOffSet);
                copyOffSet += UV_BUFFER_LENGTH_FOR_ATTACHMENT;
            }  

            if (attachmentState.IsAttachedToFrontNeighbor)
            {
                CopyUvBufferForOneAttachment(result, uvCoordinatesFrontAttachment, copyOffSet);
                copyOffSet += UV_BUFFER_LENGTH_FOR_ATTACHMENT;
            }

            if (attachmentState.IsAttachedToRightNeighbor)
            {
                CopyUvBufferForOneAttachment(result, uvCoordinatesRightAttachment, copyOffSet);
                copyOffSet += UV_BUFFER_LENGTH_FOR_ATTACHMENT;
            }

            if (attachmentState.IsAttachedToBackNeighbor)
            {
                CopyUvBufferForOneAttachment(result, uvCoordinatesBackAttachment, copyOffSet);
            }                                              

            return result;
        }
    
        public override float[] GetBackUvCoordinatesForAttachmentState(BlockAttachmentState attachmentState) 
        {
            float[] result = new float[GetAttachmentUvBufferSize(attachmentState)];
            int copyOffSet = 0;

            if (attachmentState.IsAttachedToLeftNeighbor)
            {
                CopyUvBufferForOneAttachment(result, backUvCoordinatesLeftAttachment, copyOffSet);
                copyOffSet += UV_BUFFER_LENGTH_FOR_ATTACHMENT;
            }  

            if (attachmentState.IsAttachedToFrontNeighbor)
            {
                CopyUvBufferForOneAttachment(result, backUvCoordinatesFrontAttachment, copyOffSet);
                copyOffSet += UV_BUFFER_LENGTH_FOR_ATTACHMENT;
            }

            if (attachmentState.IsAttachedToRightNeighbor)
            {
                CopyUvBufferForOneAttachment(result, backUvCoordinatesRightAttachment, copyOffSet);
                copyOffSet += UV_BUFFER_LENGTH_FOR_ATTACHMENT;
            }

            if (attachmentState.IsAttachedToBackNeighbor)
            {
                CopyUvBufferForOneAttachment(result, backUvCoordinatesBackAttachment, copyOffSet);
            }                                              

            return result;
        }    

        private int GetAttachmentUvBufferSize(BlockAttachmentState attachmentState)
        {
            int result = 0;

            if (attachmentState.IsAttachedToFrontNeighbor)
            {
                result += UV_BUFFER_LENGTH_FOR_ATTACHMENT;
            }

            if (attachmentState.IsAttachedToRightNeighbor)
            {
                result += UV_BUFFER_LENGTH_FOR_ATTACHMENT;
            }

            if (attachmentState.IsAttachedToBackNeighbor)
            {
                result += UV_BUFFER_LENGTH_FOR_ATTACHMENT;
            }     

            if (attachmentState.IsAttachedToLeftNeighbor)
            {
                result += UV_BUFFER_LENGTH_FOR_ATTACHMENT;
            } 

            return result;
        }    

        private void CopyUvBufferForOneAttachment(float[] target, float[] source, int targetOffset)
        {
            for (int i = 0; i < UV_BUFFER_LENGTH_FOR_ATTACHMENT; i++)
            {
                target[i + targetOffset] = source[i];
            }            
        }
    }
}