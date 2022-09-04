using System.Collections.Generic;

namespace nodetest.Models;


public interface IConnectionCollection : ICollection<IConnection>
{
    bool CanAdd(IConnection connection);
}

