namespace Org.Ethasia.Adventuregrid.Core.Items
{
    public class BodyArmor : Equipment
    {
        public override bool CanFitInMainHandSlot()
        {
            return false;
        }

        public override bool CanFitInOffHandSlot()
        {
            return false;
        }

        public override bool CanFitInHeadSlot()
        {
            return false;
        }

        public override bool CanFitInChestSlot()
        {
            return true;
        }

        public override bool CanFitInLegSlot()
        {
            return false;
        }

        public override bool CanFitInFeetSlot()
        {
            return false;
        }

        public override bool CanFitInHandsSlot()
        {
            return false;
        }

        public override bool CanFitInLeftRingSlot()
        {
            return false;
        }

        public override bool CanFitInRightRingSlot()
        {
            return false;
        }

        public override bool CanFitInAmuletSlot()
        {
            return false;
        }
    }
}