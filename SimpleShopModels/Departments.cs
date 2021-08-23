using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShopModels
{
    public class Departments
    {
        public int DepartmentId { get; set; }

        public string DepartmenName { get; set; }

        public List<Employees> employees { get; set; }

        // Constructor, takes name and price
        public Departments(string name) 
        {
            DepartmenName = name;
        }

        // Constructor, takes: id
        public Departments(int id)
        {
            DepartmentId = id;
        }
    }
}
