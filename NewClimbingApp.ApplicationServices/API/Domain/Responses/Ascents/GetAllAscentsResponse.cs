using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Domain.Responses.Ascents;

public class GetAllAscentsResponse : ResponseBase<List<AscentDto>>
{
}
