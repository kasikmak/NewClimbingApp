using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Ascents;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Ascents;

namespace NewClimbingApp.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AscentsController : ApiControllerBase
{
    public AscentsController(IMediator mediator, ILogger<AscentsController> logger) : base(mediator, logger)
    {
        logger.LogInformation("We are in Ascents");
    }
    [HttpGet]
    [Route("")]
    public Task<IActionResult> GetAllAscents([FromQuery] GetAllAscentsRequest request)
    {
        return HandleRequest<GetAllAscentsRequest, GetAllAscentsResponse>(request);
    }
 
    [HttpGet]
    [Route("route/{routeId}")]
    public Task<IActionResult> GetAscentById([FromRoute] int routeId)
    {
        var request = new GetAscentByRouteIdRequest { RouteId = routeId };
        return HandleRequest<GetAscentByRouteIdRequest, GetAscentsByRouteIdResponse>(request);
    }

    [HttpGet]
    [Route("ascents/{ascentRating}")]
    public Task<IActionResult> GetAscentsByRating([FromRoute] int ascentRating)
    {
        var request = new GetAscentsByRatingRequest { Rating = ascentRating };
        return HandleRequest<GetAscentsByRatingRequest, GetAscentByRatingResponse>(request);
    }

    [HttpPut]
    [Route("{ascentId}")]
    public Task<IActionResult> UpdateAscent([FromRoute] int ascentId, [FromBody] UpdateAscentRequest request)
    {
        request.Id = ascentId;
        return HandleRequest<UpdateAscentRequest, UpdateAscentResponse>(request);
    }

    [HttpPost]
    [Route("")]
    public Task<IActionResult> AddAscent([FromBody] AddAscentRequest request)
    {       
        return HandleRequest<AddAscentRequest, AddAscentResponse>(request);
    }

    [HttpDelete]
    [Route("{ascentId}")]
    public Task<IActionResult> DeleteAscent([FromRoute] int ascentId)
    {
        var request = new DeleteAscentRequest { Id = ascentId };
        return this.HandleRequest<DeleteAscentRequest, DeleteAscentResponse>(request);
    }
}
