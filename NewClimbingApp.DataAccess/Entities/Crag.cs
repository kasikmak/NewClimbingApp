using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.Entities;

public class Crag : EntityBase
{ 
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }

    [MaxLength(50)]
    public string Location { get; set; }  
    public List<Route>? Routes { get; set; }
}
