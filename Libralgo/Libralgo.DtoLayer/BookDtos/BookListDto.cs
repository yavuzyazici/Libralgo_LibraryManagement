using Libralgo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libralgo.Dto.BookDtos
{
    public class BookListDto
    {
        public int Id { get; set; }
        public string BookName { get; set; } = null!;
        public int PageCount { get; set; }
        public string? ImageUrl { get; set; }
        public virtual Library Library { get; set; } = null!;
        public virtual Publisher Publisher { get; set; } = null!;
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}
