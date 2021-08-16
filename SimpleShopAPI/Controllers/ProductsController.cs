using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimleShopORM;
using SimpleShopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShopAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ORM_MsSql ORM;

        public ProductsController()
        {
            ORM = new ORM_MsSql();
        }


        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            Product product;

            try
            {
                product = ORM.GetProduct(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Something went wrong" + ex.Message);
            }

            if (product == null) return NotFound();

            // 200 ok 
            return product;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            List<Product> products = new();

            try
            {
                products = ORM.GetProducts();
            }
            catch (Exception ex) {
                throw new ArgumentException("Something went wrong" + ex.Message);
            }

            if (products.Count < 1) return NotFound();

            return products;
        }
    }
}
