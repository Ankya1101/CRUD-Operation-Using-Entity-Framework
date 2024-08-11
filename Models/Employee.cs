using System.ComponentModel.DataAnnotations;

namespace CRUD_DEMO.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
