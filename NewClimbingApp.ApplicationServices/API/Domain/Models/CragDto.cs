using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Domain.Models;

public class CragDto
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(1000)]
    public string? Description { get; set; }
    [MaxLength(50)]
    public string Location { get; set; }
    public List<string> Routes { get; set; }
}
