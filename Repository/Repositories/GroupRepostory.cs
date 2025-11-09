using Domain.Models;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

public class GroupRepostory : IRepository<Group>
{
    private readonly List<Group> _groups = new List<Group>();
    public void Add(Group entity)
    {
        _groups.Add(entity);
    }
    public void Update(Group entity)
    {
        var group = _groups.FirstOrDefault(x => x.Id == entity.Id);
        if (group != null)
        {
            group.Name = entity.Name;
            group.Teacher = entity.Teacher;
            group.Room = entity.Room;
            group.Students = entity.Students;
            group.UpdatedAt = DateTime.Now;
        }
    }
    public void Delete(int id)
    {
        var group = _groups.FirstOrDefault(x => x.Id == id);
        if (group != null)
        {
            _groups.Remove(group);
        }
    }
    public Group GetById(Predicate<Group> predicate)
    {
        return _groups.Find(predicate);
    }
    public List<Group> GetAll(Predicate<Group> predicate)
    {
        return _groups.FindAll(predicate);
    }
    public List<Group> GetAll()
    {
        return _groups;
    }
}