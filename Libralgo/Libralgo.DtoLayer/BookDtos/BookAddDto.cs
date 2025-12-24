using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libralgo.Dto.BookDtos
{
    public class BookAddDto
    {
        [Required, MaxLength(100)]
        public string BookName { get; set; } = null!;

        [Range(1, 100000)]
        public int PageCount { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Url, MaxLength(2048)]
        public string? ImageUrl { get; set; }

        [Required]
        public int PublisherId { get; set; }

        [Required]
        public int LibraryId { get; set; }

        [Required(ErrorMessage = "En az bir yazar seçiniz.")]
        public List<int> AuthorIds { get; set; } = new();

        [Required(ErrorMessage = "En az bir kategori seçiniz.")]
        public List<int> CategoryIds { get; set; } = new();
    }
}
