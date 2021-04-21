namespace Org.Ethasia.Adventuregrid.Core.Items
{
    public class OneHandedSword : Armament
    {
        public override bool CanBeEquippedInMainHand()
        {
            return true;
        }

        public override bool CanBeEquippedInOffHand()
        {
            return true;
        }

        public override int GetAddedMinimumPhysicalDamage()
        {
            return 10;
        }

        public override int GetAddedMaximumPhysicalDamage()
        {
            return 20;
        }
    }
}