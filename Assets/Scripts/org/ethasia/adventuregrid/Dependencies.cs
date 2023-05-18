using Org.Ethasia.Adventuregrid.Core;
using Org.Ethasia.Adventuregrid.Interactors.Factories;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters;
using Org.Ethasia.Adventuregrid.Ioadapters;
using Org.Ethasia.Adventuregrid.Ioadapters.Controllers;
using Org.Ethasia.Adventuregrid.Technical;

namespace Org.Ethasia.Adventuregrid
{
    public class Dependencies
    {
        public static void Inject()
        {
            InjectCoreDependencies();
            InjectInteractorDependencies();
            InjectIoAdapterDependencies();
            InjectTechnicalDependencies();
        }

        private static void InjectCoreDependencies()
        {
            CoreFactory.SetInstance(new RealCoreFactory());
            InteractorsFactoryForCore.SetInstance(new RealInteractorsFactoryForCore());
        }

        private static void InjectInteractorDependencies()
        {
            InteractorsFactory.SetInstance(new RealInteractorsFactory());
            IoAdaptersFactoryForInteractors.SetInstance(new RealIoAdaptersFactoryForInteractors());
        }   

        private static void InjectIoAdapterDependencies()
        {
            ControllersFactory.SetInstance(new RealControllersFactory());
        }

        private static void InjectTechnicalDependencies()
        {
            TechnicalsFactory.SetInstance(new RealTechnicalsFactory());
        }             
    }
}