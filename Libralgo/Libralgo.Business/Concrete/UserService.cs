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
    public class UserService(IUserDal userDal, IMapper mapper) : IUserService
    {
        public void TCreate(User entity)
        {
            userDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var data = mapper.Map<User>(dto);
            userDal.Create(data);
        }

        public void TDelete(int id)
        {
            userDal.Delete(id);
        }

        public List<User> TGetAll()
        {
            return userDal.GetAll();
        }

        public List<TDto> TGetAllDto<TDto>()
        {
            return mapper.Map<List<TDto>>(userDal.GetAll());
        }

        public User TGetById(int id)
        {
            return userDal.GetById(id);
        }

        public TDto TGetByIdDto<TDto>(int id)
        {
            return mapper.Map<TDto>(userDal.GetById(id));
        }

        public User TGetFirst()
        {
            return userDal.GetFirst();
        }

        public void TUpdate(User entity)
        {
            userDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = mapper.Map<User>(dto);
            userDal.Update(data);
        }
    }
}
