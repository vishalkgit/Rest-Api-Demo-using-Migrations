using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest_Api_Demo_using_Migrations.Data;
using Rest_Api_Demo_using_Migrations.Models.Entitiess;

namespace Rest_Api_Demo_using_Migrations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult GetEmployees()
        {
            var res=dbContext.Employees.ToList();
            return Ok(res);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee emp)
        {
            var res=dbContext.Employees.Add(emp);
            dbContext.SaveChanges();
            return StatusCode(201, emp);
        }


        [HttpGet]
        [Route("{Eid:int}")]
        public IActionResult GetEmpBy(int Eid)
        {
            var res = dbContext.Employees.Find(Eid);
            return Ok(res);
        }

        [HttpPost]
        [Route("{Eid:int}")]
        public IActionResult updateEmp(int Eid,Employee emp)
        {
            var res=dbContext.Employees.Update(emp);
            dbContext.SaveChanges();
            return Ok(res);
        }


    }
}
