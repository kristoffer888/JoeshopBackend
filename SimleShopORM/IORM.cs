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
        public Customer DeleteCustomer(Customer customer);


        public List<Manufacturer> GetManufacturers();
        public Manufacturer GetManufacturer(int id);
        public Manufacturer CreateManufacturer(Manufacturer manufacturer);
        public Manufacturer UpdateManufacturer(Manufacturer manufacturer);
        public Manufacturer DeleteManufacturer(Manufacturer manufacturer);
    }
}
