using UnityEngine;

namespace Org.Ethasia.Adventuregrid.Technical.Mainmenucamerastates
{
    public interface MainMenuCameraState
    {
        MainMenuCameraState ChangeToNewGame();
        MainMenuCameraState ChangeToQuitGame();

        Vector3 GetTargetPosition();
        Quaternion GetTargetRotation();
    }
}