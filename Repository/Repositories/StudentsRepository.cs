using Domain.Models;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

public class StudentsRepository : IRepository<Student>
{
    private readonly List<Student> _students = new List<Student>();
    public void Add(Student entity)
    {
        _students.Add(entity);
    }
    public void Update(Student entity)
    {
        var student = _students.FirstOrDefault(x => x.Id == entity.Id);
        if (student != null)
        {
            student.Name = entity.Name;
            student.Surname = entity.Surname;
            student.Age = entity.Age;
        }
    }
    public void Delete(int id)
    {
        var student = _students.FirstOrDefault(x => x.Id == id);
        if (student != null)
        {
            _students.Remove(student);
        }
    }
    public Student GetById(Predicate<Student> predicate)
    {
        return _students.Find(predicate);
    }
    public List<Student> GetAll()
    {
        return _students;
    }

}