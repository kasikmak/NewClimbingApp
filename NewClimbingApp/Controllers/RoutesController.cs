using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Routes;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Users;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Routes;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Users;
using NewClimbingApp.DataAccess;
using NewClimbingApp.DataAccess.Entities;

namespace NewClimbingApp.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class RoutesController : ApiControllerBase
{
   
    public RoutesController(IMediator mediator, ILogger<RoutesController> logger) : base(mediator, logger)
    {
        logger.LogInformation("We are in Routes");
    }

    [HttpGet]
    [Route("")]
    public Task<IActionResult> GetAllRoutes([FromQuery] GetRoutesRequest request)
    {
        return HandleRequest<GetRoutesRequest, GetRoutesResponse>(request);
    }

    [HttpGet]
    [Route("grade/{routeGrade}")]
    public Task<IActionResult> GetRoutesByGrade([FromRoute] string routeGrade)
    {
        var request = new GetRoutesByGradeRequest
        {
            Grade = routeGrade.ToUpper(),
        };        
        return HandleRequest<GetRoutesByGradeRequest, GetRoutesByGradeResponse>(request);
    }

    [HttpGet]
    [Route("{routeId}")]
    public Task<IActionResult> GetRouteById([FromRoute] int routeId)
    {
        var request = new GetRouteRequest { Id = routeId };
        return this.HandleRequest<GetRouteRequest, GetRouteResponse>(request);
    }

    [HttpPost]
    [Route("")]
    public Task<IActionResult> AddRoute([FromBody] AddRouteRequest request)
    {
        return this.HandleRequest<AddRouteRequest, AddRouteResponse>(request);
    }

    [HttpPut]
    [Route("{routeId}")]
    public Task<IActionResult> UpdateRoute([FromBody] UpdateRouteRequest request, [FromRoute] int routeId)
    {
        request.Id = routeId;
        return this.HandleRequest<UpdateRouteRequest, UpdateRouteResponse>(request);
    }

    [HttpPut]
    [Route("{routeId}/climbers/{climberId}")]
    public Task<IActionResult> AddRouteToUser([FromRoute] int routeId, int climberId, [FromBody] AddRouteToUserRequest request)
    {
        request.RouteId = routeId;
        request.ClimberId = climberId;
        return HandleRequest<AddRouteToUserRequest, AddRouteToUserResponse>(request);
    }

    [HttpDelete]
    [Route("{routeId}")]
    public Task<IActionResult> DeleteRoute([FromRoute] int routeId)
    {
        var request = new DeleteRouteRequest { Id = routeId };
        return this.HandleRequest<DeleteRouteRequest,  DeleteRouteResponse>(request);
    }
}
