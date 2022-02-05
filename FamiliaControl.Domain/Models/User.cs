using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiliaControl.Domain.Models
{
    public class User : BaseClass
    {
        [Required(ErrorMessage = "Email é obrigatório")]        
        public string Email { get; set; }

        [Required(ErrorMessage = "Password é obrigatório")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Login é obrigatório")]
        public string Login { get; set; }

    }
}
