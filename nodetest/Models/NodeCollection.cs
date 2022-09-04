using System.Collections;

namespace nodetest.Models;

public class NodeCollection : INodeCollection
{
    private readonly Predicate<INode>? _canAdd;
    private readonly List<INode> _nodes = new ();

    public int Count => _nodes.Count;

    public NodeCollection(bool isReadOnly = false, Predicate<INode>? canAdd = null)
    {
        _canAdd = canAdd;
        this.IsReadOnly = isReadOnly;
    }

    public bool IsReadOnly { get; }
    public bool CanAdd(INode node)
    {
        return (_canAdd?.Invoke(node) ?? true) && !IsReadOnly;
    }

    public void Add(INode item)
    {
        if (CanAdd(item))
        {
            _nodes.Add(item);
            return;
        }

        throw new InvalidOperationException($"unable to add {item} to node collection");
    }

    public void Clear()
    {
        _nodes.Clear();
    }

    public bool Contains(INode item)
    {
        return _nodes.Contains(item);
    }

    public void CopyTo(INode[] array, int arrayIndex)
    {
        _nodes.CopyTo(array, arrayIndex);
    }

    public IEnumerator<INode> GetEnumerator()
    {
        return _nodes.GetEnumerator();
    }

    public bool Remove(INode item)
    {
        return _nodes.Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _nodes.GetEnumerator();
    }
}