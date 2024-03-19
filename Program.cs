namespace sample1;
using ClassesNamespace;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person("John", 25);
        person.Hello(true);

        var watch = System.Diagnostics.Stopwatch.StartNew();

        Parallel.ForEach(Directory.EnumerateFiles(@"./data/raw"), 
        (currentFile) => { helper.ResizeImage(currentFile); });

        watch.Stop();
        Console.WriteLine($"Execution Time (Parallel): {watch.ElapsedMilliseconds} ms");

        watch = System.Diagnostics.Stopwatch.StartNew();

        foreach (string currentFile in Directory.EnumerateFiles(@"./data/raw"))
        { helper.ResizeImage(currentFile); }

        watch.Stop();
        Console.WriteLine($"Execution Time (Sequential): {watch.ElapsedMilliseconds} ms");
    }
}

