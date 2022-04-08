using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Stream_Reader_Writer_Json_Xml
{
    public class Department
    {
        public int Id { get; set; }
        public int id { get; set; }
        public string Name { get; set; }

        public List<Employee> employees = new List<Employee>();

        public Department()
        {
            id++;
            Id = id;
        }

        public void AddEmployee(Employee employe)
        {
            employees.Add(employe);

        }
        public void GetEmployeeById(int id)
        {
            string result1;
            string path1 = @"C:\Users\Clean__Laptop\Desktop\Stream-Reader-Writer-Json-Xml\Stream-Reader-Writer-Json-Xml\Files\Database.json";
            using (StreamReader reader = new StreamReader(path1))
            {
                result1 = reader.ReadToEnd();
            }

            Department department1 = JsonConvert.DeserializeObject<Department>(result1);
            foreach (var item in department1.employees)
            {
                if (item.Id == id)
                {
                    Console.WriteLine($"Id:{item.Id}\nName:{item.Name}\nSalary:{item.Salary}");
                }

            }

        }
        public void RemoveEmployee(int id)
        {
            // 3 - cü əməliyyatda isə yenə 2 ci əməliyyatdakı kimi database.json oxunacaq deserialize olunacaq
            //department obyektinə həmin idli employee tapılacaq və listdən silinəcək daha sonra həmin depatment
            //yenidən obyekti serialize olunacaq json-a və database.json file-na yazılacaq.
            string result1;
            string path1 = @"C:\Users\Clean__Laptop\Desktop\Stream-Reader-Writer-Json-Xml\Stream-Reader-Writer-Json-Xml\Files\Database.json";
            using (StreamReader reader = new StreamReader(path1))
            {
                result1 = reader.ReadToEnd();
            }
            Department department2 = JsonConvert.DeserializeObject<Department>(result1);

            foreach (var item in department2.employees)
            {
                employees = department2.employees;
                if (item.Id == id)
                {
                    employees.Remove(item);
                    string result = JsonConvert.SerializeObject(department2);
                    string path = @"C:\Users\Clean__Laptop\Desktop\Stream-Reader-Writer-Json-Xml\Stream-Reader-Writer-Json-Xml\Files\Database.json";
                    using (StreamWriter stream = new StreamWriter(path))
                    {
                        stream.Write(result);
                    }
                    return;
                }
            }

        }
    }


}
