using Org.Ethasia.Adventuregrid.Interactors.Output;

namespace Org.Ethasia.Adventuregrid.Interactors
{

    public abstract class IoAdaptersFactoryForInteractors
    {
        private static IoAdaptersFactoryForInteractors instance;
    
        public static void SetInstance(IoAdaptersFactoryForInteractors value) 
        {
            instance = value;
        }
    
        public static IoAdaptersFactoryForInteractors GetInstance() 
        {
            return instance;
        }

        public abstract IslandPresenter CreateIslandPresenter();        
    }
}