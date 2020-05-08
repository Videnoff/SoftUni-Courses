using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Engine
    {
        private const int MAX_CAPACITY = 3;

        private readonly List<Department> departments;
        private readonly List<Doctor> doctors;

        private Engine()
        {
            this.departments = new List<Department>();
            this.doctors = new List<Doctor>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] tokens = command.Split();
                string departmentName = tokens[0];
                string doctorFirstName = tokens[1];
                string doctorLastName = tokens[2];
                string doctorFullName = doctorFirstName + doctorLastName;
                string patientName = tokens[3];

                if (!this.DoctorExist(doctorFullName))
                {
                    this.doctors.Add(new Doctor(doctorFirstName, doctorLastName));
                }
                if (!this.DepartmentExists(departmentName))
                {
                    this.departments.Add(new Department(departmentName));
                }

                Department department = this.departments.FirstOrDefault(d => d.Name == departmentName);

                Doctor doctor = this.doctors.FirstOrDefault(d => d.FullName == doctorFullName);

                bool isFree = department.Rooms.Any(r => r.Count < MAX_CAPACITY);

                if (isFree)
                {
                    Room firstFreeRoom = department.GetFirstFreeRoom();

                    Patient patient = new Patient(patientName);

                    firstFreeRoom.AddPatient(patient);
                    doctor.AddPatientToDoctor(patient);

                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Room[] rooms = (Room[])this.departments
                        .FirstOrDefault(d => d.Name == command)
                        .Rooms;

                    foreach (var room in rooms)
                    {
                        Console.WriteLine(room);
                    }
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int roomNum))
                {
                    Room room = this.departments.FirstOrDefault(d => d.Name == command).Rooms
                        .FirstOrDefault(r => r.Number == roomNum);

                    string[] output = room.ToString().Split(Environment.NewLine).OrderBy(r => r).ToArray();

                    foreach (var patient in output)
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    string doctorFullName = args[0] + args[1];

                    Doctor doctor = this.doctors.FirstOrDefault(d => d.FullName == doctorFullName);
                }
                command = Console.ReadLine();
            }
        }

        private bool DoctorExist(string fullName)
        {
            bool exists = this.doctors.Any(d => d.FullName == fullName);

            return exists;
        }

        private bool DepartmentExists(string name)
        {
            bool exists = this.departments.Any(d => d.Name == name);

            return exists;
        }
    }
}
