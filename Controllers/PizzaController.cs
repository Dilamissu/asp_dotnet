using asp_dotnet.Models;
using asp_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace asp_dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
        
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);

        if(pizza == null)
        {
            return NotFound();
        }

        return pizza;
    }
}