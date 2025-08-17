using AutoMapper;
using Libralgo.Business.Abstract;
using Libralgo.Data.Abstract;
using Libralgo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Libralgo.Business.Concrete
{
    public class BookService(IBookDal bookDal, IMapper mapper) : IBookService
    {
        public void TCreate(Book entity)
        {
            bookDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var data = mapper.Map<Book>(dto);
            bookDal.Create(data);
        }

        public void TDelete(int id)
        {
            bookDal.Delete(id);
        }

        public List<Book> TGetAll()
        {
            return bookDal.GetAll();
        }

        public List<TDto> TGetAllDto<TDto>()
        {
            return mapper.Map<List<TDto>>(bookDal.GetAll());
        }

        public Book TGetById(int id)
        {
            return bookDal.GetById(id);
        }

        public TDto TGetByIdDto<TDto>(int id)
        {
            return mapper.Map<TDto>(bookDal.GetById(id));
        }

        public Book TGetFirst()
        {
            return bookDal.GetFirst();
        }

        public void TUpdate(Book entity)
        {
            bookDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = mapper.Map<Book>(dto);
            bookDal.Update(data);
        }
    }
}
