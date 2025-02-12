using Application.Users.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Infrastructure;
using Swashbuckle.AspNetCore.Annotations;
using Web.Api.Extensions;


namespace Web.Api.Controllers;

[Route("api/users")]
[ApiController]
[SwaggerTag("Users")]
public class UsersController : ControllerBase
{
    private readonly ISender _sender;// MediatR 사용

    public UsersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetUserByIdQuery(id), cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }
    [HttpGet("test/{userIdx}")]
    //[ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    //[SwaggerOperation(Summary = "Get User by ID", Description = "Fetches user details by ID", Tags = new[] { "Users" })]
    public async Task<IResult> GetById(int userIdx, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery(userIdx);
        Result<UserResponse> result = await _sender.Send(query, cancellationToken);

        // 수정된 Match 사용
        return result.Match(Results.Ok, CustomResults.Problem);
    }


    //private readonly ILogger<UsersController> _logger;
    //public UsersController(ILogger<UsersController> logger)
    //{
    //    _logger = logger;
    //}
    //public UsersController(IEndpointRouteBuilder app)//ILogger<UsersController> logger, ISender sender)
    //{
    //_logger = logger;
    //_sender = sender;    
    //}

    //[HttpGet("{userIdx}")]
    //[ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    //[SwaggerOperation(Summary = "Get User by ID", Description = "Fetches user details by ID", Tags = new[] { "Users" })]
    //public async Task<IActionResult> GetById(int userIdx)
    //{
    //    var query = new GetUserByIdQuery(userIdx);
    //    //Result<UserResponse> result = await sender.Send(query, cancellationToken);
    //
    //    // 수정된 Match 사용
    //    return Ok(userIdx);
    //}

    //

    /*public UsersController(IEndpointRouteBuilder app)//ILogger<UsersController> logger, ISender sender)
    {
        //_logger = logger;
        //_sender = sender;
        string a = app.ToString();
    }

    [HttpGet("{userIdx}")]
    //[ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "Get User by ID", Description = "Fetches user details by ID", Tags = new[] { "Users" })]
    public async Task<IResult> GetById(int userIdx, ISender sender, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery(userIdx);
        Result<UserResponse> result = await sender.Send(query, cancellationToken);

        // 수정된 Match 사용
        return result.Match(Results.Ok, CustomResults.Problem);
    }*/
}
