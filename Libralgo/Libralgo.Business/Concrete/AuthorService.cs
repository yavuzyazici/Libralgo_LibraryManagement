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
    public class AuthorService(IAuthorDal authorDal, IMapper mapper) : IAuthorService
    {
        public void TCreate(Author entity)
        {
            authorDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var data = mapper.Map<Author>(dto);
            authorDal.Create(data);
        }

        public void TDelete(int id)
        {
            authorDal.Delete(id);
        }

        public List<Author> TGetAll()
        {
            return authorDal.GetAll();
        }

        public List<TDto> TGetAllDto<TDto>()
        {
            return mapper.Map<List<TDto>>(authorDal.GetAll());
        }

        public Author TGetById(int id)
        {
            return authorDal.GetById(id);
        }

        public TDto TGetByIdDto<TDto>(int id)
        {
            return mapper.Map<TDto>(authorDal.GetById(id));
        }

        public Author TGetFirst()
        {
            return authorDal.GetFirst();
        }

        public void TUpdate(Author entity)
        {
            authorDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = mapper.Map<Author>(dto);
            authorDal.Update(data);
        }
    }
}
