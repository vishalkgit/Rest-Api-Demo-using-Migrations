using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rest_Api_Demo_using_Migrations.Data;
using Rest_Api_Demo_using_Migrations.Models.Entitiess;

namespace Rest_Api_Demo_using_Migrations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CustomerController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var allcustomers=dbContext.Customers.ToList();
            return Ok(allcustomers);
        }

        [HttpPost]

        public IActionResult AddCustomer(CustomerDto customerDto)
        {
            var customerEntity = new Customer()
            {
                CName = customerDto.CName,
                Email = customerDto.Email,
                Address = customerDto.Address,
                Salary = customerDto.Salary
            };

            dbContext.Customers.Add(customerEntity);
            dbContext.SaveChanges();

            return StatusCode(201, customerEntity);

        }


        [HttpGet]
        [Route("{Cid:guid}")]
        public IActionResult GetCustomerbyId(Guid Cid)
        {
            var allCustomers = dbContext.Customers.ToList();

            if (allCustomers is null)
            {
                return StatusCode(404);
            }

            var GetCustById = dbContext.Customers.Find(Cid);
            return Ok(GetCustById);
        }

        [HttpPut]
        [Route("{Cid:guid}")]
        public IActionResult UpdateCustomer(Guid Cid, UpdateCustomerDto updateCustomerDto)
        {
            var getalldata = dbContext.Customers.Find(Cid);

            if (getalldata is null)
            {
                return StatusCode(404);
            }

            getalldata.CName = updateCustomerDto.CName;
            getalldata.Email = updateCustomerDto.Email;
            getalldata.Address = updateCustomerDto.Address;
            getalldata.Salary = updateCustomerDto.Salary;

            //dbContext.Customers.Add();
            dbContext.SaveChanges();
            return Ok(getalldata);

        }


        [HttpDelete]
        [Route("{Cid:guid}")]
        public IActionResult DeleteCustomerbyId(Guid Cid)
        {
            var cidExists = dbContext.Customers.Find(Cid);
            if (cidExists is null)
            {
                return StatusCode(404);
            }

            var delete = dbContext.Customers.Remove(cidExists);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteAllCustomers()
        {
           

            var deleteall = dbContext.Customers.ExecuteDelete();
            if(deleteall==0)
            {
                return NotFound();
            }

            return Ok(new {DeletedRecords=deleteall });

        }
    }
}
