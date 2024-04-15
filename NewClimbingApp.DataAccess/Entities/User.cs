using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.Entities;

public class User : EntityBase
{
    [Required]
    [MaxLength(25)]
    public string UserName { get; set; }
    [Required]
    [MaxLength(50)]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MaxLength(25)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(25)]
    public string LastName { get; set; }
    [MaxLength(25)]
    public string Nationality { get; set; }
    public enum UserRole
    {
        Admin = 0,
        Climber = 1,
        Equiper = 2,
        Guest = 3
    };
    public UserRole Role { get; set; }

    [Required]
    [MinLength(8)]
    public string PasswordHash { get; set; }
    public List<Route> Routes { get; set; }       

    public List<Ascent> Ascents { get; set; }     

}
