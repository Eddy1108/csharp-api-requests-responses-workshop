using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository<T>
    {
        T Insert(T entity);
        IEnumerable<T> Get();
        T Update(T entity);
        T Delete(int id);
        T GetById(object id);
        void Save();
    }
}
