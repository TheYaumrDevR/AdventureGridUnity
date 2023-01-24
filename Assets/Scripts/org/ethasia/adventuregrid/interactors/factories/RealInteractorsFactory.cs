using Org.Ethasia.Adventuregrid.Interactors;
using Org.Ethasia.Adventuregrid.Interactors.Input;

namespace Org.Ethasia.Adventuregrid.Interactors.Factories
{
    public class RealInteractorsFactory : InteractorsFactory
    {
        public override GroundedCheckInteractor CreateGroundedCheckInteractor() 
        {
            return new GroundedCheckInteractorImpl();
        }
    }
}