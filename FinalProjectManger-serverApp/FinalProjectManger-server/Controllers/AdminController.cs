using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        static UsersDbContext context = new UsersDbContext();
        
        // GET: api/<AdminController>
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Admin>>> ListAdmins()
        {
            return await context.Set<Admin>().ToListAsync();
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin([FromRoute] long id)
        {
            var admin = await context.Set<Admin>().Where(x => x.id == id).FirstOrDefaultAsync();
            if (admin == null)
                return NotFound();
            return Ok(admin);
        }
    }
}
