namespace Repository.Repositories.Exeption;

public class NotFoundExeption : Exception
{
    public NotFoundExeption(string message) : base(message)
    {
        Console.WriteLine(message);
    }
}