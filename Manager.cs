using System.ComponentModel.DataAnnotations;

namespace Group5_Website.Models
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]

        public string Account { get; set; }
        [Required]
        [MaxLength(20)]

        public string Password { get; set; }
    }
}
