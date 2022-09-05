using nodetest.Models;
using nodetest.Utils;

namespace nodetest.ViewModels;

public struct BoundingClientRectPair
{
    public ElementUtils.BoundingClientRect From { get; set; }
    public ElementUtils.BoundingClientRect To { get; set; }
}

public struct VectorPair
{
    public Vector2 From { get; set; }
    public Vector2 To { get; set; }
}

public class ConnectionsStorage
{
    private Dictionary<IConnection, VectorPair> _connectionsData = new ();
   
    public IReadOnlyCollection<ConnectionViewModel> Connections => _connections;

    private List<ConnectionViewModel> _connections = new();
    public void AddFrom(IConnection connection, Vector2 from)
    {
        if (_connectionsData.TryGetValue(connection, out var pair))
        {
            pair.From = from;
            ConnectionCompleted(connection, pair);
            return;
        }

        _connectionsData[connection] = new VectorPair() { From = from };
    }
    
    
    public void AddTo(IConnection connection, Vector2 to)
    {
        if (_connectionsData.TryGetValue(connection, out var pair))
        {
            pair.To = to;
            ConnectionCompleted(connection, pair);
            return;
        }
        _connectionsData[connection] = new VectorPair() { To = to };
       
    }

    private void ConnectionCompleted(IConnection connection, VectorPair vectorPair)
    {
        var connectionViewModel = new ConnectionViewModel(connection, vectorPair.From, vectorPair.To);
        _connections.Add(connectionViewModel);
        OnConnectionCompleted?.Invoke(connectionViewModel);
    }

    public delegate void ConnectionCompletedHandler(ConnectionViewModel connectionViewModel);
    public event ConnectionCompletedHandler? OnConnectionCompleted;
}