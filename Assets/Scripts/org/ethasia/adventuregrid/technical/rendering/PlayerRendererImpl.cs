using UnityEngine;

using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Interfaces.Technical;

namespace Org.Ethasia.Adventuregrid.Technical.Rendering
{
    public class PlayerRendererImpl : MonoBehaviour, PlayerRenderer
    {
        private static PlayerRendererImpl instance;

        [SerializeField]
        private Transform playerTransform;

        void Awake()
        {
            instance = this;
        }

        public static PlayerRenderer GetInstance()
        {
            return instance;
        }      

        public void RenderPlayerAt(BlockPosition renderPosition) 
        {
            float posX = renderPosition.X * 0.5f + 0.25f;
            float posY = renderPosition.Y * 0.5f + 0.125f;
            float posZ = renderPosition.Z * 0.5f + 0.25f;

            playerTransform.position = new Vector3(posX, posY, posZ);
        } 
    }
}