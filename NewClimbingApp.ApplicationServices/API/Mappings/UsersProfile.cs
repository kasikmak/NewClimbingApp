using AutoMapper;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Users;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Mappings;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        this.CreateMap<User, UserDto>()
            .ForMember(x => x.Id, y => y.MapFrom(y => y.Id))
            .ForMember(x => x.UserName, y => y.MapFrom(y => y.UserName))
            .ForMember(x => x.FirstName, y => y.MapFrom(y => y.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(y => y.LastName))
            .ForMember(x => x.Nationality, y => y.MapFrom(y => y.Nationality))
            .ForMember(x => x.Password, y => y.MapFrom( z=> z.PasswordHash))
            .ForMember(x => x.Routes, y => y.MapFrom(y => y.Routes != null ? y.Routes.Select(z => z.Name) : new List<string>()))
            .ForMember(x => x.Role, y => y.MapFrom(y => y.Role));

        this.CreateMap<AddUserRequest, User>()
            .ForMember(x => x.UserName, y => y.MapFrom(y => y.UserName))
            .ForMember(x => x.FirstName, y => y.MapFrom(y => y.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(y => y.FirstName))
            .ForMember(x => x.Nationality, y => y.MapFrom(y => y.Nationality))
            .ForMember(x => x.Role, y => y.MapFrom(y => y.Role))
            .ForMember(x => x.PasswordHash, y => y.MapFrom(z => z.Password));

        this.CreateMap<UpdateUserRequest, User>()
           .ForMember(x => x.Id, y => y.MapFrom(y => y.Id))
           .ForMember(x => x.UserName, y => y.MapFrom(y => y.UserName))
           .ForMember(x => x.FirstName, y => y.MapFrom(y => y.FirstName))
           .ForMember(x => x.LastName, y => y.MapFrom(y => y.LastName))
           .ForMember(x => x.Nationality, y => y.MapFrom(y => y.Nationality))
           .ForMember(x => x.PasswordHash, y => y.MapFrom(z => z.Password));
    }
}
