using AutoMapper;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Crags;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Mappings;

public class CragsProfile : Profile
{
    public CragsProfile()
    {
        this.CreateMap<Crag, CragDto>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
            .ForMember(x => x.Location, y => y.MapFrom(z => z.Location))
            .ForMember(x => x.Routes, y => y.MapFrom(z => z.Routes != null ? z.Routes.Select(z => z.Name) : new List<string>()));

        this.CreateMap<AddCragRequest, Crag>()                        
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
            .ForMember(x => x.Location, y => y.MapFrom(z => z.Location));

        this.CreateMap<UpdateCragRequest, Crag>()
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
            .ForMember(x => x.Location, y => y.MapFrom(z => z.Location));

        this.CreateMap<DeleteCragRequest, Crag>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));
    }
}
