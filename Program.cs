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

        using (Image image = Image.Load(@"/Users/paulpacaud/Documents/ASI/INFRA/sample1/data/raw/maxresdefault.jpg"))
        {
            image.Mutate(x => x.Resize(image.Width / 2, image.Height / 2));
            image.Save(@"/Users/paulpacaud/Documents/ASI/INFRA/sample1/data/processed/maxresdefault.jpg");
        }
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
        // string message = "hello " + Name + ", you are " + Age.ToString() + "!";
        // if (isLowercase)
        //     Console.WriteLine(message);
        // else
        //     Console.WriteLine(message.ToUpper());

        Console.WriteLine(JsonConvert.SerializeObject(this));
    }
}
