using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;

public class ErrorModel
{
    public ErrorModel(string error)
    {
        Error = error;
    }
    public string Error { get; set; }
}
