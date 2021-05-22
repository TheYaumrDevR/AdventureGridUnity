namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class ForceShield : EquipmentClass
    {
        public bool CanEquipInMainHand(PlayerEquipmentSlots otherEquipments)
        {
            return false;
        }

        public bool CanEquipInOffHand(PlayerEquipmentSlots otherEquipments)
        {
            EquipmentClass mainHandEquipment = otherEquipments.GetMainHandEquipment();

            if (null == mainHandEquipment || EquipmentIsOneHandedWeapon(mainHandEquipment))
            {
                return true;
            }

            return false;
        }      

        private bool EquipmentIsOneHandedWeapon(EquipmentClass mainHandEquipment)
        {
            return mainHandEquipment is OneHandedSword 
                || mainHandEquipment is OneHandedMace 
                || mainHandEquipment is Wand;
        }                   
    }
}