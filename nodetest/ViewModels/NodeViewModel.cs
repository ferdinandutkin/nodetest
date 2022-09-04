using nodetest.Models;

namespace nodetest.ViewModels;

public class NodeViewModel : INode
{
    private readonly INode _node;
    private readonly string _text;
    private readonly INodeCollection _field;
    
    public int Width { get; set; }
    
    public int Height { get; set; }

    public Vector2 Position { get; } = new();

    public NodeViewModel(INode node, string text)
    {
        _node = node;
        _text = text;
    }

    public Guid TypeId => _node.TypeId;

    public Guid Id => _node.Id;

    public IInputConnectionCollection  Inputs => _node.Inputs;

    public IOutputConnectionCollection Outputs => _node.Outputs;
    
    public bool Equals(INode? other)
    {
        return _node.Equals(other);
    }

    public override string ToString()
    {
        return _text;
    }
}