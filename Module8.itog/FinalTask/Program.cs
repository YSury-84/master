using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream("C:\\Temp\\Students.dat", FileMode.OpenOrCreate))
            {
                var student = (List<Student>)formatter.Deserialize(fs);//Ошибка десереализации!!!
            }

        }

        [Serializable] // Для сериализации студент должен был добавить в класс этот атрибут
        class Student
        {
            public string Name { get; set; }
            public string Group { get; set; }
            public DateTime DateOfBirth { get; set; }
            public Student(string name, string group, DateTime dateOfBirth)
            {
                Name = name;
                Group = group;
                DateOfBirth = dateOfBirth;
            }
        }

    }
}