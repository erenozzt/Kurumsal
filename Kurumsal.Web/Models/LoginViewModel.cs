using System.ComponentModel.DataAnnotations;

namespace Kurumsal.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
 
        public bool RememberMe { get; set; }
    }
}
