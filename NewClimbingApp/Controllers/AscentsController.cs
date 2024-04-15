using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Ascents;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Ascents;

namespace NewClimbingApp.Controllers;

//[Authorize]
[ApiController]
[Route("[controller]")]
public class AscentsController : ApiControllerBase
{
    public AscentsController(IMediator mediator, ILogger<AscentsController> logger) : base(mediator, logger)
    {
        logger.LogInformation("We are in Ascents");
    }

 
    [HttpGet]
    [Route("{ascentId}")]
    public Task<IActionResult> GetAscentById([FromRoute] int ascentId)
    {
        var request = new GetAscentByIdRequest { Id = ascentId };
        return HandleRequest<GetAscentByIdRequest, GetAscentByIdResponse>(request);
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

}
