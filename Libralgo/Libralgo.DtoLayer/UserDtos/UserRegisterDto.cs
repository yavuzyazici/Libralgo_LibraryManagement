using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libralgo.Dto.UserDtos
{
    public class UserRegisterDto
    {
        [Required, MaxLength(100)]
        public string NameSurname { get; set; } = null!;
        [Required, MaxLength(255), EmailAddress]
        public string MailAddress { get; set; } = null!;

        [Required, DataType(DataType.Password), MinLength(4), MaxLength(255)]
        public string Password { get; set; } = null!;

        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
