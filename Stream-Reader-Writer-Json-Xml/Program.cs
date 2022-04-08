using Newtonsoft.Json;
using System;
using System.IO;

namespace Stream_Reader_Writer_Json_Xml
{
    internal class Program
    {
        public enum Choice { AddEmployee = 1, GetEmployeeById, RemoveEmployee, Quit = 0 }
        static void Main(string[] args)
        {




            if (!File.Exists(@"C:\Users\Clean__Laptop\Desktop\Stream-Reader-Writer-Json-Xml\Stream-Reader-Writer-Json-Xml\Files\Database.json"))
            {
                File.Create(@"C:\Users\Clean__Laptop\Desktop\Stream-Reader-Writer-Json-Xml\Stream-Reader-Writer-Json-Xml\Files\Database.json");
            }

            Department department = new Department("Departament");
            while (true)
            {
                Console.WriteLine($"1.Add employee\n2.Get employee by id\n3.Remove employee\n0.Quit");
                int num = int.Parse(Console.ReadLine());
                switch (num)
                {
                    case (int)Choice.AddEmployee:
                        Employee employee = new Employee(GetInputStr("Write Name:"), GetInputInt("Write Salary:"));


                        department.AddEmployee(employee);
                        string result = JsonConvert.SerializeObject(department);
                        string path = @"C:\Users\Clean__Laptop\Desktop\Stream-Reader-Writer-Json-Xml\Stream-Reader-Writer-Json-Xml\Files\Database.json";
                        using (StreamWriter stream = new StreamWriter(path))
                        {
                            stream.Write(result);
                        }

                        break;
                    case (int)Choice.GetEmployeeById:
                        Console.WriteLine("Id daxil edin");
                        int id = int.Parse(Console.ReadLine());
                        department.GetEmployeeById(id);
                        break;
                    case (int)Choice.RemoveEmployee:
                        Console.WriteLine("Id daxil edin");
                        int Id = int.Parse(Console.ReadLine());
                        department.RemoveEmployee(Id);
                        break;
                    case (int)Choice.Quit:
                        Environment.Exit(0);
                        break;

                }

            }

        }
        static string GetInputStr(string sentence)
        {

            string input;
            Console.Write(sentence);
            input = Console.ReadLine();
            return input;

        }
        static double GetInputInt(string sentence)
        {
            double input;
            Console.Write(sentence);
            input = Convert.ToInt32(Console.ReadLine());

            return input;
        }
    }
}
