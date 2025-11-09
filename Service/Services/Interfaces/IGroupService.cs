using Domain.Models;

namespace Service.Services.Interfaces;

public interface IGroupService
{
    Group Add(Group group);
    Group Update(int id, Group group);
    void Delete(int id);
    Group GetById(int id);
    List<Group> GetAll();
    List<Group> GetAll(Predicate<Group> predicate);
    void AddStudentToGroup(int groupId, int studentId, StudentsService studentsService);
}