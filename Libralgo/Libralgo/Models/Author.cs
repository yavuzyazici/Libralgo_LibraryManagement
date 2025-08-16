using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libralgo.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Yazar adı soyadı zorunludur.")]
        [MaxLength(255, ErrorMessage = "Yazar adı soyadı en fazla 255 karakter olabilir.")]
        public string NameSurname { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
