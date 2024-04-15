using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Domain.ErrorHandling;

public static class ErrorType
{
    public const string InternalServerError = "INTERNAL_SERVER_ERROR";
    
    public const string Forbidden = "FORBIDDEN";

    public const string ValidationError = "VALIDATON_ERROR";

    public const string NotAuthenticated = "NOT_AUTHENTICATED";

    public const string Unauthorized = "UNAUTHORIZED";

    public const string NotFound = "NOT_FOUND";

    public const string UnsupportedMediaType = "UNSUPPORTED_MEDIA_TYPE";

    public const string UnsupportedMethod = "UNSUPPORTED_METHOD";

    public const string RequestTooLarge = "REQUEST_TOO_LARGE";

    public const string TooManyRequests = "TOO_MANY_REQUESTS";

    public const string Conflict = "";
}
