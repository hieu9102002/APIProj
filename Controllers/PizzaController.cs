using APIProj.Models;
using APIProj.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIProj.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {

    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaServices.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        Pizza pizza = PizzaServices.Get(id);

        if (pizza is null) return NotFound();

        return pizza;
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaServices.Add(pizza);
        return CreatedAtAction(nameof(Create), new {id = pizza.Id}, pizza);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id) return BadRequest();

        Pizza existingPizza = PizzaServices.Get(id);

        if(existingPizza is null) return NotFound();

        PizzaServices.Update(pizza);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Pizza pizza = PizzaServices.Get(id);

        if(pizza is null) return NotFound();

        PizzaServices.Delete(id);

        return NoContent();
    }
}