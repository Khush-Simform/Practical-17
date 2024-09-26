using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Practical_17.Models
{
    public class Login
    {
        [Required]
        public string Fname { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;    
    }
}
