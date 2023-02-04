using System;

using Org.Ethasia.Adventuregrid.Core.Environment;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public abstract class BlockUvCoordinates
    {
        public static BlockUvCoordinates FromBlockType(BlockTypes blockType) 
        {
            switch (blockType) 
            {
                case BlockTypes.GRASSY_EARTH:
                    return GrassyEarthBlockUvCoordinates.GetInstance();
                case BlockTypes.EARTH:
                    return EarthBlockUvCoordinates.GetInstance();
                case BlockTypes.ROCK:
                    return RockBlockUvCoordinates.GetInstance(); 
                case BlockTypes.GRAVEL:
                    return GravelBlockUvCoordinates.GetInstance();                       
                case BlockTypes.PORTAL:
                    return PortalBlockUvCoordinates.GetInstance();
                default:
                    throw new NotSupportedException("UV coordinates for block type " + blockType + " not found. Please add them.");
            }
        }

        public abstract float[] GetUvCoordinates();    
        public abstract float[] GetBackUvCoordinates(); 
    }
}