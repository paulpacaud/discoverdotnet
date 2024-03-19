using Newtonsoft.Json;

namespace ClassesNamespace
{
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
}