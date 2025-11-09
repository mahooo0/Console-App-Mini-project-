using Domain.Models;
using Service.Services.Interfaces;
using Repository.Repositories;

namespace Service.Services;

public class StudentsService : IStudentsService
{
    private readonly StudentsRepository _studentsRepository;
    static int Count = 0;
    
    public StudentsService()
    {
        _studentsRepository = new StudentsRepository();
    }
    
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
        student.UpdatedAt = DateTime.Now;
        _studentsRepository.Update(student);
        return student;
    }
    
    public void Delete(int id)
    {
        _studentsRepository.Delete(id);
    }
    
    public Student Get(Predicate<Student> predicate)
    {
        return _studentsRepository.GetById(predicate);
    }
    public List<Student> GetAll(Predicate<Student> predicate)
    {
        return _studentsRepository.GetAll(predicate);
    }
    public List<Student> GetAll()
    {
        return _studentsRepository.GetAll();
    }
    
 
}