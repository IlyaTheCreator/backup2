using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpotifyAppApi.Dtos;
using SpotifyAppApi.Models;
using AutoMapper;

namespace SpotifyAppApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Source -> Target
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
