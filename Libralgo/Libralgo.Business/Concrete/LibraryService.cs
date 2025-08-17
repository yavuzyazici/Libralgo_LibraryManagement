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
    public class LibraryService(ILibraryDal libraryDal, IMapper mapper) : ILibraryService
    {
        public void TCreate(Library entity)
        {
            libraryDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var data = mapper.Map<Library>(dto);
            libraryDal.Create(data);
        }

        public void TDelete(int id)
        {
            libraryDal.Delete(id);
        }

        public List<Library> TGetAll()
        {
            return libraryDal.GetAll();
        }

        public List<TDto> TGetAllDto<TDto>()
        {
            return mapper.Map<List<TDto>>(libraryDal.GetAll());
        }

        public Library TGetById(int id)
        {
            return libraryDal.GetById(id);
        }

        public TDto TGetByIdDto<TDto>(int id)
        {
            return mapper.Map<TDto>(libraryDal.GetById(id));
        }

        public Library TGetFirst()
        {
            return libraryDal.GetFirst();
        }

        public void TUpdate(Library entity)
        {
            libraryDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = mapper.Map<Library>(dto);
            libraryDal.Update(data);
        }
    }
}
