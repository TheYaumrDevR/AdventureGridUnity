using Org.Ethasia.Adventuregrid.Core.InputInterfaces;
using Org.Ethasia.Adventuregrid.Interactors.Factories;
using Org.Ethasia.Adventuregrid.Interactors.Input;

using UnityEngine;

namespace Org.Ethasia.Adventuregrid
{
    public class AdventureGrid : MonoBehaviour
    {
        void Start()
        {
            Dependencies.Inject();
            SetupMainMenuInteractor setupMainMenuInteractor = InteractorsFactory.GetInstance().CreateSetupMainMenuInteractor();
            setupMainMenuInteractor.GenerateMainMenuSceneAndEnterMainMenu();
        }
    }
}