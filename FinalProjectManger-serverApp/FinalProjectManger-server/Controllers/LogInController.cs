﻿using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using NuGet.Protocol.Plugins;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        static UsersDbContext context = new UsersDbContext();
        List<Student> students = context.Set<Student>().ToList();
        List<Lecturer> lecturers = context.Set<Lecturer>().ToList();
        List<Admin> admins = context.Set<Admin>().ToList();

        // GET: api/<LogInController>
        [HttpGet("{id}/{password}")]
        public async Task<ActionResult<int>> Get([FromRoute]long id,[FromRoute] string password)
        {
            var admin = await context.Set<Admin>().Where(x => x.id == id).FirstOrDefaultAsync();
            if (admin != null && admin.password.Equals(password))
                return 0;
            var lecturer = await context.Set<Lecturer>().Where(x => x.id == id).FirstOrDefaultAsync();
            if (lecturer != null && lecturer.password.Equals(password))
                return 2;
            var student = await context.Set<Student>().Where(x => x.id == id).FirstOrDefaultAsync();
            if (student != null && student.password.Equals(password))
                return 1;
            return 3;
        }
    }
}
