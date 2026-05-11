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