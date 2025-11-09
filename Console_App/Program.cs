using Service.Helper;
using Service.Services;

namespace Console_App;

class Program
{
    static void Main(string[] args)
    {
        // Создаем общие сервисы для всего приложения
        StudentsService studentsService = new StudentsService();
        GroupService groupService = new GroupService();
        
        int choice;
        
        while (true)
        {
            Console.Clear();
            Helper.Print("Hi there!", ConsoleColor.Red);
            Helper.Print(" Choose an option:", ConsoleColor.Green);
            Helper.Print(" 1. Students Management", ConsoleColor.Yellow);
            Helper.Print(" 2. Groups Management", ConsoleColor.Yellow);
            Helper.Print(" 3. Exit", ConsoleColor.Yellow);
            choice = Helper.GetIntInput();
            
            switch (choice)
            {
                case 1:
                    {
                        StudentMenegment studentMenegment = new StudentMenegment(studentsService, groupService); 
                        studentMenegment.StudentManagementMenu();
                        break;
                    }
                case 2:
                    {
                        GropupMenegmen gropupMenegmen = new GropupMenegmen(studentsService, groupService);
                        gropupMenegmen.GropupManagementMenu();
                        break;
                    }
                case 3:
                    {
                        Helper.Print("Goodbye!", ConsoleColor.Green);
                        return;
                    }
                default:
                    {
                        Helper.Print("Invalid choice", ConsoleColor.Red);
                        Console.ReadKey();
                        break;
                    }
            }
        }
    }
}