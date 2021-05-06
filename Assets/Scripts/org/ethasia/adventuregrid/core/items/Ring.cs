namespace Org.Ethasia.Adventuregrid.Core.Items
{
    public class Ring : Equipment
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
            return false;
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
            return true;
        }

        public override bool CanFitInRightRingSlot()
        {
            return true;
        }

        public override bool CanFitInAmuletSlot()
        {
            return false;
        }
    }
}