using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JoeShopORM;
using JoeShopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShopAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ORM_MsSql ORM;

        public CustomerController()
        {
            ORM = new ORM_MsSql();
        }

        // Get Customer by id
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            Customer customer;

            try
            {
                customer = ORM.GetCustomer(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Something went wrong" + ex.Message);
            }

            if (customer == null) return NotFound();

            // 200 ok 
            return customer;
        }

        // Get all Customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            List<Customer> customer = new();

            try
            {
                customer = ORM.GetCustomers();
            }
            catch (Exception ex) {
                throw new ArgumentException("Something went wrong" + ex.Message);
            }

            if (customer.Count < 1) return NotFound();

            return customer;
        }

        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            ORM.CreateCustomer(customer);
            return customer;
        }

    }
} 
