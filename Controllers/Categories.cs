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
    public class Categories : ControllerBase
    {
        CRUD db = new CRUD();
        public IEnumerable<CategoriesModel> Get()
        {


            return db.GetAllCategories().ToArray();
        }


        [HttpPost]
        public IActionResult Post([FromBody] JsonElement body)
        {

            CategoriesModel category = new CategoriesModel()
            {
                name = body.GetProperty("name").ToString(),
                description = body.GetProperty("description").ToString(),
                image = body.GetProperty("image").ToString(),


            };

            db.InsertCategory(category);

            return Ok();

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] JsonElement body)
        {
            CategoriesModel category = new CategoriesModel()
            {
                name = body.GetProperty("name").ToString(),
                description = body.GetProperty("description").ToString(),
                image = body.GetProperty("image").ToString(),


            };

            db.UpdateCategory(id, category);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.DeleteCategory(id);
        }


    }
}
