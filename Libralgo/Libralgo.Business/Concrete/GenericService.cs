using AutoMapper;
using Libralgo.Business.Abstract;
using Libralgo.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libralgo.Business.Concrete
{
    public class GenericService<T>(IGenericDal<T> genericDal, IMapper mapper) : IGenericService<T> where T : class
    {
        public void TCreate(T entity)
        {
            genericDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var data = mapper.Map<T>(dto);
            genericDal.Create(data);
        }

        public void TDelete(int id)
        {
            genericDal.Delete(id);
        }

        public List<T> TGetAll()
        {
            return genericDal.GetAll();
        }

        public List<TDto> TGetAllDto<TDto>()
        {
            return mapper.Map<List<TDto>>(genericDal.GetAll());
        }

        public T TGetById(int id)
        {
           return genericDal.GetById(id);
        }

        public TDto TGetByIdDto<TDto>(int id)
        {
            return mapper.Map<TDto>(genericDal.GetById(id));
        }

        public T TGetFirst()
        {
            return genericDal.GetFirst();
        }

        public void TUpdate(T entity)
        {
            genericDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = mapper.Map<T>(dto);
            genericDal.Update(data);
        }
    }
}
