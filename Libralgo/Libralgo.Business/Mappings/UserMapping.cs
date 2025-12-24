using AutoMapper;
using Libralgo.Dto.UserDtos;
using Libralgo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libralgo.Business.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<UserRegisterDto, User>().ReverseMap();
            CreateMap<UserLoginDto, User>().ReverseMap();
        }
    }
}
