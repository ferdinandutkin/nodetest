using nodetest.Models;
using nodetest.Utils;

namespace nodetest.ViewModels;

public struct BoundingClientRectPair
{
    public ElementUtils.BoundingClientRect From { get; set; }
    public ElementUtils.BoundingClientRect To { get; set; }
}
public class ConnectionsStorage
{
    private Dictionary<IConnection, BoundingClientRectPair> _connectionsData = new ();

    public IReadOnlyCollection<ConnectionViewModel> Connections => _connections;

    private List<ConnectionViewModel> _connections = new();
    public void AddFrom(IConnection connection, ElementUtils.BoundingClientRect from)
    {
        if (_connectionsData.TryGetValue(connection, out var pair))
        {
            pair.From = from;
            ConnectionCompleted(connection, pair);
            return;
        }

        _connectionsData[connection] = new BoundingClientRectPair() { From = from };
    }
    
    
    public void AddTo(IConnection connection, ElementUtils.BoundingClientRect to)
    {
        if (_connectionsData.TryGetValue(connection, out var pair))
        {
            pair.To = to;
            ConnectionCompleted(connection, pair);
            return;
        }
        _connectionsData[connection] = new BoundingClientRectPair() { To = to };
       
    }

    private void ConnectionCompleted(IConnection connection, BoundingClientRectPair rectPair)
    {
        var connectionViewModel = new ConnectionViewModel(connection, rectPair.From, rectPair.To);
        _connections.Add(connectionViewModel);
        OnConnectionCompleted?.Invoke(connectionViewModel);
    }

    public delegate void ConnectionCompletedHandler(ConnectionViewModel connectionViewModel);
    public event ConnectionCompletedHandler? OnConnectionCompleted;
}