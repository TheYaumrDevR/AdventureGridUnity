using UnityEngine;

namespace Org.Ethasia.Adventuregrid.Technical.Mainmenucamerastates
{
    public class InitialSelectionCameraState : MainMenuCameraState
    {
        private static InitialSelectionCameraState instance;

        private static Vector3 endPosition = new Vector3(23.5f, 12f, 10.1f);
        private static Quaternion endRotation = Quaternion.Euler(-19f, -172, 8f);

        public static InitialSelectionCameraState GetInstance()
        {
            if (null == instance)
            {
                instance = new InitialSelectionCameraState();
            }

            return instance;
        }

        public MainMenuCameraState ChangeToNewGame()
        {
            return NewGameCameraState.GetInstance();
        }

        public MainMenuCameraState ChangeToQuitGame()
        {
            return QuitGameCameraState.GetInstance();
        }

        public Vector3 GetTargetPosition()
        {
            return endPosition;
        }

        public Quaternion GetTargetRotation()
        {
            return endRotation;
        }
    }
}