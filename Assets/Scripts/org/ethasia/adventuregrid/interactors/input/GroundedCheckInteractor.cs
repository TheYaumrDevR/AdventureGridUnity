using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Interactors.Input
{
    public interface GroundedCheckInteractor
    {
        bool ObjectAtPositionIsGrounded(BlockPosition position);
    }
}