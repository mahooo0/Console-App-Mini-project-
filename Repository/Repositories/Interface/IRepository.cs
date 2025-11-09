 public interface IRepository<T> where T : BaseEntity
{
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
    T GetById(Predicate<T> predicate);
    List<T> GetAll();
    void Patch(Predicate<T> predicate, Dictionary<string, object> data);
    
}