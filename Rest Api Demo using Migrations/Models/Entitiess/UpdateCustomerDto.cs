namespace Rest_Api_Demo_using_Migrations.Models.Entitiess
{
    public class UpdateCustomerDto
    {

        public required string CName { get; set; }

        public required string Email { get; set; }
        public string? Address { get; set; }

        public decimal Salary { get; set; }
    }
}
