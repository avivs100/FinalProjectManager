using Data;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        static UsersDbContext context = new UsersDbContext();
        List<User> users = context.Set<User>().ToList();
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(Guid id)
        {
            var user = users.Find(x => x.Id == id);
            return user;
        }

        // POST api/<UsersController>
        [HttpPost]
        public bool Post(Guid id, [FromBody] string name)
        {
            if (!(users.Any(x => x.Id == id)))
            {
                return false;
            }
            User user = users.Find(x => x.Id == id);
            context.Remove(user);
            context.SaveChanges();
            user.Name = name;
            context.Add(user);
            context.SaveChanges();
            return true;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] string name)
        {
            User user = new User();
            user.Id = id;
            user.Name = name;
            context.Add(user);
            context.SaveChanges();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            if (users.Any(x => x.Id == id))
            {
                User userToDelete = users.Find(x => x.Id == id);
                context.Remove(userToDelete);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
