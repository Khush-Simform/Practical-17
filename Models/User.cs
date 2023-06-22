using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Practical_17.Models
{
    public enum UserRole
    {
        Admin,
        Normal
    }
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Fname { get; set; } = string.Empty;
        [Required]
        public string Lname { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Range(6000000000, 9999999999)]
        public string MobileNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [NotMapped]
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and Confirm Password doesn't match")]
        public string ConfirmPassword { get; set; } = string.Empty;
        public UserRole Role { get; set; }
    }
}
