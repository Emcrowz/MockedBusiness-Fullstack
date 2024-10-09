using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Backend.Domain.Models.Users;
using Web.Backend.RestAPI.Data;

namespace Web.Backend.RestAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssignmentsController(EducationDbContext context) : ControllerBase
{
    // GET: api/Assignments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignments()
    {
        return await context.Assignments.ToListAsync();
    }

    // GET: api/Assignments/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Assignment>> GetAssignment(int id)
    {
        var assignment = await context.Assignments.FindAsync(id);

        if (assignment == null)
        {
            return NotFound();
        }

        return assignment;
    }

    // PUT: api/Assignments/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAssignment(int id, Assignment assignment)
    {
        if (id != assignment.Id)
        {
            return BadRequest();
        }

        context.Entry(assignment).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AssignmentExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Assignments
    [HttpPost]
    public async Task<ActionResult<Assignment>> PostAssignment(Assignment assignment)
    {
        context.Assignments.Add(assignment);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetAssignment", new { id = assignment.Id }, assignment);
    }

    // DELETE: api/Assignments/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAssignment(int id)
    {
        var assignment = await context.Assignments.FindAsync(id);
        if (assignment == null)
        {
            return NotFound();
        }

        context.Assignments.Remove(assignment);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool AssignmentExists(int id)
    {
        return context.Assignments.Any(e => e.Id == id);
    }
}
