using System.Collections.Generic;

namespace Games.Core
{
    public interface IInventory
    {
        List<IItem> Items { get; }
        void Add(IItem item);
        void Remove(IItem item);
        void Transfer(IItem item, IInventory inventory);
        bool Empty { get; }
        List<T> GetListOfType<T>();
    }
}