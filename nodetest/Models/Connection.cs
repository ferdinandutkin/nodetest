namespace nodetest.Models;

public enum Direction {}
class Connection : IConnection
{
    public Connection(INode @from, INode to)
    {
        From = @from;
        To = to;
    }

    public INode From { get; }
    public INode To { get; }

    public override bool Equals(object? obj)
    {
        return obj is IConnection connection && connection.Equals(this);
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(From, To);
    }

    public bool Equals(IConnection? other)
    {
        return other is not null && other.From.Equals(From) && other.To.Equals(To);
    }
}