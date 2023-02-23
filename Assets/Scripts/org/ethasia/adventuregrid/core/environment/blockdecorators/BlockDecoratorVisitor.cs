namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public interface BlockDecoratorVisitor
    {
        void Accept(RotationDataBlockDecorator visited);
    }
}