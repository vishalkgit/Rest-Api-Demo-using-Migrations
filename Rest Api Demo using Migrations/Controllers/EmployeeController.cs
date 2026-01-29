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

        [HttpPut]
        [Route("{Eid:int}")]
        public IActionResult updateEmp(int Eid,Employee emp)
        {
            var allemp = dbContext.Employees.Find(Eid);
            if(allemp is null)
            {
                return NoContent();
            }
            //allemp.Eid = emp.Eid;
            allemp.EName = emp.EName;
            allemp.Salary = emp.Salary;
            dbContext.SaveChanges();
            return Ok(allemp);
        }

        [HttpDelete]
        [Route("{Eid:int}")]
        public IActionResult DeleteEmp(int Eid)
        {
            var emp = dbContext.Employees.Find(Eid);
            if(emp is null)
            {
                return NotFound();
            }
            var res=dbContext.Employees.Remove(emp);
            dbContext.SaveChanges();
            return Ok();
        }


    }
}
