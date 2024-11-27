using ConsoleApp1.Data;
using ConsoleApp1.Interfaces;

class Program
{
    static void Main(string[] args)
    {
        using var context = new RecipeContext();
        context.Database.EnsureCreated(); // Crée la base de données si elle n'existe pas

        var ihm = new IHM(context);
        ihm.Run();
    }
}
