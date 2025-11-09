using Service.Helper;
namespace Console_App;
class Program
{
    static void Main(string[] args)
    {
       
        int choice ;
        while (true){
        Console.Clear();
        Helper.Print("hi there!", ConsoleColor.Red);
        Helper.Print(" Choose an option:", ConsoleColor.Green);
        Helper.Print(" 1.Students Management", ConsoleColor.Yellow);
        Helper.Print(" 2.Groups Management", ConsoleColor.Yellow);
        choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                StudentMenegment studentMenegment = new StudentMenegment(); 
                studentMenegment.StudentManagementMenu();
                break;
            case 2:
                GropupMenegmen gropupMenegmen = new GropupMenegmen();
                gropupMenegmen.GropupManagementMenu();
                break;
                default:
                Helper.Print("Invalid choice", ConsoleColor.Red);
                break;
        }
        }
    }
}