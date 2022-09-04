namespace nodetest.Models;

public abstract class NodeBase : INode
{
    public Guid Id { get; } = Guid.NewGuid();
    public abstract Guid TypeId { get; }
    public IInputConnectionCollection Inputs { get; protected set; } = null!;
    public IOutputConnectionCollection Outputs { get; protected set; } = null!;

    protected virtual void InitializeInputs()
    {
        Inputs = new InputCollection(this);
    }

    protected virtual void InitializeOutputs()
    {
        Outputs = new OutputCollection(this);
    }
    private void InitializeConnections()
    {
        InitializeInputs();
        InitializeOutputs();
    }

    protected NodeBase()
    {
        InitializeConnections();
    }

    public bool Equals(INode? other)
    {
        return other is not null && Id.Equals(other.Id) && TypeId.Equals(other.TypeId);
    }

    public override bool Equals(object? obj)
    {
        return obj is INode node && Equals(node);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, TypeId);
    }
}


// bool CanAttachInput(INode node);
//         
// bool CanAttachOutput()