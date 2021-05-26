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
    }
}