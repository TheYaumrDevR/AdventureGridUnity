using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Interactors.Input;

namespace Org.Ethasia.Adventuregrid.Interactors.Mocks
{
    public class GroundedCheckInteractorMock : GroundedCheckInteractor
    {
        private static BlockPosition? lastPassedBlockPosition;

        public static BlockPosition? GetLastPassedBlockPosition()
        {
            return lastPassedBlockPosition;
        }

        public static void ResetMock()
        {
            lastPassedBlockPosition = null;
        }

        public bool ObjectAtPositionIsGrounded(BlockPosition position)
        {
            lastPassedBlockPosition = position;
            return false;
        }
    }
}