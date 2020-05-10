using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName { get; internal set; }

        public string LastName { get; internal set; }

        public int Age { get; internal set; }

        public string Gender { get; internal set; }

        public DateTime BirthDate { get; internal set; }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva";
        }

        public void IncreaseSalary(decimal percentage)
        {
            var delimeter = 100;

            if (this.Age < 30)
            {
                delimeter = 200;
            }

            this.Salary += this.Salary * percentage / delimeter;
        }
    }
}
