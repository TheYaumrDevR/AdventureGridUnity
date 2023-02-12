using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public class SignPlateBlockVisualsBuilder : CuboidBlockVisualsBuilder
    {
        // Base vertices
        private static readonly Vector3f[] BV;

        static SignPlateBlockVisualsBuilder()
        {
            Vector3f[] blockHalfAxes = {
                Vector3f.UNIT_X.ScaleImmutable(BLOCK_HALF_EDGE_LENGTH_IN_ENGINE_UNITS),
                Vector3f.UNIT_Y.ScaleImmutable(0.15f),
                Vector3f.UNIT_Z.ScaleImmutable(0.025f)
            };

            Vector3f origin = new Vector3f(0, 0, 0);

            BV = new Vector3f[] {
                origin.SubtractImmutable(blockHalfAxes[0]).Subtract(blockHalfAxes[1]).Add(blockHalfAxes[2]),
                origin.SubtractImmutable(blockHalfAxes[0]).Add(blockHalfAxes[1]).Add(blockHalfAxes[2]),
                origin.AddImmutable(blockHalfAxes[0]).Add(blockHalfAxes[1]).Add(blockHalfAxes[2]),
                origin.AddImmutable(blockHalfAxes[0]).Subtract(blockHalfAxes[1]).Add(blockHalfAxes[2]),
                origin.AddImmutable(blockHalfAxes[0]).Subtract(blockHalfAxes[1]).Subtract(blockHalfAxes[2]),
                origin.AddImmutable(blockHalfAxes[0]).Add(blockHalfAxes[1]).Subtract(blockHalfAxes[2]),
                origin.SubtractImmutable(blockHalfAxes[0]).Add(blockHalfAxes[1]).Subtract(blockHalfAxes[2]),
                origin.SubtractImmutable(blockHalfAxes[0]).Subtract(blockHalfAxes[1]).Subtract(blockHalfAxes[2])
            };
        }

        public override Vector3f[] GetBaseVertices()
        {
            return BV;
        }
    }
}