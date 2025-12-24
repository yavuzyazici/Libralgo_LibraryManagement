using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libralgo.Dto.UserDtos
{
    public class UserLoginDto
    {
        [Required, MaxLength(255), EmailAddress]
        public string MailAddress { get; set; } = null!;
        [Required, DataType(DataType.Password), MaxLength(255)]
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; }
    }
}
