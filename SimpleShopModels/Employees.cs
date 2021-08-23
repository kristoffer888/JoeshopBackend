using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleShopModels
{
    public class Employees
    {
        public int EmployeesId { get; set; }
        public string EmployeesName { get; set; }

        // Constructor, takes name and price
        public Employees(string name) 
        {
            EmployeesName = name;
        }

        // Constructor, takes: id
        public Employees(int id)
        {
            EmployeesId = id;
        }
    }
}
