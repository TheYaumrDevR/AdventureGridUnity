using Org.Ethasia.Adventuregrid.Core;
using Org.Ethasia.Adventuregrid.Ioadapters;
using Org.Ethasia.Adventuregrid.Technical;

namespace Org.Ethasia.Adventuregrid
{
    public class Dependencies
    {
        public static void Inject()
        {
            InjectCoreDependencies();
            InjectInteractorDependencies();
            InjectTechnicalDependencies();
        }

        private static void InjectCoreDependencies()
        {
            CoreFactory.SetInstance(new RealCoreFactory());
        }

        private static void InjectInteractorDependencies()
        {
            
        }   

        private static void InjectTechnicalDependencies()
        {
            TechnicalsFactory.SetInstance(new RealTechnicalsFactory());
        }             
    }
}