using System.Collections;

namespace nodetest.Models;

public class ConnectionCollectionBase : IConnectionCollection
{
    private readonly List<IConnection> _nodes = new ();

    public int Count => _nodes.Count;

    public ConnectionCollectionBase(bool isReadOnly = false)
    {
        this.IsReadOnly = isReadOnly;
    }

    public bool IsReadOnly { get; }
    public virtual bool CanAdd(IConnection connection)
    {
        return !IsReadOnly;
    }

    public void Add(IConnection item)
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

    public bool Contains(IConnection item)
    {
        return _nodes.Contains(item);
    }

    public void CopyTo(IConnection[] array, int arrayIndex)
    {
        _nodes.CopyTo(array, arrayIndex);
    }

    public IEnumerator<IConnection> GetEnumerator()
    {
        return _nodes.GetEnumerator();
    }

    public bool Remove(IConnection item)
    {
        return _nodes.Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _nodes.GetEnumerator();
    }
}