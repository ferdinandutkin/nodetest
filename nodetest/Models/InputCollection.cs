namespace nodetest.Models;

public class InputCollection : ConnectionCollectionBase, IInputConnectionCollection
{
    private readonly Predicate<INode>? _canAttachInput;
    private readonly INode _target;

    public InputCollection(INode target, bool isReadOnly = false, Predicate<INode>? canAttachInput = null)
        : base(isReadOnly)
    {
        _target = target;
        _canAttachInput = canAttachInput;
    }
    
    public override bool CanAdd(IConnection connection)
    {
        return base.CanAdd(connection) && connection.To.Equals(_target) && (_canAttachInput?.Invoke(connection.From) ?? true);
    }
}