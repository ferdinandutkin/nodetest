namespace nodetest.Models.Nodes;

public class DefaultNode : NodeBase
{
    private static readonly Guid TypeIdImplementation = Guid.NewGuid();
        
    public override Guid TypeId => TypeIdImplementation;
}