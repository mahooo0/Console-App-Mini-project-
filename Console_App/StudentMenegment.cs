using Service.Helper;
using Service.Services;
using Domain.Models;

namespace Console_App;

public class StudentMenegment
{
    private readonly StudentsService studentsService;
    private readonly GroupService groupService;
    
    public StudentMenegment(StudentsService studentsService, GroupService groupService)
    {
        this.studentsService = studentsService;
        this.groupService = groupService;
    }
    
    public void StudentManagementMenu()
    {
        int choice;
        bool isRunning = true;

        while (isRunning){

        Console.Clear();
        Helper.Print("Student Management", ConsoleColor.Green);
        Helper.Print(" Choose an option:", ConsoleColor.Green);
        Helper.Print(" 1. Add a student", ConsoleColor.Yellow);
        Helper.Print(" 2. Update a student", ConsoleColor.Yellow);
        Helper.Print(" 3. Delete a student", ConsoleColor.Yellow);
        Helper.Print(" 4. Get a student by id", ConsoleColor.Yellow);
        Helper.Print(" 5. Get a student by name", ConsoleColor.Yellow);
        Helper.Print(" 6. Get a student by age", ConsoleColor.Yellow);
        Helper.Print(" 7. Get students by group id", ConsoleColor.Yellow);
        Helper.Print(" 8. Get all students", ConsoleColor.Yellow);
        Helper.Print(" 9. Search a student by name or surname", ConsoleColor.Yellow);
        Helper.Print(" 10. Add student to group", ConsoleColor.Yellow);
        Helper.Print(" 11. Exit", ConsoleColor.Yellow);
        choice = Helper.GetIntInput();
        switch (choice)
        {
            case 1:
                {
                    string name = Helper.GetStringInput("Enter student name:");
                    string surname = Helper.GetStringInput("Enter student surname:");
                    Console.WriteLine("Enter student age:");
                    int age = Helper.GetIntInput();
                    Student student = new Student { Name = name, Surname = surname, Age = age };
                    studentsService.Add(student);
                    Console.Clear();
                    Helper.Print("Student added successfully!", ConsoleColor.Green);
                    Helper.ShowObject(student);
                    Console.ReadKey();
                    Console.Clear();

                    break;
                }
            case 2:
                {
                    Console.WriteLine("Enter student id:");
                    int id = Helper.GetIntInput();
                    Student student1 = studentsService.Get(s => s.Id == id);
                    if (student1 == null)
                    {
                        Helper.Print("Student not found!", ConsoleColor.Red);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    string name = Helper.GetOptionalStringInput("Enter student name", student1.Name);
                    string surname = Helper.GetOptionalStringInput("Enter student surname", student1.Surname);
                    int age = Helper.GetOptionalIntInput("Enter student age", student1.Age);
                    Student student = new Student {  Name = name, Surname = surname, Age = age };
                    studentsService.Update(id, student);
                    Console.Clear();
                    Helper.Print("Student updated successfully!", ConsoleColor.Green);
                    Helper.ShowObject(student);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            case 3:
                {
                    Console.WriteLine("Enter student id:");
                    int id = Helper.GetIntInput();
                    Student student1 = studentsService.Get(s => s.Id == id);
                    if (student1 == null)
                    {
                        Helper.Print("Student not found!", ConsoleColor.Red);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }                    studentsService.Delete(id);

                    Console.Clear();
                    Helper.Print("Student deleted successfully!", ConsoleColor.Green);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            case 4:
                {
                    Console.WriteLine("Enter student id:");
                    int id = Helper.GetIntInput();
                    Student student1 = studentsService.Get(s => s.Id == id);
                    if (student1 == null)
                    {
                        Helper.Print("Student not found!", ConsoleColor.Red);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    Student student = studentsService.Get(s => s.Id == id);
                    Console.Clear();
                    Helper.ShowObject(student);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            case 5:
                {
                    string name = Helper.GetStringInput("Enter student name:");
                    Student student = studentsService.Get(s => s.Name == name);
                    Console.Clear();
                    Helper.ShowObject(student);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            case 6:
                {
                    Console.WriteLine("Enter student age:");
                    int age = Helper.GetIntInput();
                    Student student = studentsService.Get(s => s.Age == age);
                    Console.Clear();
                    Helper.ShowObject(student);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            case 7:
                {
                    Console.WriteLine("Enter group id:");
                    int groupId = Helper.GetIntInput();
                    Student student = studentsService.Get(s => s.GroupId == groupId);
                    Console.Clear();
                    Helper.ShowObject(student);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            case 8:
                {
                    List<Student> students = studentsService.GetAll();
                    Console.Clear();
                    Helper.ShowObjectsInTable(students);
                    Console.ReadKey();
                    Console.Clear();
                        break;
                }
            case 9:
                {
                    string nameOrSurname = Helper.GetStringInput("Enter student name or surname:");
                    List<Student> students = studentsService.GetAll(x => x.Name == nameOrSurname || x.Surname == nameOrSurname);
                    Console.Clear();
                    Helper.ShowObjectsInTable(students);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            case 10:
                {
                    Console.WriteLine("Enter student id:");
                    int studentId = Helper.GetIntInput();
                    Student student1 = studentsService.Get(s => s.Id == studentId);
                    if (student1 == null)
                    {
                        Helper.Print("Student not found!", ConsoleColor.Red);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    Console.WriteLine("Enter group id:");
                    int groupId = Helper.GetIntInput();
                    Group group1 = groupService.GetById(groupId);
                    if (group1 == null)
                    {
                        Helper.Print("Group not found!", ConsoleColor.Red);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    groupService.AddStudentToGroup(groupId, studentId, studentsService);
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
}}