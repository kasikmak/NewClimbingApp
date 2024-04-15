using NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Domain.Responses;

public class ResponseBase<T> : ErrorResponseBase
{
    public T Data { get; set; }
}
