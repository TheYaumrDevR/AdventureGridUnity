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
            if (value.CanFitInMainHandSlot())
            {
                mainHandSlotEquipment = value;
            }            
        }

        public void EquipInOffHand(Equipment value)
        {
            if (value.CanFitInOffHandSlot())
            {
                offHandEquipmentSlot = value;
            }            
        }

        public void EquipInHead(Equipment value)
        {
            if (value.CanFitInHeadSlot())
            {
                headEquipmentSlot = value;
            }
        }     

        public void EquipInChest(Equipment value)
        {
            if (value.CanFitInChestSlot())
            {
                chestEquipmentSlot = value;
            }
        }   

        public void EquipInLegs(Equipment value)
        {
            if (value.CanFitInLegSlot())
            {
                legsEquipmentSlot = value;
            }
        }

        public void EquipInFeet(Equipment value)
        {
            if (value.CanFitInFeetSlot())
            {
                feetEquipmentSlot = value;
            }
        }

        public void EquipInHands(Equipment value)
        {
            if (value.CanFitInHandsSlot())
            {
                handsEquipmentSlot = value;
            }            
        }

        public void EquipInLeftRing(Equipment value)
        {
            if (value.CanFitInLeftRingSlot())
            {
                leftRingEquipmentSlot = value;
            }            
        }

        public void EquipInRightRing(Equipment value)
        {
            if (value.CanFitInRightRingSlot())
            {
                rightRingEquipmentSlot = value;
            }            
        }

        public void EquipInAmulet(Equipment value)
        {
            if (value.CanFitInAmuletSlot())
            {   
                amuletEquipmentSlot = value;
            }      
        }                
    }
}