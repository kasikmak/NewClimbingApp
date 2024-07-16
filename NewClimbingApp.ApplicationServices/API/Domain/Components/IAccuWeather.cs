using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewClimbingApp.ApplicationServices.API.Domain.Components.Models;


namespace NewClimbingApp.ApplicationServices.API.Domain.Components;

public interface IAccuWeather
{
    Task<Weather> Check(string city);
}
