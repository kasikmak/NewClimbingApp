using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.Entities;

public class Route : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(5)]
    public string Grade { get; set; }
    [Range(4F, 9.3F)]
    public float GradeAsFloat { get; set; }   
    public int? Length { get; set; }
    public bool IsClimbed { get; set; }
    public enum RouteType
    {
        Sport = 0,
        Boulder = 1
    };
    public RouteType Type { get; set; }
    public List<User>? Climbers { get; set; }
    public int? EquiperId { get; set; }
    public int? CragId { get; set; }   
    public List<Ascent>? Ascents { get; set; }
}

