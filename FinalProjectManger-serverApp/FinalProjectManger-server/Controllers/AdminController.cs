using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        static UsersDbContext context = new UsersDbContext();
        List<Admin> admins = context.Set<Admin>().ToList();
        List<ScheduleDates> scheduleDates = context.Set<ScheduleDates>().ToList();
        // GET: api/<AdminController>
        [HttpGet]
        public IEnumerable<Admin> Get()
        {
            return admins;
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public Admin Get([FromRoute]long id)
        {
            var admin = admins.Find(x => x.id == id);
            return admin;
        }


        [HttpPut("AddDates")]
        public bool AddDates([FromBody] ScheduleDatesDetails dates)
        {
            if (scheduleDates.Count > 0) return false;
            context.Add(new ScheduleDates(dates.date1, dates.date2));
            context.SaveChanges();
            return true;
        }

        [HttpGet("GetSchedulesTime")]
        public IEnumerable<ScheduleDates> GetSchedulesTime()
        {
            return scheduleDates;
        }

        [HttpDelete("DeleteSchedulesTime")]
        public bool DeleteSchedulesTime()
        {
            if (!scheduleDates.Any(x => x.id > 0))
                return false;

            context.Remove(scheduleDates.First());
            context.SaveChanges();
            return true;
        }
    }
}
