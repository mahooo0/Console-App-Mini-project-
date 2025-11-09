using Domain.Models;

namespace Service.Services.Interfaces;

public interface IStudentsService
{
    Student Add(Student student);
    Student Update(int id, Student student);
    void Delete(int id);
    Student Get(Predicate<Student> predicate);
    List<Student> GetAll();
    List<Student> GetAll(Predicate<Student> predicate);
}