using UnityEngine; 

using Org.Ethasia.Adventuregrid.Interactors.Factories;
using Org.Ethasia.Adventuregrid.Interactors.Input;

namespace Org.Ethasia.Adventuregrid.Technical
{
    public class OverworldScene : MonoBehaviour
    {
        void Start()
        {
            CreateWorldInteractor createWorldInteractor = InteractorsFactory.GetInstance().CreateCreateWorldInteractor();
            createWorldInteractor.CreateAndRenderFirstIsland();
        }        
    }
}