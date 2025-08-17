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
    public class PublisherService(IPublisherDal publisherDal, IMapper mapper) : IPublisherService
    {
        public void TCreate(Publisher entity)
        {
            publisherDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var data = mapper.Map<Publisher>(dto);
            publisherDal.Create(data);
        }

        public void TDelete(int id)
        {
            publisherDal.Delete(id);
        }

        public List<Publisher> TGetAll()
        {
            return publisherDal.GetAll();
        }

        public List<TDto> TGetAllDto<TDto>()
        {
            return mapper.Map<List<TDto>>(publisherDal.GetAll());
        }

        public Publisher TGetById(int id)
        {
            return publisherDal.GetById(id);
        }

        public TDto TGetByIdDto<TDto>(int id)
        {
            return mapper.Map<TDto>(publisherDal.GetById(id));
        }

        public Publisher TGetFirst()
        {
            return publisherDal.GetFirst();
        }

        public void TUpdate(Publisher entity)
        {
            publisherDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = mapper.Map<Publisher>(dto);
            publisherDal.Update(data);
        }
    }
}
