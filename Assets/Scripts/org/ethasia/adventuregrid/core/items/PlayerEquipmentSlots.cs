namespace Org.Ethasia.Adventuregrid.Core.Items
{
    public class PlayerEquipmentSlots
    {
        private Equipment mainHandSlotEquipment;
        private Equipment offHandEquipmentSlot;
        private Equipment headEquipmentSlot;
        private Equipment chestEquipmentSlot;
        private Equipment legsEquipmentSlot;
        private Equipment feetEquipmentSlot;
        private Equipment handsEquipmentSlot;
        private Equipment leftRingEquipmentSlot;
        private Equipment rightRingEquipmentSlot;
        private Equipment amuletEquipmentSlot;

        public PlayerEquipmentSlots()
        {
            mainHandSlotEquipment = new EmptyEquipment();
            offHandEquipmentSlot = new EmptyEquipment();
            headEquipmentSlot = new EmptyEquipment();
            chestEquipmentSlot = new EmptyEquipment();
            legsEquipmentSlot = new EmptyEquipment();
            feetEquipmentSlot = new EmptyEquipment();
            handsEquipmentSlot = new EmptyEquipment();
            leftRingEquipmentSlot = new EmptyEquipment();
            rightRingEquipmentSlot = new EmptyEquipment();
            amuletEquipmentSlot = new EmptyEquipment();
        }

        public bool IsMainHandSlotEmpty()
        {
            return mainHandSlotEquipment is EmptyEquipment;
        }

        public bool IsOffHandSlotEmpty()
        {
            return offHandEquipmentSlot is EmptyEquipment;
        }

        public bool IsHeadSlotEmpty()
        {
            return headEquipmentSlot is EmptyEquipment;
        }

        public bool IsChestSlotEmpty()
        {
            return chestEquipmentSlot is EmptyEquipment;
        }

        public bool IsLegSlotEmpty()
        {
            return legsEquipmentSlot is EmptyEquipment;
        }

        public bool IsFeetSlotEmpty()
        {
            return feetEquipmentSlot is EmptyEquipment;
        }

        public bool IsHandSlotEmpty()
        {
            return handsEquipmentSlot is EmptyEquipment;
        }

        public bool IsLeftRingSlotEmpty()
        {
            return leftRingEquipmentSlot is EmptyEquipment;
        }

        public bool IsRightRingSlotEmpty()
        {
            return rightRingEquipmentSlot is EmptyEquipment;
        }

        public bool IsAmuletSlotEmpty()
        {
            return amuletEquipmentSlot is EmptyEquipment;
        }

        public Equipment GetEquipmentInMainHand()
        {
            return mainHandSlotEquipment;
        }

        public Equipment GetEquipmentInOffHand()
        {
            return offHandEquipmentSlot;
        }      

        public Equipment GetEquipmentOnHead()
        {
            return headEquipmentSlot;
        }  

        public Equipment GetEquipmentOnChest()
        {
            return chestEquipmentSlot;
        }

        public Equipment GetEquipmentOnLegs()
        {
            return legsEquipmentSlot;
        }

        public Equipment GetEquipmentOnFeet()
        {
            return feetEquipmentSlot;
        }

        public Equipment GetEquipmentOnHands()
        {
            return handsEquipmentSlot;
        }

        public Equipment GetEquipmentOnLeftRing()
        {
            return leftRingEquipmentSlot;
        }     

        public Equipment GetEquipmentOnRightRing()
        {
            return rightRingEquipmentSlot;
        }   

        public Equipment GetEquipmentOnAmulet()
        {
            return amuletEquipmentSlot;
        }        

        public void EquipInMainHand(Equipment value)
        {
            mainHandSlotEquipment = value;
        }

        public void EquipInOffHand(Equipment value)
        {
            offHandEquipmentSlot = value;
        }

        public void EquipInHead(Equipment value)
        {
            headEquipmentSlot = value;
        }     

        public void EquipInChest(Equipment value)
        {
            chestEquipmentSlot = value;
        }   

        public void EquipInLegs(Equipment value)
        {
            legsEquipmentSlot = value;
        }

        public void EquipInFeet(Equipment value)
        {
            feetEquipmentSlot = value;
        }

        public void EquipInHands(Equipment value)
        {
            handsEquipmentSlot = value;
        }

        public void EquipInLeftRing(Equipment value)
        {
            leftRingEquipmentSlot = value;
        }

        public void EquipInRightRing(Equipment value)
        {
            rightRingEquipmentSlot = value;
        }

        public void EquipInAmulet(Equipment value)
        {
            amuletEquipmentSlot = value;
        }                
    }
}