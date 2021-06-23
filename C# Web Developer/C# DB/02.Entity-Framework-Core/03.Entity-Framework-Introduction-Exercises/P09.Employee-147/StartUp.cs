using System;
using System.Linq;
using System.Text;
using SoftUni.Data;

namespace P09.Employee_147
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            var result = GetEmployee147(context);

            Console.WriteLine(result);
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(ep => ep.Project.Name)
                        .OrderBy(pn => pn)
                        .ToList()
                })
                .Single();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var project in employee147.Projects)
            {
                sb.AppendLine(project);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
