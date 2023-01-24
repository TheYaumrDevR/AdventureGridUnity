namespace Org.Ethasia.Adventuregrid.Ioadapters.Controllers
{
    public abstract class ControllersFactory
    {
        private static ControllersFactory instance;

        public static void SetInstance(ControllersFactory value)
        {
            instance = value;
        }

        public static ControllersFactory GetInstance()
        {
            return instance;
        }

        public abstract PlayerWithWorldInteractionController CreatePlayerWithWorldInteractionController();
    }
}