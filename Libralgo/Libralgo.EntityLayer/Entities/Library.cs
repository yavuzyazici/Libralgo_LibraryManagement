using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libralgo.Models
{
    public class Library
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LibraryId { get; set; }

        [Required(ErrorMessage = "Kütüphane adı zorunludur.")]
        [MaxLength(255, ErrorMessage = "Kütüphane adı en fazla 255 karakter olabilir.")]
        public string LibraryName { get; set; } = null!;
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
        public virtual ICollection<LibraryMember> LibraryMembers { get; set; } = new List<LibraryMember>();
    }
}
