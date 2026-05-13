using DotnetPractice.Models;
using DotnetPractice.Services;
using DotnetPractice.Services.Auth;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotnetPractice.Controllers.Auth;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public UserController()
    {
    }

    [HttpPost("test")]
    public ActionResult Test(User user)
    {
        return Ok();
    }

    [HttpPost("register")]
    public ActionResult Register(User user)
    {
        UserService.Register(user);
        return Ok();
    }

    [HttpPost("deleteAccount")]
    public ActionResult DeleteAccount(User user)
    {
        UserService.DeleteAccount(user);
        return Ok();
    }

    [HttpGet("searchAccount/{userID}")]
    public ActionResult<User?> SearchAccount(string userID)
    {
        return UserService.SearchAccount(userID);
    }  
}