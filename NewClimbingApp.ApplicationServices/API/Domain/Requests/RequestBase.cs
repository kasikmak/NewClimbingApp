﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Domain.Requests;

public class RequestBase
{
    public string? AuthenticationName { get; set; }
    public string? AuthenticationRole { get; set; }

    public string? AuthenticationId { get; set; }
}
