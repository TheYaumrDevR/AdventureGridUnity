using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Interactors;
using Org.Ethasia.Adventuregrid.Interactors.Factories;
using Org.Ethasia.Adventuregrid.Interactors.Input;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Controllers
{
    public class PlayerWithWorldInteractionControllerImpl : PlayerWithWorldInteractionController
    {
        private GroundedCheckInteractor groundedCheckInteractor;

        public PlayerWithWorldInteractionControllerImpl()
        {
            groundedCheckInteractor = InteractorsFactory.GetInstance().CreateGroundedCheckInteractor();
        }

        public bool TestPlayerIsGrounded(Position3 playerFootPosition)
        {
            int blockPositionX = FastMath.Ceil(playerFootPosition.X * 2) - 1;
            int blockPositionY = FastMath.Ceil(playerFootPosition.Y * 2) - 1;
            int blockPositionZ = FastMath.Ceil(playerFootPosition.Z * 2) - 1;
        
            BlockPosition blockPosition = new BlockPosition(blockPositionX, blockPositionY, blockPositionZ);

            return groundedCheckInteractor.ObjectAtPositionIsGrounded(blockPosition);
        }
    }
}