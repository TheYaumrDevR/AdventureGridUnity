namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public interface RotationState
    {
        RotationState RotatePositiveAroundXAxis();
        RotationState RotateNegativeAroundXAxis();
        RotationState RotatePositiveAroundYAxis();      
        RotationState RotateNegativeAroundYAxis();
        RotationState RotatePositiveAroundZAxis();      
        RotationState RotateNegativeAroundZAxis();

        RotationStates GetRotationIdentifier();
    }
}