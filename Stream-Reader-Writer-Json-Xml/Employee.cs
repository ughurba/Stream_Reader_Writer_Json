using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stream_Reader_Writer_Json_Xml
{
    public class Employee
    {
        public static  int id { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public Employee(string name , double salary)
        {
            Name = name;
            Salary = salary;
            id++;
            Id = id;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Id:{Id}\nName:{Name}\nSalary:{Salary}");
        }
    }
}
