using UnityEngine;

namespace Org.Ethasia.Adventuregrid.Technical.Inputcontrols
{
    public class PlayerMovementControlRightMouseButton : MonoBehaviour
    {
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
                Quaternion rotationMovement = Quaternion.LookRotation(-movementDirectionVector, Vector3.up);

                playerCharacterRigidBody.MovePosition(currentPlayerCharacterPosition + movementDirectionVector * Time.deltaTime * PLAYER_MOVEMENT_SPEED);
                playerCharacterRigidBody.MoveRotation(rotationMovement);
            }
        }
    }
}