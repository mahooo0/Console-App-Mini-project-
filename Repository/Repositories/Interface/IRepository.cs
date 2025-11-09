using Domain.Common;

namespace Repository.Repositories.Interface;

public interface IRepository<T> where T : BaseEntity
{
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
    T GetById(Predicate<T> predicate);
    List<T> GetAll();
}