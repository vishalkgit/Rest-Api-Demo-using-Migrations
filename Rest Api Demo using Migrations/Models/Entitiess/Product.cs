using System.ComponentModel.DataAnnotations;

namespace Rest_Api_Demo_using_Migrations.Models.Entitiess
{
    public class Product
    {
        [Key]
        public int Pid { get; set; }

        public required string PName { get; set; }

        public required string Cost { get; set; }



    }
}
