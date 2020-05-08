using System;
using System.Collections.Generic;
using P03_StudentSystem.Entities;

namespace P03_StudentSystem
{
    public class StudentData
    {
        public Dictionary<string, Student> Students { get; } = new Dictionary<string, Student>();


        public string GetDetails(string name)
        {
            if (!this.Students.ContainsKey(name)) return null;

            var student = this.Students[name];

            return student.ToString();

        }

        public void Add(string name, int age, double grade)
        {
            if (!this.Students.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                this.Students[name] = student;
            }
        }
    }
}