using SimleShopORM;
using SimpleShopModels;
using System;
using System.Collections.Generic;

namespace SimpleShopORMTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ORM_MsSql ORM = new ORM_MsSql();
            List<Customer> cust1 = ORM.GetCustomers();

            foreach (Customer joe in cust1)
            {
                Console.WriteLine(joe.CustomerName);
            }
        }
    }
}
