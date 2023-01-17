using UnityEngine;

namespace Org.Ethasia.Adventuregrid.Technical.Inputcontrols
{
    public class PlayerMovementControlRightMouseButton : MonoBehaviour
    {
        // TODO: rotate player towards direction
        // TODO: add jumping

        private const float PLAYER_MOVEMENT_SPEED = 1.6f;

        [SerializeField]
        private Transform cameraTransform;

        [SerializeField]
        private Rigidbody playerCharacterRigidBody;

        void FixedUpdate()
        {
            if (Input.GetMouseButton(InputControlConstants.LEFT_MOUSE_BUTTON) && Input.GetMouseButton(InputControlConstants.RIGHT_MOUSE_BUTTON))
            {
                Vector3 currentPlayerCharacterPosition = playerCharacterRigidBody.position;
                Vector3 movementDirectionVector = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z);
                movementDirectionVector.Normalize();

                playerCharacterRigidBody.MovePosition(currentPlayerCharacterPosition + movementDirectionVector * Time.deltaTime * PLAYER_MOVEMENT_SPEED);
            }
        }
    }
}