using nodetest.Models;
using nodetest.Utils;

namespace nodetest.ViewModels;

public class ConnectionViewModel : IConnection
{
    private readonly IConnection _connection;
    
    public Vector2 FromVector { get; }
    
    public Vector2 ToVector { get; }

    public ConnectionViewModel(IConnection connection,
        Vector2 fromVector, 
        Vector2 toVector)
    {
        _connection = connection;
        FromVector = fromVector;
        ToVector = toVector;
    }

    public bool Equals(IConnection? other)
    {
        return _connection.Equals(other);
    }

    public INode From => _connection.From;

    public INode To => _connection.To;
}