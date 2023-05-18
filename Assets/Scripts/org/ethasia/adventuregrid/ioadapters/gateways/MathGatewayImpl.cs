using UnityEngine;

using Org.Ethasia.Adventuregrid.Interactors.Output;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Gateways 
{
    public class MathGatewayImpl : MathGateway
    {
        public int CeilToInt(float f)
        {
            return Mathf.CeilToInt(f);
        }

        public float Pow(float number, float exponent)
        {
            return Mathf.Pow(number, exponent);
        }
    }
}