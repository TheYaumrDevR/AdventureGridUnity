using UnityEngine;

namespace Org.Ethasia.Adventuregrid.Technical.Inputcontrols
{
    public class PlayerCameraInputControl : MonoBehaviour
    {
        [SerializeField]
        private Camera playerCamera;

        private Vector3 previousCursorViewportPosition;

        // TODO: make camera attached to player
        // TODO: move logic to layer below
        // TODO: make camera terrain unpassable
        // TODO: make camera unflippable

        void Update()
        {
            if (Input.GetMouseButtonDown(InputControlConstants.LEFT_MOUSE_BUTTON)) 
            {
                Cursor.visible = false;
                previousCursorViewportPosition = playerCamera.ScreenToViewportPoint(Input.mousePosition);
            }
            else if (Input.GetMouseButton(InputControlConstants.LEFT_MOUSE_BUTTON))
            {
                Cursor.visible = false;

                Vector3 cursorDragDirection = previousCursorViewportPosition - playerCamera.ScreenToViewportPoint(Input.mousePosition);

                // playerCamera.transform.localPosition = Vector3.zero;
                playerCamera.transform.localPosition = new Vector3(150, 65, 94);

                playerCamera.transform.Rotate(Vector3.right, cursorDragDirection.y * 180);
                playerCamera.transform.Rotate(Vector3.up, -cursorDragDirection.x * 180, Space.World);
                playerCamera.transform.Translate(new Vector3(0, 2, -4));

                previousCursorViewportPosition = playerCamera.ScreenToViewportPoint(Input.mousePosition);
            }
            else
            {
                // TODO: move cursor back into window
                Cursor.visible = true;
            }
        }
    }
}