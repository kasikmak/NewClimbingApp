using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Users;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Users;

namespace NewClimbingApp.Controllers
{
  //  [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        public UsersController(IMediator mediator, ILogger<UsersController> logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in Users");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetUsers([FromQuery] GetUsersRequest request)
        {
            return HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

      /*  [HttpGet]
        [Route("{userId}")]
        public Task<IActionResult> GetUserById([FromRoute] int userId)
        {
           var request = new GetUserRequest { UserId = userId};
           return this.HandleRequest<GetUserRequest, GetUserResponse>(request);
        }*/ 

        [HttpGet]
        [Route("{me}")]
        public Task<IActionResult> GetUserMe([FromRoute] string me)
        {
            var request = new GetUserMeRequest { Me = me };
            return HandleRequest<GetUserMeRequest, GetUserMeResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public  Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            return this.HandleRequest<AddUserRequest, AddUserResponse>(request);
        }

        [HttpPut]
        [Route("{userId}")]
        public  Task<IActionResult> UpdateUser([FromRoute] int userId, [FromBody] UpdateUserRequest request)
        {
            request.Id = userId;
            return this.HandleRequest<UpdateUserRequest, UpdateUserResponse>(request);
        }

        [HttpPut]
        [Route("{climberId}/routes/{routeId}")]
        public Task<IActionResult> AddRouteToUser([FromRoute] int routeId, int climberId, [FromBody] AddRouteToUserRequest request)
        {
            request.RouteId = routeId;
            request.ClimberId = climberId;
            return HandleRequest<AddRouteToUserRequest, AddRouteToUserResponse>(request);
        }

        [HttpDelete]
        [Route("{userId}")]
        public Task<IActionResult> DeleteUser([FromRoute] int userId)
        {
            var request = new DeleteUserRequest { Id = userId };
            return this.HandleRequest<DeleteUserRequest, DeleteUserResponse>(request);
        }
    }
}
