using System;
using System.IO;

class FileOperations
{
    public static void WriteToFile(string path, string content)
    {
        File.WriteAllText(path, content);
    }

    public static string ReadFromFile(string path)
    {
        return File.ReadAllText(path);
    }

    public static void DeleteFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            Console.WriteLine("File does not exist.");
        }
    }

    public static bool SearchInFile(string path, string searchTerm)
    {
        if (File.Exists(path))
        {
            string content = File.ReadAllText(path);
            return content.Contains(searchTerm);
        }
        return false;
    }
}

class Program
{
    static void Main()
    {
        string path = "example.txt";
        FileOperations.WriteToFile(path, "Hello, World!");

        Console.WriteLine(FileOperations.ReadFromFile(path));

        if (FileOperations.SearchInFile(path, "World"))
        {
            Console.WriteLine("Search term found.");
        }
        else
        {
            Console.WriteLine("Search term not found.");
        }

        FileOperations.DeleteFile(path);
        Console.WriteLine("File deleted.");
    }
}
