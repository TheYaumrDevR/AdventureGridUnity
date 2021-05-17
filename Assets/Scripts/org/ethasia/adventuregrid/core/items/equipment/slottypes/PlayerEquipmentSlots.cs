namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Slottypes
{
    public class PlayerEquipmentSlots
    {
        private EquipmentSlotType mainHandSlotEquipment;
        private EquipmentSlotType offHandEquipmentSlot;
        private EquipmentSlotType headEquipmentSlot;
        private EquipmentSlotType chestEquipmentSlot;
        private EquipmentSlotType legsEquipmentSlot;
        private EquipmentSlotType feetEquipmentSlot;
        private EquipmentSlotType handsEquipmentSlot;
        private EquipmentSlotType leftRingEquipmentSlot;
        private EquipmentSlotType rightRingEquipmentSlot;
        private EquipmentSlotType amuletEquipmentSlot;

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

        public EquipmentSlotType GetEquipmentInMainHand()
        {
            return mainHandSlotEquipment;
        }

        public EquipmentSlotType GetEquipmentInOffHand()
        {
            return offHandEquipmentSlot;
        }      

        public EquipmentSlotType GetEquipmentOnHead()
        {
            return headEquipmentSlot;
        }  

        public EquipmentSlotType GetEquipmentOnChest()
        {
            return chestEquipmentSlot;
        }

        public EquipmentSlotType GetEquipmentOnLegs()
        {
            return legsEquipmentSlot;
        }

        public EquipmentSlotType GetEquipmentOnFeet()
        {
            return feetEquipmentSlot;
        }

        public EquipmentSlotType GetEquipmentOnHands()
        {
            return handsEquipmentSlot;
        }

        public EquipmentSlotType GetEquipmentOnLeftRing()
        {
            return leftRingEquipmentSlot;
        }     

        public EquipmentSlotType GetEquipmentOnRightRing()
        {
            return rightRingEquipmentSlot;
        }   

        public EquipmentSlotType GetEquipmentOnAmulet()
        {
            return amuletEquipmentSlot;
        }        

        public void EquipInMainHand(EquipmentSlotType value)
        {
            if (value.CanFitInMainHandSlot())
            {
                mainHandSlotEquipment = value;
            }            
        }

        public void EquipInOffHand(EquipmentSlotType value)
        {
            if (value.CanFitInOffHandSlot())
            {
                offHandEquipmentSlot = value;
            }            
        }

        public void EquipInHead(EquipmentSlotType value)
        {
            if (value.CanFitInHeadSlot())
            {
                headEquipmentSlot = value;
            }
        }     

        public void EquipInChest(EquipmentSlotType value)
        {
            if (value.CanFitInChestSlot())
            {
                chestEquipmentSlot = value;
            }
        }   

        public void EquipInLegs(EquipmentSlotType value)
        {
            if (value.CanFitInLegSlot())
            {
                legsEquipmentSlot = value;
            }
        }

        public void EquipInFeet(EquipmentSlotType value)
        {
            if (value.CanFitInFeetSlot())
            {
                feetEquipmentSlot = value;
            }
        }

        public void EquipInHands(EquipmentSlotType value)
        {
            if (value.CanFitInHandsSlot())
            {
                handsEquipmentSlot = value;
            }            
        }

        public void EquipInLeftRing(EquipmentSlotType value)
        {
            if (value.CanFitInLeftRingSlot())
            {
                leftRingEquipmentSlot = value;
            }            
        }

        public void EquipInRightRing(EquipmentSlotType value)
        {
            if (value.CanFitInRightRingSlot())
            {
                rightRingEquipmentSlot = value;
            }            
        }

        public void EquipInAmulet(EquipmentSlotType value)
        {
            if (value.CanFitInAmuletSlot())
            {   
                amuletEquipmentSlot = value;
            }      
        }                
    }
}