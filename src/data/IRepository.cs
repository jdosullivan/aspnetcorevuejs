using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupClue.Data
{
    public interface IRepository<T> where T : class 
    {
        T Insert(T item);

        Task<T> InsertAsync(T item);

        bool Update(T item);

        bool Remove(T item);

        IEnumerable<T> Find(string query = null);

        Task<IEnumerable<T>> FindAsync(string query = null);

    }
}
