using Microsoft.AspNetCore.Mvc;
using Serilog;
using Utilities.Constants;
using Web.Backend.Domain.Models.SpecializationDetails;
using Web.Backend.Domain.Repositories.Contracts;

namespace Web.Backend.RestAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecializationsController(ISpecializationRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Specialization>>> GetAssignmentAsync()
    {
        string reqType = Requests.GET;
        string methodName = nameof(GetAssignmentAsync);

        try
        {
            IEnumerable<Specialization> data = await repository.GetAsync();

            Log.Information(LoggingMessages.Success(reqType, methodName));
            return Ok(data);
        }
        catch
        {
            Log.Error(LoggingMessages.Failure(reqType, methodName));
            return Problem(LoggingMessages.Failure(reqType, methodName), statusCode: 500);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Specialization>> GetAssignmentAsync(string id)
    {
        string reqType = Requests.GET;
        string methodName = nameof(GetAssignmentAsync);

        if (string.IsNullOrWhiteSpace(id))
        {
            Log.Warning(LoggingMessages.BadRequest(reqType, methodName, id));
            return BadRequest();
        }

        Specialization? data = await repository.GetAsync(id);

        if (data is null)
        {
            Log.Warning(LoggingMessages.NotFound(reqType, methodName, id));
            return NotFound();
        }

        Log.Information(LoggingMessages.Success(reqType, methodName, id));
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> PostAssignmentAsync(Specialization newModel)
    {
        string reqType = Requests.POST;
        string methodName = nameof(PostAssignmentAsync);

        if (newModel is null)
        {
            Log.Warning(LoggingMessages.BadRequest(reqType, methodName));
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            Log.Warning(LoggingMessages.BadRequest(reqType, methodName));
            return BadRequest();
        }

        if (await repository.AddAsync(newModel))
        {
            Log.Information(LoggingMessages.Success(reqType, methodName));
            return Ok();
        }
        else
        {
            Log.Error(LoggingMessages.Failure(reqType, methodName));
            return Problem(LoggingMessages.Failure(reqType, methodName), statusCode: 500);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAssignmentAsync(string id, [FromBody] Specialization updateModel)
    {
        string reqType = Requests.PUT;
        string methodName = nameof(PutAssignmentAsync);

        if (string.IsNullOrWhiteSpace(id))
        {
            Log.Warning(LoggingMessages.BadRequest(reqType, methodName, id));
            return BadRequest();
        }

        if (id != updateModel.Id)
        {
            Log.Warning(LoggingMessages.BadRequest(reqType, methodName, id));
            return BadRequest();
        }

        if (await repository.UpdateAsync(id, updateModel))
        {
            Log.Information(LoggingMessages.Success(reqType, methodName, id));
            return Ok();
        }
        else
        {
            Log.Error(LoggingMessages.Failure(reqType, methodName));
            return Problem(LoggingMessages.Failure(reqType, methodName), statusCode: 500);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAssignmentAsync(string id)
    {
        string reqType = Requests.DELETE;
        string methodName = nameof(DeleteAssignmentAsync);

        if (string.IsNullOrWhiteSpace(id))
        {
            Log.Warning(LoggingMessages.BadRequest(reqType, methodName, id));
            return BadRequest();
        }

        if (await repository.DeleteAsync(id))
        {
            Log.Information(LoggingMessages.Success(reqType, methodName, id));
            return Ok();
        }
        else
        {
            Log.Warning(LoggingMessages.NotFound(reqType, methodName, id));
            return NotFound();
        }
    }
}
