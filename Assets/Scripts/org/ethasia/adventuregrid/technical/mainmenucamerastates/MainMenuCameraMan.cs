using UnityEngine;

using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Technical.Mainmenucamerastates
{
    public class MainMenuCameraMan : MonoBehaviour
    {
        private static MainMenuCameraMan currentInstance;

        [SerializeField]
        private Transform mainMenuCameraTransform;

        private MainMenuCameraState cameraState;

        public static MainMenuCameraMan GetInstance()
        {
            return currentInstance;
        }

        void Awake()
        {
            currentInstance = this;
        }

        void Start()
        {
            cameraState = InitialSelectionCameraState.GetInstance();
        }

        void Update()
        {
            mainMenuCameraTransform.position = Vector3.Lerp(mainMenuCameraTransform.position, cameraState.GetTargetPosition(), 0.0125f);
            mainMenuCameraTransform.rotation = Quaternion.Slerp(mainMenuCameraTransform.rotation, cameraState.GetTargetRotation(), 0.0125f);
        }

        public void ChangeToNewGame()
        {
            cameraState = cameraState.ChangeToNewGame();
        }

        public void ChangeToQuitGame()
        {
            cameraState = cameraState.ChangeToQuitGame();
        }

        public bool IsMovingCamera()
        {
            return !FastMath.NearlyEqual(mainMenuCameraTransform.position.x, cameraState.GetTargetPosition().x, 0.01f) 
                || !FastMath.NearlyEqual(mainMenuCameraTransform.position.y, cameraState.GetTargetPosition().y, 0.01f) 
                || !FastMath.NearlyEqual(mainMenuCameraTransform.position.z, cameraState.GetTargetPosition().z, 0.01f);
        }
    }
}