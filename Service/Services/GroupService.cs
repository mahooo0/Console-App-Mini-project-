using Domain.Models;
using Service.Services.Interfaces;
using Repository.Repositories;

namespace Service.Services;

public class GroupService : IGroupService
{
    private readonly GroupRepostory _groupRepostory = new GroupRepostory();
    static int Count = 0;
    
    public Group Add(Group group)
    {
        Count++;
        group.Id = Count;
        group.CreatedAt = DateTime.Now;
        group.UpdatedAt = DateTime.Now;
        _groupRepostory.Add(group);
        return group;
    }
    
    public Group Update(int id, Group group)
    {
        _groupRepostory.Update(group);
        return group;
    }
    
    public void Delete(int id)
    {
        _groupRepostory.Delete(id);
    }
    
    public Group GetById(int id)
    {
        return _groupRepostory.GetById(g => g.Id == id);
    }
    
    public List<Group> GetAll()
    {
        return _groupRepostory.GetAll();
    }
    
    public List<Group> GetAll(Predicate<Group> predicate)
    {
        return _groupRepostory.GetAll(predicate);
    }

    public void AddStudentToGroup(int groupId, int studentId, StudentsService studentsService)
    {
        var group = _groupRepostory.GetById(g => g.Id == groupId);
        if(group == null)
        {
            throw new Exception("Group not found");
        }
        var student = studentsService.Get(s => s.Id == studentId);
        if(student == null)
        {
            throw new Exception("Student not found");
        }
        if (group != null && student != null)
        {
            group.Students.Add(student);
            student.GroupId = groupId;
            student.UpdatedAt = DateTime.Now;
            _groupRepostory.Update(group);
            studentsService.Update(studentId, student);
        }
    }
}