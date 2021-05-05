namespace Org.Ethasia.Adventuregrid.Core.Items
{

    public class EmptyArmament : Armament
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
            return 0;
        }

        public override int GetAddedMaximumPhysicalDamage()
        {
            return 0;
        }        
    }
}