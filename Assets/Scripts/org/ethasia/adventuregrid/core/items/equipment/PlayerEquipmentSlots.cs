using Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes;

namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment
{
    public class PlayerEquipmentSlots
    {
        private EquipmentClass mainHandEquipment;
        private EquipmentClass offHandEquipment;
        
        public bool IsMainHandOccupied()
        {
            return mainHandEquipment != null;
        }

        public bool IsOffHandOccupied()
        {
            return offHandEquipment != null;
        }        

        public EquipmentClass GetMainHandEquipment()
        {
            return mainHandEquipment;
        }

        public EquipmentClass GetOffHandEquipment()
        {
            return offHandEquipment;
        }        

        public void EquipInMainHand(EquipmentClass value)
        {
            if (value.CanEquipInMainHand())
            {
                mainHandEquipment = value;
            }
        }

        public void EquipInOffHand(EquipmentClass value)
        {
            if (value.CanEquipInOffHand())
            {
                offHandEquipment = value;
            }
        }        
    }
}