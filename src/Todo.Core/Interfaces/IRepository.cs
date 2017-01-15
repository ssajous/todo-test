using System.Collections.Generic;

namespace Todo.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Add(T item);
        void Update(T item);
        T FindById(int id);
        void Delete(int id);
    }
}