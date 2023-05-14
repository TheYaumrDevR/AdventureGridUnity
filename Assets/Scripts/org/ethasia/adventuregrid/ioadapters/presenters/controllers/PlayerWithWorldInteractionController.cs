using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Controllers
{
    public interface PlayerWithWorldInteractionController
    {
        bool TestPlayerIsGrounded(Position3 playerFootPosition);
    }
}