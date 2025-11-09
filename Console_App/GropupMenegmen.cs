using Service.Helper;
using Service.Services;
using Domain.Models;

namespace Console_App;

public class GropupMenegmen
{
    private readonly StudentsService studentsService;
    private readonly GroupService groupService;
    
    public GropupMenegmen(StudentsService studentsService, GroupService groupService)
    {
        this.studentsService = studentsService;
        this.groupService = groupService;
    }
    public void GropupManagementMenu()
    {
        int choice;
        bool isRunning = true;
        
        while (isRunning)
        {
            Console.Clear();
            Helper.Print("Group Management", ConsoleColor.Green);
            Helper.Print(" Choose an option:", ConsoleColor.Green);
            Helper.Print(" 1. Add a group", ConsoleColor.Yellow);
            Helper.Print(" 2. Update a group", ConsoleColor.Yellow);
            Helper.Print(" 3. Delete a group", ConsoleColor.Yellow);
            Helper.Print(" 4. Get a group by id", ConsoleColor.Yellow);
            Helper.Print(" 5. Get a group by name", ConsoleColor.Yellow);
            Helper.Print(" 6. Get a group by teacher", ConsoleColor.Yellow);
            Helper.Print(" 7. Get groups by room", ConsoleColor.Yellow);
            Helper.Print(" 8. Search a group by name or teacher", ConsoleColor.Yellow); 
            Helper.Print(" 9. Get all groups", ConsoleColor.Yellow);
            Helper.Print(" 10. Add a student to a group", ConsoleColor.Yellow); 
            Helper.Print(" 11. Exit", ConsoleColor.Yellow);
            choice = Helper.GetIntInput();
            
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Enter group name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter group teacher:");
                        string teacher = Console.ReadLine();
                        Console.WriteLine("Enter group room:");
                        int room = Helper.GetIntInput();
                        Group group = new Group { Name = name, Teacher = teacher, Room = room };
                        groupService.Add(group);
                        Helper.Print("Group added successfully!", ConsoleColor.Green);
                        Console.Clear();
                        Helper.ShowObject(group);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Enter group id:");
                        int id = Helper.GetIntInput();
                        Console.WriteLine("Enter group name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter group teacher:");
                        string teacher = Console.ReadLine();
                        Console.WriteLine("Enter group room:");
                        int room = Helper.GetIntInput();
                        Group group = new Group { Id = id, Name = name, Teacher = teacher, Room = room };
                        groupService.Update(id, group);
                        Helper.Print("Group updated successfully!", ConsoleColor.Green);
                        Console.Clear();
                            Helper.ShowObject(group);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Enter group id:");
                        int id = Helper.GetIntInput();
                        groupService.Delete(id);
                        Helper.Print("Group deleted successfully!", ConsoleColor.Green);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Enter group id:");
                        int id = Helper.GetIntInput();
                        Group group = groupService.GetById(id);
                        Console.Clear();
                        Helper.ShowObject(group);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Enter group name:");
                        string name = Console.ReadLine();
                        var groups = groupService.GetAll(g => g.Name == name);
                                                    Console.Clear();

                        if (groups.Count > 0)
                        {
                            Helper.ShowObject(groups[0]);
                        }
                        else
                            Helper.Print("Group not found!", ConsoleColor.Red);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Enter group teacher:");
                        string teacher = Console.ReadLine();
                        var groups = groupService.GetAll(g => g.Teacher == teacher);
                        Console.Clear();
                        if (groups.Count > 0)
                            Helper.ShowObjectsInTable(groups);
                        else
                            Helper.Print("Groups not found!", ConsoleColor.Red);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("Enter group room:");
                        int room = Helper.GetIntInput();
                        var groups = groupService.GetAll(g => g.Room == room);
                        Console.Clear();
                        if (groups.Count > 0)
                            Helper.ShowObjectsInTable(groups);
                        else
                            Helper.Print("Groups not found!", ConsoleColor.Red);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                case 8:
                    {
                        Console.WriteLine("Enter group name or teacher:");
                        string searchTerm = Console.ReadLine();
                        var groups = groupService.GetAll(g => g.Name == searchTerm || g.Teacher == searchTerm);
                        Console.Clear();
                        if (groups.Count > 0)
                            Helper.ShowObjectsInTable(groups);
                        else
                            Helper.Print("Groups not found!", ConsoleColor.Red);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                case 9:
                    {
                        List<Group> groups = groupService.GetAll();
                        Console.Clear();
                        Helper.ShowObjectsInTable(groups);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                case 10:
                    {
                        Console.WriteLine("Enter group id:");
                        int groupId = Helper.GetIntInput();
                        Console.WriteLine("Enter student id:");
                        int studentId = Helper.GetIntInput();
                        groupService.AddStudentToGroup(groupId, studentId, studentsService);
                        Console.Clear();
                        Helper.Print("Student added to group successfully!", ConsoleColor.Green);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                case 11:
                    isRunning = false;
                    Console.Clear();
                    break;
                default:
                    Helper.Print("Invalid choice", ConsoleColor.Red);
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
    }
}
