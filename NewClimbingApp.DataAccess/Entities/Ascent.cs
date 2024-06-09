 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.Entities;

public class Ascent : EntityBase
{
    public float? Rating { get; set; }
    public bool IsClimbed { get; set; }

    [MaxLength(250)]
    public string? Notes { get; set; }    
    
    public enum AscentStyle
    {
        OnSight = 0,
        FLASH = 1,
        RedPoint = 2,
        TopRope = 3
    }

    public AscentStyle Style { get; set; }
    public int ClimberId { get; set; }
    public int RouteId { get; set; }
}
