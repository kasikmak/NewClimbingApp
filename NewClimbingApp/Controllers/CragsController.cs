using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Crags;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Crags;

namespace NewClimbingApp.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CragsController : ApiControllerBase
{
    public CragsController(IMediator mediator, ILogger<CragsController> logger) : base(mediator, logger)
    {
        logger.LogInformation("We are in Crags");
    }

    [HttpGet]
    [Route("")]
    public Task<IActionResult> GetAllCrags([FromQuery] GetAllCragsRequest request)
    {
        return HandleRequest<GetAllCragsRequest, GetAllCragsResponse>(request);
    }

    [HttpGet]
    [Route("{cragId}")]
    public Task<IActionResult> GetCragById([FromRoute] int cragId)
    {
        var request = new GetCragByIdRequest { Id =  cragId };
        return HandleRequest<GetCragByIdRequest, GetCragByIdResponse>(request);
    }

    [HttpPost]
    [Route("")]
    public Task<IActionResult> AddCrag([FromBody] AddCragRequest request)
    {
        return HandleRequest<AddCragRequest, AddCragResponse>(request);
    }

    [HttpPut]
    [Route("{cragId}")]
    public Task<IActionResult> UpdateCrag([FromRoute] int cragId, [FromBody]  UpdateCragRequest request)
    {
        request.Id = cragId;
        return HandleRequest<UpdateCragRequest, UpdateCragResponse>(request);
    }

    [HttpPut]
    [Route("{cragId}/routes/{routeId}")]
    public Task<IActionResult> AddRouteToCrag([FromRoute] int cragId, int routeId, [FromBody] AddRouteToCragRequest request)
    {
        request.RouteId = routeId;
        request.CragId = cragId;
        return HandleRequest<AddRouteToCragRequest, AddRouteToCragResponse>(request);
    }

    [HttpDelete]
    [Route("{cragId}")]
    public Task<IActionResult> DeleteCrag([FromRoute] int cragId)
    {
        var request = new DeleteCragRequest { Id = cragId };
        return HandleRequest<DeleteCragRequest, DeleteCragResponse>(request);
    }
}
