using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleShopModels;
using SimleShopORM;
using Microsoft.AspNetCore.Authorization;
using System.Web.Http.Cors;

namespace SupershopAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors(origins: "http://localhost:3000/", headers: "", methods: "")]
    public class ManufacturerController : ControllerBase
    {
        private readonly ORM_MsSql ORM;

        public ManufacturerController()
        {
            ORM = new ORM_MsSql();
        }

        // Get manufacturer by id
        [HttpGet("{id}")]
        public ActionResult<Manufacturer> Get(int id)
        {
            Manufacturer manufacturer;

            try
            {
                manufacturer = ORM.GetManufacturer(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Something went wrong" + ex.Message);
            }

            if (manufacturer == null) return NotFound();

            // 200 ok 
            return manufacturer;
        }

        // Get all
        [HttpGet]
        public ActionResult<IEnumerable<Manufacturer>> Get()
        {
            List<Manufacturer> manufacturers = new();

            try
            {
                manufacturers = ORM.GetManufacturers();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Something went wrong" + ex.Message);
            }

            if (manufacturers.Count < 1) return NotFound();

            // 200 ok 
            return manufacturers;
        }

        // Create
        [HttpPost]
        public ActionResult<Manufacturer> Post([FromBody] Manufacturer manufacturer)
        {
            try
            {
                ORM.CreateManufacturer(manufacturer);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Something went wrong" + ex.Message);
            }

            if (manufacturer == null) return NotFound();

            // 200 ok 
            return manufacturer;
        }

        // Update 
        [HttpPut]
        public ActionResult<Manufacturer> Put([FromBody] Manufacturer manufacturer)
        {
            try
            {
                ORM.UpdateManufacturer(manufacturer);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Something went wrong" + ex.Message);
            }

            if (manufacturer == null) return NotFound();

            // 200 ok 
            return manufacturer;
        }

        // Delete
        [HttpDelete]
        public ActionResult<Manufacturer> Delete([FromBody] Manufacturer manufacturer)
        {
            try
            {
                ORM.DeleteManufacturer(manufacturer);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Something went wrong" + ex.Message);
            }

            if (manufacturer == null) return NotFound();

            // 200 ok 
            return manufacturer;
        }
    }

}