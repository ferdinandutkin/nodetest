using nodetest.Models;
using nodetest.Utils;

namespace nodetest.ViewModels;

public class ConnectionViewModel : IConnection
{
    private readonly IConnection _connection;
    
    public ElementUtils.BoundingClientRect FromRect { get; }
    
    public ElementUtils.BoundingClientRect ToRect { get; }

    public ConnectionViewModel(IConnection connection,
        ElementUtils.BoundingClientRect fromRect, 
        ElementUtils.BoundingClientRect toRect)
    {
        _connection = connection;
        FromRect = fromRect;
        ToRect = toRect;
    }

    public bool Equals(IConnection? other)
    {
        return _connection.Equals(other);
    }

    public INode From => _connection.From;

    public INode To => _connection.To;
}