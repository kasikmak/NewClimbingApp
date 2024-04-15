using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static NewClimbingApp.DataAccess.Entities.User;

namespace NewClimbingApp.ApplicationServices.API.Domain.Models;

public class UserDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }    
    public string FirstName { get; set; }  
    public string LastName { get; set; }   
    public string Nationality { get; set; }

    [JsonIgnore]
    public string Password { get; set; }
   /* public enum Role
    {
        Admin = 0,
        Climber = 1,
        Equiper = 2,
        Guest = 3
    };*/

    public UserRole Role  { get; set; }      

    public List<string> Routes { get; set; }
}
