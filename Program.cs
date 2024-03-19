namespace sample1;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person("John", 25);
        person.Hello(true);

        // iterate over the folder data/raw and process each image to data/processed with Parallel.ForEach
        Parallel.ForEach(Directory.EnumerateFiles(@"/Users/paulpacaud/Documents/ASI/INFRA/sample1/data/raw"), (currentFile) =>
        {
            using (Image image = Image.Load(currentFile))
            {
                image.Mutate(x => x.Resize(image.Width / 2, image.Height / 2));
                image.Save(currentFile.Replace("raw", "processed"));
            }
        });
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void Hello(bool isLowercase)
    {
        Console.WriteLine(JsonConvert.SerializeObject(this));
    }
}
