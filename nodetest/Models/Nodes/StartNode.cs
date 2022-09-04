namespace nodetest.Models.Nodes;

public class StartNode : NodeBase
{
    private static readonly Guid TypeIdImplementation = Guid.NewGuid();
        
    public override Guid TypeId => TypeIdImplementation;

    protected override void InitializeInputs()
    {
          Inputs = new InputCollection(this, true);
    }
}