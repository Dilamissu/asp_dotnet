using DotnetPractice.Models;
using DotnetPractice.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetPractice.Controllers;

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