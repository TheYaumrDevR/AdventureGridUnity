namespace Org.Ethasia.Adventuregrid.Core.Items
{
    public abstract class Armament
    {
        public abstract bool CanBeEquippedInMainHand();
        public abstract bool CanBeEquippedInOffHand();
        public abstract int GetAddedMinimumPhysicalDamage();
        public abstract int GetAddedMaximumPhysicalDamage();
    }
}