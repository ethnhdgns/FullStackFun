using Microsoft.AspNetCore.Mvc;
using FullStackFun.Data;

 namespace FullStackFun.Controllers
 {
     [Route("api/[controller]")]
     [ApiController]
     public class BowlersController : ControllerBase
     {
         private readonly BowlerDBContext _context;

         public BowlersController(BowlerDBContext context)
         {
             _context = context;
         }

         [HttpGet]
         public IEnumerable<Object> GetBowlers()
         {
             var bowlers = _context.Bowlers
                 .Where(b => b.TeamID == 1 || b.TeamID == 2)
                 .Select(b => new
                 {
                     BowlerName = $"{b.BowlerFirstName} {b.BowlerMiddleInit} {b.BowlerLastName}",
                     TeamName = b.TeamID,
                     Address = b.BowlerAddress,
                     City = b.BowlerCity,
                     State = b.BowlerState,
                     Zip = b.BowlerZip,
                     PhoneNumber = b.BowlerPhoneNumber
                 }).ToArray();
             
             return bowlers;

         }
     }
 }
