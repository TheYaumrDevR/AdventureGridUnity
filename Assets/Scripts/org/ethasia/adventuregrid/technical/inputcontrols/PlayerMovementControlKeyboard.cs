using UnityEngine;

using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Ioadapters.Controllers;

namespace Org.Ethasia.Adventuregrid.Technical.Inputcontrols
{
    public class PlayerMovementControlKeyboard : MonoBehaviour
    {
        private const float JUMP_FORCE = 3.3f;
        private static PlayerMovementControlKeyboard instance;

        [SerializeField]
        private Rigidbody playerCharacterRigidBody;

        [SerializeField]
        private Transform playerAvatarTransform;

        private PlayerWithWorldInteractionController playerWithWorldInteractionController;

        public static PlayerMovementControlKeyboard GetInstance()
        {
            return instance;
        }

        void Awake()
        {
            instance = this;
        }

        void FixedUpdate()
        {
            if ((Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space)) && PlayerCharacterIsGrounded()) 
            {
                playerCharacterRigidBody.AddForce(UnityEngine.Vector3.up * JUMP_FORCE, ForceMode.Impulse);
            }
        }

        public bool PlayerCharacterIsGrounded()
        {
            InitializePlayerWithWorldInteractionControllerIfNull();
            Position3 playerAvatarFeetPositionTopRight = new Position3(playerAvatarTransform.position.x + 0.125f, playerAvatarTransform.position.y, playerAvatarTransform.position.z - 0.125f);
            Position3 playerAvatarFeetPositionTopLeft = new Position3(playerAvatarTransform.position.x - 0.125f, playerAvatarTransform.position.y, playerAvatarTransform.position.z - 0.125f);
            Position3 playerAvatarFeetPositionBottomLeft = new Position3(playerAvatarTransform.position.x - 0.125f, playerAvatarTransform.position.y, playerAvatarTransform.position.z + 0.125f);
            Position3 playerAvatarFeetPositionBottomRight = new Position3(playerAvatarTransform.position.x + 0.125f, playerAvatarTransform.position.y, playerAvatarTransform.position.z + 0.125f);
            
            return playerWithWorldInteractionController.TestPlayerIsGrounded(playerAvatarFeetPositionTopRight)
                || playerWithWorldInteractionController.TestPlayerIsGrounded(playerAvatarFeetPositionTopLeft)
                || playerWithWorldInteractionController.TestPlayerIsGrounded(playerAvatarFeetPositionBottomLeft)
                || playerWithWorldInteractionController.TestPlayerIsGrounded(playerAvatarFeetPositionBottomRight);
        }

        private void InitializePlayerWithWorldInteractionControllerIfNull()
        {
            if (null == playerWithWorldInteractionController)
            {
                playerWithWorldInteractionController = ControllersFactory.GetInstance().CreatePlayerWithWorldInteractionController();
            }
        }
    }
}