using UnityEngine;

namespace Org.Ethasia.Adventuregrid.Technical.Mainmenucamerastates
{
    public class QuitGameCameraState : MainMenuCameraState
    {
        private static QuitGameCameraState instance;

        private static Vector3 endPosition = new Vector3(27, 12.4f, 9.6f);
        private static Quaternion endRotation = Quaternion.Euler(0, 90, 0);        

        public static QuitGameCameraState GetInstance()
        {
            if (null == instance)
            {
                instance = new QuitGameCameraState();
            }

            return instance;
        }

        public MainMenuCameraState ChangeToNewGame()
        {
            return null;
        }

        public MainMenuCameraState ChangeToQuitGame()
        {
            return this;
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