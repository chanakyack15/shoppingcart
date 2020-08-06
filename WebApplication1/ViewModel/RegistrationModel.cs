using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModel
{
    public class RegistrationModel
    {
        [Required]
        public string Name { set; get; }
        [Required]
        [EmailAddress]
        public string Email { set; get;  }
        [Required]
        [MinLength(5, ErrorMessage ="Too short password")]
        [MaxLength(15)]
        public string Password { set; get; }
    }
}
