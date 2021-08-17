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
        public List<Product> GetProducts();
        public Product GetProduct(int id);
        public Product CreateProduct(Product product);
    }
}
