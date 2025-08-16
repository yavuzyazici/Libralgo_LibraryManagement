using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libralgo.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Kategori zorunludur.")]
        [MaxLength(255, ErrorMessage = "Kategori adı en fazla 255 karakter olabilir.")]
        public string CategoryName { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
