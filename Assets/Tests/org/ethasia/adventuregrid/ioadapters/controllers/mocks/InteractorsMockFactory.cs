using Org.Ethasia.Adventuregrid.Interactors.Factories;
using Org.Ethasia.Adventuregrid.Interactors.Input;
using Org.Ethasia.Adventuregrid.Interactors.Mocks;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Mocks
{
    public class InteractorsMockFactory : InteractorsFactory
    {
        public override GroundedCheckInteractor CreateGroundedCheckInteractor()
        {
            return new GroundedCheckInteractorMock();
        }

        public override SetupMainMenuInteractor CreateSetupMainMenuInteractor()
        {
            return null;
        }
    }
}