using System.ComponentModel.DataAnnotations;

namespace Rest_Api_Demo_using_Migrations.Models.Entitiess
{
    public class Customer
    {
        [Key]
        public Guid Cid { get; set; }

        public required string CName { get; set; }

        public required string Email { get; set; }
        public string? Address { get; set; }

        public decimal Salary {  get; set; }


    }
}
