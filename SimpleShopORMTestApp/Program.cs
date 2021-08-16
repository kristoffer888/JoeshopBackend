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

            List<Product> products = ORM.GetProducts();
            foreach (var product in products) 
            {
                Console.WriteLine(product.ProductName + " " + product.ProductPrice);
            }

            //// Get customer by id
            //Customer cust1 = ORM.GetCustomer(2);
            //Console.WriteLine(cust1.CustomerName);

            //Console.WriteLine();
            //Console.WriteLine();

            //// Get all customers
            //List <Customer> customers = ORM.GetCustomers();
            //foreach (var customer in customers)
            //{
            //    Console.WriteLine(customer.CustomerName);
            //}
        }
    }
}
