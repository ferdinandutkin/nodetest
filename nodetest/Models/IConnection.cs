namespace nodetest.Models;

public interface IConnection : IEquatable<IConnection>
{
    INode From { get; }
    
    INode To { get; }
}