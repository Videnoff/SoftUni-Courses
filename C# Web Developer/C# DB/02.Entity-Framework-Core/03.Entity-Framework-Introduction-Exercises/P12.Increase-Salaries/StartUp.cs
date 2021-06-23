using System;
using System.Linq;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace P12.Increase_Salaries
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            var result = IncreaseSalaries(context);

            Console.WriteLine(result);
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            IQueryable<Employee> employeesToIncrease = context
                .Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services");

            foreach (var employee in employeesToIncrease)
            {
                employee.Salary += employee.Salary * 0.12m;
            }

            context.SaveChanges();

            var employeesInfo = employeesToIncrease.Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Salary
            })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employeesInfo)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} $({employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
