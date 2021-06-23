using UnityEngine;

namespace Org.Ethasia.Adventuregrid.Technical.Rendering
{

    public class RenderingTypeConverter
    {
        public static Vector3[] ConvertFlatFloatArrayToVector3Array(float[] toConvert)
        {
            Vector3[] result = new Vector3[toConvert.Length / 3];

            for (int i = 0; i < toConvert.Length; i += 3)
            {
                Vector3 groupedFloats = new Vector3(toConvert[i], toConvert[i + 1], toConvert[i + 2]);
                result[i / 3] = groupedFloats;
            }

            return result;
        }

        public static Vector2[] ConvertFlatFloatArrayToVector2Array(float[] toConvert)
        {
            Vector2[] result = new Vector2[toConvert.Length / 2];

            for (int i = 0; i < toConvert.Length; i += 2)
            {
                Vector3 groupedFloats = new Vector3(toConvert[i], toConvert[i + 1]);
                result[i / 2] = groupedFloats;
            }

            return result;
        }        
    }       
}