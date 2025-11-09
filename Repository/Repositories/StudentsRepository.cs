using Domain.Models;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

public class StudentsRepository : IRepository<Student>
{
    public void Add(Student entity)
    {
        throw new NotImplementedException();
    }
    public void Update(Student entity)
    {
        throw new NotImplementedException();
    }
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
    public Student GetById(Predicate<Student> predicate)
    {
        throw new NotImplementedException();
    }
    public List<Student> GetAll()
    {
        throw new NotImplementedException();
    }
    public void Patch(Predicate<Student> predicate, Dictionary<string, object> data)
    {
        throw new NotImplementedException();
    }
}