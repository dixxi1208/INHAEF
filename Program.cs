using EntityFrameworkCoreINHA;
using EntityFrameworkCoreINHA.Context;

public static class MainClass
{
    public static void Main()
    {
        var db = new DbService();
        var studentAges = db.JoinStudentsMethod();

        Console.WriteLine("");
    }
}