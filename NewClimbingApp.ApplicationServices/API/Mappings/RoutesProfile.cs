using AutoMapper;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Routes;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Mappings;

public class RoutesProfile : Profile
{
    public RoutesProfile()
    {
        this.CreateMap<Route, RouteDto>()
        .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
        .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
        .ForMember(x => x.Length, y => y.MapFrom(z => z.Length))
        .ForMember(x => x.Grade, y => y.MapFrom(z => z.Grade))
        .ForMember(x => x.AscentId, y => y.MapFrom(z => z.AscentId))
        .ForMember(x => x.GradeAsFloat, y => y.MapFrom(z => z.GradeAsFloat));
            
        this.CreateMap<AddRouteRequest, Route>()
        //.ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
        .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
        .ForMember(x => x.Length, y => y.MapFrom(z => z.Length))
        .ForMember(x => x.Grade, y => y.MapFrom(z => z.Grade))
        .ForMember(x => x.GradeAsFloat, y => y.MapFrom(z => z.GradeAsFloat));

        this.CreateMap<UpdateRouteRequest, Route>()
        .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
        .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
        .ForMember(x => x.Length, y => y.MapFrom(z => z.Length))
        .ForMember(x => x.Grade, y => y.MapFrom(z => z.Grade))
        .ForMember(x => x.GradeAsFloat, y => y.MapFrom(z => z.GradeAsFloat));
    }
}
