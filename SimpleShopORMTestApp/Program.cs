using SimleShopORM;
using SimpleShopModels;
using System;

namespace SimpleShopORMTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ORM_MsSql ORM = new ORM_MsSql();
            Customer cust1 = ORM.GetCustomer(2);
            Console.WriteLine(cust1.CustomerName);
        }
    }
}
