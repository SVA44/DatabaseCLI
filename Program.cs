// See https://aka.ms/new-console-template for more information
using Database_Reprise_;
using System.Data;
Database db = new Database(new string[] {"Hello Database"});
CurrentDir currentDir = new CurrentDir();
ProcessQuery processQuery = new ProcessQuery(currentDir);
currentDir.DirName = db.FirstID;


Console.WriteLine("Welcome to " + db.FirstID);
Console.WriteLine("Type ? to show all possible queries");
Console.WriteLine("Type q to exit the database");

while (true)
{
    Console.Write(currentDir.DirName);
    string query = Console.ReadLine();
    string[] parsedQuery = query.Split(" ");
    if (parsedQuery[0] == "q")
    {
        break;
    }
    string ret = processQuery.Execute(db, parsedQuery);
    Console.WriteLine(ret);
}