using UnityEngine;

namespace Org.Ethasia.Adventuregrid.Technical.Mainmenucamerastates
{
    public class NewGameCameraState : MainMenuCameraState
    {
        private static NewGameCameraState instance;

        private static Vector3 endPosition = new Vector3(18.2f, 12.4f, 9.6f);
        private static Quaternion endRotation = Quaternion.Euler(0, -90, 0);           

        public static NewGameCameraState GetInstance()
        {
            if (null == instance)
            {
                instance = new NewGameCameraState();
            }

            return instance;
        }

        public MainMenuCameraState ChangeToNewGame()
        {
            return this;
        }

        public MainMenuCameraState ChangeToQuitGame()
        {
            return null;
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