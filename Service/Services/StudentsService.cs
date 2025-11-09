using Domain.Models;
using Service.Services.Interfaces;
using Repository.Repositories;

namespace Service.Services;

public class StudentsService : IStudentsService
{
    private readonly StudentsRepository _studentsRepository;
    static int Count = 0;
    
    public StudentsService(StudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }

    public Student Add(Student student)
    {
        Count++;
        student.Id = Count;
        student.CreatedAt = DateTime.Now;
        student.UpdatedAt = DateTime.Now;
        _studentsRepository.Add(student);
        return student;
    }
    
    public Student Update(int id, Student student)
    {
        throw new NotImplementedException();
    }
    
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
    
    public Student Get(Predicate<Student> predicate)
    {
        throw new NotImplementedException();
    }
    
    public List<Student> GetAll()
    {
        throw new NotImplementedException();
    }
    
    public Student Patch(Predicate<Student> predicate, Dictionary<string, object> data)
    {
        throw new NotImplementedException();
    }
}