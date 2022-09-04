namespace nodetest.Models;

public interface INodeCollection : ICollection<INode>
{ 
    bool CanAdd(INode node);
}