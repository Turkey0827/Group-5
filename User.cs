using System.ComponentModel.DataAnnotations;

namespace Group5_Website.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]

        public string Account {  get; set; }
        [Required]
        [MaxLength(20)]

        public string Password { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address!")]  // 验证是否为有效的邮箱格式
        [StringLength(20, ErrorMessage = "The mailbox must not exceed 20 characters in length!")]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } 
            
    }
}
