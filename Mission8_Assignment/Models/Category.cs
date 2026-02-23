using System.ComponentModel.DataAnnotations;

namespace Mission8_Assignment.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; } // primary key
        public string CategoryName { get; set; }

    }
}
