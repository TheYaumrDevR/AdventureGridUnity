using Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes;

namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment
{
    public class PlayerEquipmentSlots
    {
        private EquipmentClass mainHandEquipment;
        
        public bool IsMainHandOccupied()
        {
            return mainHandEquipment != null;
        }

        public EquipmentClass GetMainHandEquipment()
        {
            return mainHandEquipment;
        }

        public void EquipInMainHand(EquipmentClass value)
        {
            mainHandEquipment = value;
        }
    }
}