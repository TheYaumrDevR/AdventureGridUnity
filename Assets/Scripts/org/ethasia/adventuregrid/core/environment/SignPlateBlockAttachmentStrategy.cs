using Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators;

namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public class SignPlateBlockAttachmentStrategy : IBlockAttachingStrategy
    {
        public bool AttachesToLeftBlock(Block leftBlock)
        {
            if (BlockTypes.WALNUT_WOOD_ARROW_SIGNPLATE == leftBlock.GetBlockType())
            {
                RotationStates rotationState = ExtractRotationState(leftBlock);
                return RotationStates.FRONT_POINTING_UP == rotationState;
            }

            return false;
        }

        public bool AttachesToRightBlock(Block rightBlock)
        {
            if (BlockTypes.WALNUT_WOOD_ARROW_SIGNPLATE == rightBlock.GetBlockType())
            {
                RotationStates rotationState = ExtractRotationState(rightBlock);
                return RotationStates.BACK_POINTING_UP == rotationState;
            }

            return false;
        }

        public bool AttachesToFrontBlock(Block frontBlock)
        {
            if (BlockTypes.WALNUT_WOOD_ARROW_SIGNPLATE == frontBlock.GetBlockType())
            {
                RotationStates rotationState = ExtractRotationState(frontBlock);
                return RotationStates.RIGHT_POINTING_UP == rotationState;
            }

            return false;
        }

        public bool AttachesToBackBlock(Block backBlock)
        {
            if (BlockTypes.WALNUT_WOOD_ARROW_SIGNPLATE == backBlock.GetBlockType())
            {
                RotationStates rotationState = ExtractRotationState(backBlock);
                return RotationStates.LEFT_POINTING_UP == rotationState;
            }

            return false;
        }

        public bool AttachesToBottomBlock(Block bottomBlock)
        {
            return false;
        }

        public bool AttachesToTopBlock(Block topBlock)
        {
            return false;
        }

        private RotationStates ExtractRotationState(Block neighborBlock)
        {
            RotationDataExtractionVisitor rotationStateExtractor = RotationDataExtractionVisitor.GetInstance();
            neighborBlock.Visit(rotationStateExtractor);

            if (rotationStateExtractor.HasRotationState)
            {
                return rotationStateExtractor.ExtractedRotationState.GetRotationIdentifier();
            }

            return RotationStates.FRONT_POINTING_UP;
        } 
    }
}
