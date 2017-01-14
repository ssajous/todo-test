using System.Collections.Generic;

namespace TodoTest.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Add(T item);
        void Update(T item);
        T FindById(int id);
        void Delete(int id);
    }
}
