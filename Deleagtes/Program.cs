using Deleagtes;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> files = new List<string> { "цйуйцуцу", "йцмйцмйцмйцм", "fйцмйцмйцмцм" };

        var max = files.GetMax(f => f.Length);
        Console.WriteLine($"Максимум длины: {max}");

        DirectorySearcher searcher = new DirectorySearcher();
        searcher.FileFound += OnFileFound;
        searcher.Search("C:\\Users\\Cougar\\Desktop\\soft\\testing");

        Console.ReadLine();
    }

    static void OnFileFound(object sender, FileArgs e)
    {
        Console.WriteLine($"File found: {e.FileName}");

        if (e.FileName.EndsWith("stop.txt"))
        {
            e.Cancel = true;
        }
    }
}