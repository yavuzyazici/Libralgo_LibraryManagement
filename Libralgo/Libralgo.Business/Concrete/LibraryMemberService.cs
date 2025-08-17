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
    public class LibraryMemberService(ILibraryMemberDal libraryMemberDal, IMapper mapper) : ILibraryMemberService
    {
        public void TCreate(LibraryMember entity)
        {
            libraryMemberDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var data = mapper.Map<LibraryMember>(dto);
            libraryMemberDal.Create(data);
        }

        public void TDelete(int id)
        {
            libraryMemberDal.Delete(id);
        }

        public List<LibraryMember> TGetAll()
        {
            return libraryMemberDal.GetAll();
        }

        public List<TDto> TGetAllDto<TDto>()
        {
            return mapper.Map<List<TDto>>(libraryMemberDal.GetAll());
        }

        public LibraryMember TGetById(int id)
        {
            return libraryMemberDal.GetById(id);
        }

        public TDto TGetByIdDto<TDto>(int id)
        {
            return mapper.Map<TDto>(libraryMemberDal.GetById(id));
        }

        public LibraryMember TGetFirst()
        {
            return libraryMemberDal.GetFirst();
        }

        public void TUpdate(LibraryMember entity)
        {
            libraryMemberDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = mapper.Map<LibraryMember>(dto);
            libraryMemberDal.Update(data);
        }
    }
}
