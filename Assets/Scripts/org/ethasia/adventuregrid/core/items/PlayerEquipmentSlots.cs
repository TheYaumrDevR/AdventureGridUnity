namespace Org.Ethasia.Adventuregrid.Core.Items
{
    public class PlayerEquipmentSlots
    {
        private EquipmentBase mainHandSlotEquipment;
        private EquipmentBase offHandEquipmentSlot;
        private EquipmentBase headEquipmentSlot;
        private EquipmentBase chestEquipmentSlot;
        private EquipmentBase legsEquipmentSlot;
        private EquipmentBase feetEquipmentSlot;
        private EquipmentBase handsEquipmentSlot;
        private EquipmentBase leftRingEquipmentSlot;
        private EquipmentBase rightRingEquipmentSlot;
        private EquipmentBase amuletEquipmentSlot;

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

        public EquipmentBase GetEquipmentInMainHand()
        {
            return mainHandSlotEquipment;
        }

        public EquipmentBase GetEquipmentInOffHand()
        {
            return offHandEquipmentSlot;
        }      

        public EquipmentBase GetEquipmentOnHead()
        {
            return headEquipmentSlot;
        }  

        public EquipmentBase GetEquipmentOnChest()
        {
            return chestEquipmentSlot;
        }

        public EquipmentBase GetEquipmentOnLegs()
        {
            return legsEquipmentSlot;
        }

        public EquipmentBase GetEquipmentOnFeet()
        {
            return feetEquipmentSlot;
        }

        public EquipmentBase GetEquipmentOnHands()
        {
            return handsEquipmentSlot;
        }

        public EquipmentBase GetEquipmentOnLeftRing()
        {
            return leftRingEquipmentSlot;
        }     

        public EquipmentBase GetEquipmentOnRightRing()
        {
            return rightRingEquipmentSlot;
        }   

        public EquipmentBase GetEquipmentOnAmulet()
        {
            return amuletEquipmentSlot;
        }        

        public void EquipInMainHand(EquipmentBase value)
        {
            if (value.CanFitInMainHandSlot())
            {
                mainHandSlotEquipment = value;
            }            
        }

        public void EquipInOffHand(EquipmentBase value)
        {
            if (value.CanFitInOffHandSlot())
            {
                offHandEquipmentSlot = value;
            }            
        }

        public void EquipInHead(EquipmentBase value)
        {
            if (value.CanFitInHeadSlot())
            {
                headEquipmentSlot = value;
            }
        }     

        public void EquipInChest(EquipmentBase value)
        {
            if (value.CanFitInChestSlot())
            {
                chestEquipmentSlot = value;
            }
        }   

        public void EquipInLegs(EquipmentBase value)
        {
            if (value.CanFitInLegSlot())
            {
                legsEquipmentSlot = value;
            }
        }

        public void EquipInFeet(EquipmentBase value)
        {
            if (value.CanFitInFeetSlot())
            {
                feetEquipmentSlot = value;
            }
        }

        public void EquipInHands(EquipmentBase value)
        {
            if (value.CanFitInHandsSlot())
            {
                handsEquipmentSlot = value;
            }            
        }

        public void EquipInLeftRing(EquipmentBase value)
        {
            if (value.CanFitInLeftRingSlot())
            {
                leftRingEquipmentSlot = value;
            }            
        }

        public void EquipInRightRing(EquipmentBase value)
        {
            if (value.CanFitInRightRingSlot())
            {
                rightRingEquipmentSlot = value;
            }            
        }

        public void EquipInAmulet(EquipmentBase value)
        {
            if (value.CanFitInAmuletSlot())
            {   
                amuletEquipmentSlot = value;
            }      
        }                
    }
}