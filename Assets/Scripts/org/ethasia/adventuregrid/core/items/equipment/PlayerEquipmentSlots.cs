using Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes;

namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment
{
    public class PlayerEquipmentSlots
    {
        private EquipmentClass mainHandEquipment;
        private EquipmentClass offHandEquipment;
        private EquipmentClass headEquipment;
        private EquipmentClass chestEquipment;
        private EquipmentClass legEquipment;
        private EquipmentClass feetEquipment;
        private EquipmentClass handsEquipment;
        private EquipmentClass rightRingEquipment;
        private EquipmentClass leftRingEquipment;
        private EquipmentClass amuletEquipment;
        
        public bool IsMainHandOccupied()
        {
            return mainHandEquipment != null;
        }

        public bool IsOffHandOccupied()
        {
            return offHandEquipment != null;
        }        

        public bool IsHeadSlotOccupied()
        {
            return headEquipment != null;
        }

        public bool IsChestSlotOccupied()
        {
            return chestEquipment != null;
        } 

        public bool IsLegSlotOccupied()
        {
            return legEquipment != null;
        } 

        public bool IsFeetSlotOccupied()
        {
            return feetEquipment != null;
        }  

        public bool IsHandsSlotOccupied()
        {
            return handsEquipment != null;
        }

        public bool IsRightRingSlotOccupied()
        {
            return rightRingEquipment != null;
        }    

        public bool IsLeftRingSlotOccupied()
        {
            return leftRingEquipment != null;
        } 

        public bool IsAmuletSlotOccupied()
        {
            return amuletEquipment != null;
        }                                       

        public EquipmentClass GetMainHandEquipment()
        {
            return mainHandEquipment;
        }

        public EquipmentClass GetOffHandEquipment()
        {
            return offHandEquipment;
        }   

        public EquipmentClass GetHeadEquipment()
        {
            return headEquipment;
        } 

        public EquipmentClass GetChestEquipment()
        {
            return chestEquipment;
        }  

        public EquipmentClass GetLegEquipment()
        {
            return legEquipment;
        }

        public EquipmentClass GetFeetEquipment()
        {
            return feetEquipment;
        }  

        public EquipmentClass GetHandsEquipment()
        {
            return handsEquipment;
        }   

        public EquipmentClass GetRightRingEquipment()
        {
            return rightRingEquipment;
        }   

        public EquipmentClass GetLeftRingEquipment()
        {
            return leftRingEquipment;
        }   

        public EquipmentClass GetAmuletEquipment()
        {
            return amuletEquipment;
        }                                                         

        public void EquipInMainHand(EquipmentClass value)
        {
            if (value.CanEquipInMainHand(this))
            {
                mainHandEquipment = value;
            }
        }

        public void EquipInOffHand(EquipmentClass value)
        {
            if (value.CanEquipInOffHand(this))
            {
                offHandEquipment = value;
            }
        }  

        public void EquipOnHead(EquipmentClass value)
        {
            if (value.CanEquipOnHead())
            {
                headEquipment = value;
            }            
        }   

        public void EquipOnChest(EquipmentClass value)
        {
            if (value.CanEquipOnChest())
            {
                chestEquipment = value;
            }            
        }  

        public void EquipOnLegs(EquipmentClass value)
        {
            if (value.CanEquipOnLegs())
            {
                legEquipment = value;
            }            
        }  

        public void EquipOnFeet(EquipmentClass value)
        {
            if (value.CanEquipOnFeet())
            {
                feetEquipment = value;
            }            
        } 

        public void EquipOnHands(EquipmentClass value)
        {
            if (value.CanEquipOnHands())
            {
                handsEquipment = value;
            }            
        }  

        public void EquipOnRightRingSlot(EquipmentClass value)
        {
            if (value.CanEquipOnRightRingSlot())
            {
                rightRingEquipment = value;
            }            
        }   

        public void EquipOnLeftRingSlot(EquipmentClass value)
        {
            if (value.CanEquipOnLeftRingSlot())
            {
                leftRingEquipment = value;
            }            
        }  

        public void EquipOnAmuletSlot(EquipmentClass value)
        {
            if (value.CanEquipOnAmuletSlot())
            {
                amuletEquipment = value;
            }            
        }                                              
    }
}