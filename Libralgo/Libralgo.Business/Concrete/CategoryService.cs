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
    public class CategoryService(ICategoryDal categoryDal, IMapper mapper) : ICategoryService
    {
        public void TCreate(Category entity)
        {
            categoryDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var data = mapper.Map<Category>(dto);
            categoryDal.Create(data);
        }

        public void TDelete(int id)
        {
            categoryDal.Delete(id);
        }

        public List<Category> TGetAll()
        {
            return categoryDal.GetAll();
        }

        public List<TDto> TGetAllDto<TDto>()
        {
            return mapper.Map<List<TDto>>(categoryDal.GetAll());
        }

        public Category TGetById(int id)
        {
            return categoryDal.GetById(id);
        }

        public TDto TGetByIdDto<TDto>(int id)
        {
            return mapper.Map<TDto>(categoryDal.GetById(id));
        }

        public Category TGetFirst()
        {
            return categoryDal.GetFirst();
        }

        public void TUpdate(Category entity)
        {
            categoryDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = mapper.Map<Category>(dto);
            categoryDal.Update(data);
        }
    }
}
