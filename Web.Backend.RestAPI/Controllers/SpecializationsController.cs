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
    public async Task<ActionResult<IEnumerable<Specialization>>> GetSpecializationsAsync()
    {
        string reqType = Requests.GET;
        string methodName = nameof(GetSpecializationsAsync);

        IEnumerable<Specialization> data = await repository.GetAllAsync();

        Log.Information(LoggingMessages.Success(reqType, methodName));
        return Ok(data);

        // return Problem(LoggingMessages.Failure(reqType, methodName), statusCode: 500)
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Specialization>> GetSpecializationsAsync(string id)
    {
        string reqType = Requests.GET;
        string methodName = nameof(GetSpecializationsAsync);

        if (string.IsNullOrWhiteSpace(id))
        {
            Log.Warning(LoggingMessages.BadRequest(reqType, methodName, id));
            return BadRequest();
        }

        Specialization? data = await repository.GetSingleAsync(id);

        if (data is null)
        {
            Log.Warning(LoggingMessages.NotFound(reqType, methodName, id));
            return NotFound();
        }

        Log.Information(LoggingMessages.Success(reqType, methodName, id));
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> PostSpecializationAsync(Specialization newModel)
    {
        string reqType = Requests.POST;
        string methodName = nameof(PostSpecializationAsync);

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
        
        try
        {
            await repository.AddAsync(newModel);
            Log.Information(LoggingMessages.Success(reqType, methodName));
            return Ok();
        }
        catch (Exception e)
        {
            Log.Error(LoggingMessages.Failure(reqType, methodName, e.Message));
            return Problem(LoggingMessages.Failure(reqType, methodName, e.Message), statusCode: 500);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutSpecializationAsync(string id, [FromBody] Specialization updateModel)
    {
        string reqType = Requests.PUT;
        string methodName = nameof(PutSpecializationAsync);

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

        try
        {
            await repository.UpdateAsync(updateModel);
            Log.Information(LoggingMessages.Success(reqType, methodName, id));
            return Ok();
        }
        catch (Exception e)
        {
            Log.Error(LoggingMessages.Failure(reqType, methodName));
            return Problem(LoggingMessages.Failure(reqType, methodName), statusCode: 500);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSpecializationAsync(string id)
    {
        string reqType = Requests.DELETE;
        string methodName = nameof(DeleteSpecializationAsync);

        if (string.IsNullOrWhiteSpace(id))
        {
            Log.Warning(LoggingMessages.BadRequest(reqType, methodName, id));
            return BadRequest();
        }

        try
        {
            await repository.DeleteAsync(id);
            Log.Information(LoggingMessages.Success(reqType, methodName, id));
            return Ok();
        }
        catch (Exception e)
        {
            Log.Warning(LoggingMessages.NotFound(reqType, methodName, id));
            return NotFound();
        }
    }
}
