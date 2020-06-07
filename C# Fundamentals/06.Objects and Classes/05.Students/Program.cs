using System;
using System.Linq;
using System.Collections.Generic;

namespace Students
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string input;
            List<Student> students = new List<Student>();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] splittedInput = input.Split();

                string firstName = splittedInput[0];
                string lastName = splittedInput[1];
                int age = int.Parse(splittedInput[2]);
                string hometown = splittedInput[3];

                Student student = new Student();

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;
                student.Hometown = hometown;

                students.Add(student);
            }

            string cityName = Console.ReadLine();

            List<Student> filteredStudents = students.Where(s => s.Hometown == cityName).ToList();

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }


            //foreach (Student student in students)
            //{
            //    if (student.Hometown == cityName)
            //    {
            //        Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            //    }
            //}

        }

        class Student
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public int Age { get; set; }

            public string Hometown { get; set; }
        }
    }
}
