using UnityEngine;
using UnityEngine.InputSystem;

namespace Org.Ethasia.Adventuregrid.Technical.Inputcontrols
{
    public class PlayerCameraInputControl : MonoBehaviour
    {
        private static readonly Vector3 untranslatedCameraPositionOffset = new Vector3(0, 1.4f, 0);
        private static readonly Vector3 cameraTranslationVector = new Vector3(0, 0, -4);
        private static readonly Vector3 cameraForwardPositionScaleVector = new Vector3(0.1f, 0.1f, 0.1f);

        [SerializeField]
        private Camera playerCamera;

        [SerializeField]
        private Transform playerAvatarTransform;

        private Vector3 previousCursorViewportPosition;

        private Vector3 previousMousePosition;

        private Vector3 previousPlayerPosition;

        void Update()
        {
            if (Input.GetMouseButtonDown(InputControlConstants.LEFT_MOUSE_BUTTON)) 
            {
                HideCursorAndSaveCursorPositions();
            }
            else if (Input.GetMouseButton(InputControlConstants.LEFT_MOUSE_BUTTON))
            {
                Cursor.visible = false;

                Vector3 cursorDragDirection = previousCursorViewportPosition - playerCamera.ScreenToViewportPoint(Input.mousePosition);
                Vector3 playerAvatarPosition = playerAvatarTransform.position;
                Vector3 untranslatedCameraPosition = playerAvatarPosition + untranslatedCameraPositionOffset;

                playerCamera.transform.localPosition = untranslatedCameraPosition;

                RotateCameraWithoutFlippingIt(cursorDragDirection);
                TranslateCameraRespectTerrainCollision(untranslatedCameraPosition);

                Mouse.current.WarpCursorPosition(previousMousePosition);
            }
            else
            {
                Cursor.visible = true;

                if (0 != Vector3.Dot(previousPlayerPosition, playerAvatarTransform.position))
                {
                    Vector3 playerAvatarPosition = playerAvatarTransform.position;
                    Vector3 untranslatedCameraPosition = playerAvatarPosition + untranslatedCameraPositionOffset;

                    playerCamera.transform.localPosition = untranslatedCameraPosition;

                    TranslateCameraRespectTerrainCollision(untranslatedCameraPosition);
                }
            }

            previousPlayerPosition = playerAvatarTransform.position;
        }

        private void HideCursorAndSaveCursorPositions() 
        {
            Cursor.visible = false;
            previousMousePosition = Mouse.current.position.ReadValue();
            previousCursorViewportPosition = playerCamera.ScreenToViewportPoint(previousMousePosition);
        }

        private void RotateCameraWithoutFlippingIt(Vector3 cursorDragDirection) 
        {
            Quaternion previousRotation = playerCamera.transform.rotation;
            playerCamera.transform.Rotate(Vector3.right, cursorDragDirection.y * 180);
            playerCamera.transform.Rotate(Vector3.up, -cursorDragDirection.x * 180, Space.World);

            if (playerCamera.transform.up.y < 0) 
            {
                playerCamera.transform.rotation = previousRotation;
            }
        }

        private void TranslateCameraRespectTerrainCollision(Vector3 untranslatedCameraPosition) 
        {
            RaycastHit hitInfo;
            bool cameraWillCollideWithTerrain = Physics.Raycast(untranslatedCameraPosition, -playerCamera.transform.forward, out hitInfo, cameraTranslationVector.magnitude);

            if (cameraWillCollideWithTerrain) 
            {
                Vector3 veryShortCameraForwardVector = Vector3.Normalize(playerCamera.transform.forward);
                veryShortCameraForwardVector.Scale(cameraForwardPositionScaleVector);

                Vector3 translationLengthVector = (hitInfo.point - untranslatedCameraPosition) + veryShortCameraForwardVector;
                Vector3 correctedCameraTranslateVector = Vector3.Normalize(cameraTranslationVector);
                correctedCameraTranslateVector.Scale(new Vector3(translationLengthVector.magnitude, translationLengthVector.magnitude, translationLengthVector.magnitude));

                playerCamera.transform.Translate(correctedCameraTranslateVector);
            }
            else
            {
                playerCamera.transform.Translate(cameraTranslationVector);
            }
        }
    }
}