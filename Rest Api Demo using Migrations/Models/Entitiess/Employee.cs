using System.ComponentModel.DataAnnotations;

namespace Rest_Api_Demo_using_Migrations.Models.Entitiess
{
    public class Employee
    {

        [Key]
        public int Eid { get; set; }

        public required string EName { get; set; }

        public decimal Salary { get; set; }
    }
}
