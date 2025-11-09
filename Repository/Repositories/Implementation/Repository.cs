public class Repository<T> : IRepository<T> where T : BaseEntity{
    public void Add(T entity){
        throw new NotImplementedException();
    }
    public void Update(T entity){
        throw new NotImplementedException();
    }
    public void Delete(int id){
        throw new NotImplementedException();
    }
    public T GetById(Predicate<T> predicate){
        throw new NotImplementedException();
    }
    public List<T> GetAll(){
        throw new NotImplementedException();
    }
    public void Patch(Predicate<T> predicate, Dictionary<string, object> data){
        throw new NotImplementedException();
    }

}