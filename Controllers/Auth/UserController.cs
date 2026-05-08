using asp_dotnet.Models;
using asp_dotnet.Services;
using asp_dotnet.Services.Auth;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace asp_dotnet.Controllers.Auth;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public UserController()
    {
        UserService.Open();
    }

    [HttpGet("test_open")]
    public ActionResult OpenDB()
    {
        try
        {
            UserService.Open();
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        return Ok();
    }

    [HttpGet("test_close")]
    public ActionResult CloseDB()
    {
        try
        {
            UserService.Close();
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        return Ok();
    }
}