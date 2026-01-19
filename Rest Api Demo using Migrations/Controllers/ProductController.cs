using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rest_Api_Demo_using_Migrations.Data;
using Rest_Api_Demo_using_Migrations.Models.Entitiess;

namespace Rest_Api_Demo_using_Migrations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ProductController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var all=dbContext.Products.ToList();
            return Ok(all);
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductDto addProductDto)
        {
            var productentity = new Product()
            {
                PName = addProductDto.PName,
                Cost = addProductDto.Cost

            };

            var add = dbContext.Products.Add(productentity);
            dbContext.SaveChanges();
            return Created();
        }


        [HttpGet]
        [Route("{Pid:int}")]
        public IActionResult GetProductById(int Pid)
        {
            var getall = dbContext.Products.ToList();
            if(getall is null)
            {
                return NotFound();
            }

            var getbyId = dbContext.Products.Find(Pid);
            if(getbyId is null)
            {
                return StatusCode(404);
            }
            return Ok(getbyId);

        }



        [HttpPut]
        [Route("{Pid:int}")]
        public IActionResult UpdateProductbyId(int Pid,UpdateProductDto updateProductDto)
        {
            var update = dbContext.Products.Find(Pid);

            if(update is null)
            {
                return StatusCode(404);
            }

            update.PName = updateProductDto.PName;
                update.Cost=updateProductDto.Cost;

            dbContext.SaveChanges();
            return Ok(update);

        }


        [HttpDelete]
        [Route("{Pid:int}")]
        public IActionResult DeleteproductByid(int Pid)
        {
            var delete = dbContext.Products.Find(Pid);
            if(delete is null)
            {
                return StatusCode(404);
            }
            dbContext.Remove(delete);
            dbContext.SaveChanges();
            return Ok(new {DeletedCount=delete });

        }


        [HttpDelete]
        public IActionResult DeleteAll()
        {
            var deleteAll = dbContext.Products.ExecuteDelete();
            return Ok(new { DeletedCount=deleteAll});
        }

        [HttpPatch]
        [Route("{Pid:int}")]
        public IActionResult UpdatePartial(int Pid,UpdateProductDto updateProductDto)
        {
            var updatepartial = dbContext.Products.Find(Pid);

            updatepartial.PName= updateProductDto.PName;
            updatepartial.Cost= updateProductDto.Cost;


            dbContext.Products.Update(updatepartial);
            dbContext.SaveChanges();
            return Ok(updatepartial);

        }

    }
}
