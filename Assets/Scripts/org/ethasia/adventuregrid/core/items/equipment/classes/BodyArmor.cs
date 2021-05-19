namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class BodyArmor : EquipmentClass
    {
        public bool CanEquipInMainHand()
        {
            return false;
        }       

        public bool CanEquipInOffHand()
        {
            return false;
        }            
    }
}