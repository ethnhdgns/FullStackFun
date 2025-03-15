using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using FullStackFun.Data;

[ApiController]
[Route("api/[controller]")]
public class BowlersController : ControllerBase
{
    private readonly BowlerDbContext _context;

    public BowlersController(BowlerDbContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetBowler")]
    public ActionResult<IEnumerable<Bowler>> Get()
    {
        try
        {
            var bowlerList = _context.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team != null && (b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks"))
                .ToList();

            return Ok(bowlerList);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error fetching bowlers: {ex.Message}");
        }
    }
}