//using Data;
//using Domain;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualBasic;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace FinalProjectManger_server.Controllers;

//[Route("api/[controller]")]
//[ApiController]
//public class ConstraintController : ControllerBase
//{
//    [HttpGet]
//    public async Task<ActionResult<IReadOnlyList<Constraint>>> ListAdmins()
//    {
//        var context = new UsersDbContext();
//        return await context.Set<Constraint>().ToListAsync();
//    }
//    [HttpPost("AddConstraint{lecturerID}")]
//    public async Task<ActionResult<Constraint>> AddConstraint([FromRoute] long lecturerID, [FromBody] ConstraintDetails constraint)
//    {
//        var context = new UsersDbContext();
//        var lecturer = await context.Set<Lecturer>().Where(x => x.id == lecturerID).FirstOrDefaultAsync();
//        if (lecturer == null) return NotFound();
//        var constraintToAdd = new Constraint(constraint.Year, constraint.Month, constraint.Day, constraint.Hour, constraint.Minute, constraint.Second);
//        lecturer.constraints.Add(constraintToAdd);
//        context.Set<Constraint>().Add(constraintToAdd);
//        await context.SaveChangesAsync();
//        return Ok();
//    }

//    [HttpDelete("{lecturerID}")]
//    public async Task<ActionResult<Constraint>> Delete([FromRoute] int lecturerID, [FromBody] Guid constraintID)
//    {
//        var context = new UsersDbContext();
//        var lecturer = await context.Set<Lecturer>().Where(x => x.id == lecturerID).FirstOrDefaultAsync();
//        var constraints = await context.Set<Constraint>().ToListAsync();
//        if (lecturer == null) return NotFound();
//        var conToDel = await context.Set<Constraint>().Where(x => x.id == constraintID).FirstOrDefaultAsync();
//        if (conToDel == null) return NotFound();
//        var isRemoved = lecturer.constraints.Remove(conToDel);
//        context.Remove(conToDel);
//        await context.SaveChangesAsync();
//        return Ok(isRemoved);
//    }
//}

