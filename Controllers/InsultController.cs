using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Insulter.Data;
using Insulter.Models;

namespace ToDo.Api.Controllers;

[ApiController]
[Route("[controller]")]

public class InsultController : ControllerBase
{
    public readonly InsultContext _insultContext;
    public InsultController(InsultContext insultContext)
    {
        _insultContext = insultContext;
    }


    [HttpGet("All")]
    public async Task<ActionResult<List<Insult>>> GetAll()
    {
        List<Insult> allInsults = await _insultContext.insults.ToListAsync();
        return Ok(allInsults);
    }

    [HttpGet("Random")]
    public async Task<IActionResult> GetRandom([FromQuery] string name)
    {
        if (name.ToLower() == "corey")
        {
            return Ok(new { Insult = "That doesn't make any sense." });
        }
        else
        {
            Random random = new();
            List<Insult> allInsults = await _insultContext.insults.ToListAsync();
            var randomInsult = allInsults[random.Next(0, allInsults.Count)];
            var returnedInsult = $"{name} {randomInsult.ToString()}";
            var result = new { Insult = returnedInsult };
            return Ok(result);
        }
    }


    [HttpPost]
    public async Task<ActionResult<List<Insult>>> SaveInsult(string insult)
    {
        Insult newInsult = new();
        newInsult.insult = insult;
        _insultContext.insults.Add(newInsult);
        await _insultContext.SaveChangesAsync();
        return Ok(await GetAll());
    }

}



