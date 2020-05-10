using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private const int MINIMUM_NAME_LENGTH = 3;

        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get => this.firstName;
            internal set
            {
                CommonValidator.ValidateLength(value, MINIMUM_NAME_LENGTH, nameof(Person), nameof(this.FirstName));
                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            internal set
            {
                CommonValidator.ValidateLength(value, MINIMUM_NAME_LENGTH, nameof(Person), nameof(this.FirstName));
                this.lastName = value;
            }
        }

        public int Age
        {
            get => this.age;
            internal set
            {
                CommonValidator.ValidateMinimum(value, 0, nameof(Person), nameof(Person.Age));
                this.age = value;
            }
        }

        public string Gender { get; internal set; }

        public DateTime BirthDate { get; internal set; }

        public decimal Salary
        {
            get => this.salary;
            set
            {
                CommonValidator.ValidateMinimum(value, 460, nameof(Person), nameof(this.Salary));
                this.salary = value;
            }
        }

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