using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Interactors.Output;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Interfaces.Technical;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters 
{
    public class StandardPlayerCharacterPresenter : PlayerCharacterPresenter
    {
        public void PresentPlayerCharacter(BlockPosition position)
        {
            PlayerRenderer playerRenderer = TechnicalsFactory.GetInstance().GetPlayerRendererInstance();
            playerRenderer.RenderPlayerAt(position);
        }
    }
}