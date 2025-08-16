using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libralgo.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Ad soyad zorunludur.")]
        [MaxLength(255, ErrorMessage = "Ad soyad en fazla 255 karakter olabilir.")]
        public string NameSurname { get; set; } = null!;

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [MaxLength(320, ErrorMessage = "E-posta adresi 320 karakteri aşmamalıdır.")]
        public string MailAddress { get; set; } = null!;

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [MaxLength(255, ErrorMessage = "Şifre en fazla 255 karakter olabilir.")]
        public string Password { get; set; } = null!;
        public virtual ICollection<LibraryMember> LibraryMemberships { get; set; } = new List<LibraryMember>();
    }
}
