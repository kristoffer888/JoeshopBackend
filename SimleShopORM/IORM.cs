using SimpleShopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimleShopORM
{
    public interface IORM
    {
        public List<Customer> GetCustomers();
        public Customer GetCustomer(int id);
        public Customer CreateCustomer(Customer customer);
        public Customer UpdateCustomer(Customer customer);
        public Customer DeleteCustomer(int id);
    }
}
