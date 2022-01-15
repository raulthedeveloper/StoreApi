using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApi.Models;
using StoreApi.DAL;
using System.Text.Json;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {

        CRUD db = new CRUD();

        public IEnumerable<ProductsModel> Get()
        {


            return db.GetAllProducts().ToArray();
        }

        [HttpPost]
        public IActionResult Post([FromBody] JsonElement body)
        {

            ProductsModel product = new ProductsModel()
            {
                catId = int.Parse(body.GetProperty("catId").ToString()),
                name = body.GetProperty("name").ToString(),
                description = body.GetProperty("description").ToString(),
                image = body.GetProperty("image").ToString(),
                price = int.Parse(body.GetProperty("price").ToString())

                
            };

            db.InsertProduct(product);

            return Ok();

        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
