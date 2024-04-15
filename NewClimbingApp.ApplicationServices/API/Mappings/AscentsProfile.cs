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
            .ForMember(x => x.Routes, y => y.MapFrom(z => z.Routes != null ? z.Routes.Select(x => x.Name) : new List<string>()))
            .ForMember(x => x.Climbers, y => y.MapFrom(z => z.Climbers != null ? z.Climbers.Select(x => x.Id) : new List<int>()))
            .ForMember(x => x.Rating, y => y.MapFrom(z => z.Rating))
            .ForMember(x => x.Notes, y => y.MapFrom(z => z.Notes));

        _ = this.CreateMap<AddAscentRequest, Ascent>()
           .ForMember(x => x.IsClimbed, y => y.MapFrom(z => z.IsClimbed))
           .ForMember(x => x.Rating, y => y.MapFrom(z => z.Rating))
           .ForMember(x => x.Style, y => y.MapFrom(z => z.Style))
          // .ForMember(x => x.Routes, y => y.MapFrom(z => z.Routes ?? new List<string>()))
           .ForMember(x => x.Notes, y => y.MapFrom(z => z.Notes));

        this.CreateMap<UpdateAscentRequest, Ascent>()
          .ForMember(x => x.IsClimbed, y => y.MapFrom(z => z.IsClimbed))
          .ForMember(x => x.Rating, y => y.MapFrom(z => z.Rating))
          .ForMember(x => x.Style, y => y.MapFrom(z => z.Style))
          .ForMember(x => x.Routes, y => y.MapFrom(z => z.Routes != null ? z.Routes : new List<string>()))
          .ForMember(x => x.Notes, y => y.MapFrom(z => z.Notes));
    }
}
