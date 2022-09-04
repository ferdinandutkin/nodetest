namespace nodetest.Models;

public class OutputCollection : ConnectionCollectionBase, IOutputConnectionCollection
{
    private readonly Predicate<INode>? _canAttachOutput;
    private readonly INode _source;

    public OutputCollection(INode source, bool isReadOnly = false, Predicate<INode>? canAttachOutput = null)
        : base(isReadOnly)
    {
        _source = source;
        _canAttachOutput = canAttachOutput;
    }
    
    public override bool CanAdd(IConnection connection)
    {
        return base.CanAdd(connection) && connection.From.Equals(_source) && (_canAttachOutput?.Invoke(connection.To) ?? true);
    }
}