using AutoMapper;
using Libralgo.Dto.BookDtos;
using Libralgo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libralgo.Business.Mappings
{
    public class BookMapping : Profile
    {
        public BookMapping()
        {
            CreateMap<Book, BookListDto>();
            CreateMap<BookAddDto, Book>().ForMember(dest => dest.Authors, opt => opt.Ignore())
                                        .ForMember(dest => dest.Categories, opt => opt.Ignore());
        }
    }
}
