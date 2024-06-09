using Microsoft.EntityFrameworkCore;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Queries
{
    public class GetAscentsQuery : QueryBase<List<Ascent>>
    {
        public float Rating { get; set; }

        public int RouteId {  get; set; }

        public  override Task<List<Ascent>> Execute(NewClimbingAppContext context)
        {
            if (this.Rating != null)
            {
                return context.Ascents
                    .Where(x => x.Rating >= this.Rating)
                    .OrderBy(x => x.RouteId)
                    .ToListAsync();
            }
            if (this.RouteId != null) 
            {
                return context.Ascents
                    .Where(x => x.RouteId == this.RouteId)
                    .OrderBy(x => x.Rating)
                    .ToListAsync();                 
            }           
            return context.Ascents
                .OrderBy(x => x.Rating)
                .ToListAsync();        
        }
    }
}
