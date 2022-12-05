using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        static UsersDbContext context = new UsersDbContext();
        List<User> users = context.Set<User>().ToList();
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(long id)
        {
            var user = users.Find(x => x.Id == id);
            return user;

        }

        // POST api/<UserController>
        public bool Post(long id, [FromBody] string name)
        {
            if (users.Any(x => x.Id == id))
            {
                return false;
            }
            User user = users.Find(x => x.Id == id);
            context.Remove(user);
            user.Name = name;
            context.Add(user);
            context.SaveChanges();
            return true;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string name)
        {

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public bool Delete(long id)
        {
            if(users.Any(x=>x.Id == id))
            {
                User userToDelete = users.Find(x=>x.Id == id);
                context.Remove(userToDelete);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
