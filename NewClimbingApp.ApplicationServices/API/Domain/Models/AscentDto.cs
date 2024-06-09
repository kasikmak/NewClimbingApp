using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NewClimbingApp.DataAccess.Entities.Ascent;

namespace NewClimbingApp.ApplicationServices.API.Domain.Models;

public class AscentDto
{
    public int Id { get; set; }
    public float? Rating { get; set; }
    public AscentStyle Style { get; set; }

    [MaxLength(250)]
    public string? Notes { get; set; }

    public int RouteId { get; set; }
    public int ClimberId { get; set; }

   
}
