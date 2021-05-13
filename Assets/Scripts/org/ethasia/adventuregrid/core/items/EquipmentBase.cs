namespace Org.Ethasia.Adventuregrid.Core.Items
{
    public abstract class EquipmentBase
    {
        public abstract bool CanFitInMainHandSlot();
        public abstract bool CanFitInOffHandSlot();
        public abstract bool CanFitInHeadSlot();
        public abstract bool CanFitInChestSlot();
        public abstract bool CanFitInLegSlot();
        public abstract bool CanFitInFeetSlot();
        public abstract bool CanFitInHandsSlot();
        public abstract bool CanFitInLeftRingSlot();
        public abstract bool CanFitInRightRingSlot();
        public abstract bool CanFitInAmuletSlot();
    }
}