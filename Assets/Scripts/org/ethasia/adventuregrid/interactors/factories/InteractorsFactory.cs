using Org.Ethasia.Adventuregrid.Interactors.Input;

namespace Org.Ethasia.Adventuregrid.Interactors.Factories
{
    public abstract class InteractorsFactory
    {
        private static InteractorsFactory instance;
    
        public static void SetInstance(InteractorsFactory value) 
        {
            instance = value;
        }
    
        public static InteractorsFactory GetInstance() 
        {
            return instance;
        }

        public abstract GroundedCheckInteractor CreateGroundedCheckInteractor();        
    }
}