namespace nodetest.Models;

public interface INode : IEquatable<INode>
{
    Guid TypeId { get; }
    Guid Id { get; }
       
    IInputConnectionCollection Inputs { get; }
    IOutputConnectionCollection Outputs { get; }

     
}