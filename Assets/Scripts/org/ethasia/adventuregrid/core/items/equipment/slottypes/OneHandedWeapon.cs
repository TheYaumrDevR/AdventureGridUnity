namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Slottypes
{
    public class OneHandedWeapon : EquipmentSlotType
    {
        public override bool CanFitInMainHandSlot()
        {
            return true;
        }

        public override bool CanFitInOffHandSlot()
        {
            return true;
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