using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Interfaces.Technical;

namespace Org.Ethasia.Adventuregrid.Ioadapters
{
    public abstract class TechnicalsFactory
    {
        private static TechnicalsFactory instance;

        public static void SetInstance(TechnicalsFactory value)
        {
            instance = value;
        }

        public static TechnicalsFactory GetInstance()
        {
            return instance;
        }

        public abstract ChunkRenderer GetChunkRendererInstance();
        public abstract PlayerRenderer GetPlayerRendererInstance();
    }
}