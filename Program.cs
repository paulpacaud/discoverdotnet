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

        using (Image image = Image.Load("foo.jpg"))
        {
            // Resize the image in place and return it for chaining.
            // 'x' signifies the current image processing context.
            image.Mutate(x => x.Resize(image.Width / 2, image.Height / 2));

            // The library automatically picks an encoder based on the file extension then
            // encodes and write the data to disk.
            // You can optionally set the encoder to choose.
            image.Save("bar.jpg");
        } // Dispose - releasing memory into a memory pool ready for the next image you wish to process.
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
