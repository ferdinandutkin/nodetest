namespace nodetest.Models.Nodes;

public class EndNode : NodeBase
{
    private static readonly Guid TypeIdImplementation = Guid.NewGuid();
        
    public override Guid TypeId => TypeIdImplementation;

    protected override void InitializeOutputs()
    {
        Outputs = new OutputCollection(this, true);
    }
}