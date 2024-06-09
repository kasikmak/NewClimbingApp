using AutoMapper;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Ascents;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Mappings;

public class AscentsProfile : Profile
{
    public AscentsProfile()
    {
       this.CreateMap<Ascent, AscentDto>()
           .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
           .ForMember(x => x.Style, y => y.MapFrom(z => z.Style))            
           .ForMember(x => x.RouteId, y => y.MapFrom(z => z.RouteId))
           .ForMember(x => x.ClimberId, y => y.MapFrom(z => z.ClimberId))
           .ForMember(x => x.Rating, y => y.MapFrom(z => z.Rating))
           .ForMember(x => x.Notes, y => y.MapFrom(z => z.Notes));

       this.CreateMap<AddAscentRequest, Ascent>()
           .ForMember(x => x.IsClimbed, y => y.MapFrom(z => z.IsClimbed))
           .ForMember(x => x.Rating, y => y.MapFrom(z => z.Rating))
           .ForMember(x => x.Style, y => y.MapFrom(z => z.Style))
           .ForMember(x => x.RouteId, y => y.MapFrom(z => z.RouteId))
           .ForMember(x => x.Notes, y => y.MapFrom(z => z.Notes));

       this.CreateMap<UpdateAscentRequest, Ascent>()
           .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
           .ForMember(x => x.IsClimbed, y => y.MapFrom(z => z.IsClimbed))
           .ForMember(x => x.Rating, y => y.MapFrom(z => z.Rating))
           .ForMember(x => x.Style, y => y.MapFrom(z => z.Style))
           .ForMember(x => x.RouteId, y => y.MapFrom(z => z.RouteId))
           .ForMember(x => x.Notes, y => y.MapFrom(z => z.Notes));

       this.CreateMap<DeleteAscentRequest, AscentDto>()
           .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));
    }
}
