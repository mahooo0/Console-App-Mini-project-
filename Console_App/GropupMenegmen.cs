 using Service.Helper;
 namespace Console_App;
 public class GropupMenegmen
 {
    public void GropupManagementMenu()
    {
        int choice  ;
        bool isRunning = true;
        while (isRunning){
        Console.Clear();
        Helper.Print("Group Management", ConsoleColor.Green);
        Helper.Print(" Choose an option:", ConsoleColor.Green);
        Helper.Print(" 1. Add a group", ConsoleColor.Yellow);
        Helper.Print(" 2. Update a group", ConsoleColor.Yellow);
        Helper.Print(" 3. Delete a group", ConsoleColor.Yellow);
        Helper.Print(" 4. Get a group by id", ConsoleColor.Yellow);
        Helper.Print(" 5. Get a group by name", ConsoleColor.Yellow);
        Helper.Print(" 6. Get a group by teacher", ConsoleColor.Yellow);
        Helper.Print(" 7. Get a group by room", ConsoleColor.Yellow);
        Helper.Print(" 8. Search a group by name or teacher or room", ConsoleColor.Yellow); 
        Helper.Print(" 9. Get all groups", ConsoleColor.Yellow);
        Helper.Print(" 10. Exit", ConsoleColor.Yellow);
        choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                isRunning = false;
                break;
            default:
                Helper.Print("Invalid choice", ConsoleColor.Red);
                break;
        }
    }
 }}