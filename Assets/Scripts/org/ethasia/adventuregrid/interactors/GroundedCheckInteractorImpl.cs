using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Interactors.Input;

namespace Org.Ethasia.Adventuregrid.Interactors
{
    public class GroundedCheckInteractorImpl : GroundedCheckInteractor
    {
        public bool ObjectAtPositionIsGrounded(BlockPosition position)
        {
            Island island = World.CurrentIsland();

            try 
            {
                return island.BlockAtPositionIsWalkable(position);
            }
            catch (BlockPositionOutOfBoundsException)
            {
                return false;
            }
        }
    }
}