using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libralgo.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kitap adı zorunludur.")]
        [MaxLength(100, ErrorMessage = "Kitap adı en fazla 100 karakter olabilir.")]
        public string BookName { get; set; } = null!;

        [Range(1, 100000, ErrorMessage = "Sayfa sayısı 1 veya daha büyük olmalıdır.")]
        public int PageCount { get; set; }

        [MaxLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        public string? Description { get; set; }

        [Url(ErrorMessage = "Geçerli bir URL giriniz.")]
        [MaxLength(2048, ErrorMessage = "URL 2048 karakteri aşmamalıdır.")]
        public string? ImageUrl { get; set; }
        [Required]
        public int LibraryId { get; set; }

        [ForeignKey(nameof(LibraryId))]
        public virtual Library Library { get; set; } = null!;

        [Required]
        public int PublisherId { get; set; }

        [ForeignKey(nameof(PublisherId))]
        public virtual Publisher Publisher { get; set; } = null!;

        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}
