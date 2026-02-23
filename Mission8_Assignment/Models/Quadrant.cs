using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Mission8_Assignment.Models

{
    public class Quadrant
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string task { get; set; }
        public string dueDate { get; set; }
        [Required]
        public int quadrant { get; set; }


        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public bool completed { get; set; }



    }
}
