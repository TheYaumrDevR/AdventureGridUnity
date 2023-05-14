namespace Org.Ethasia.Adventuregrid.Ioadapters.Controllers
{
    public class RealControllersFactory : ControllersFactory
    {
        public override PlayerWithWorldInteractionController CreatePlayerWithWorldInteractionController()
        {
            return new PlayerWithWorldInteractionControllerImpl();
        }
    }
}