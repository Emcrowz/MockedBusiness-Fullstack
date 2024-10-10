using Microsoft.AspNetCore.Mvc;
using Serilog;
using Utilities.Constants;
using Web.Backend.Domain.DTO.Education;
using Web.Backend.Domain.Repositories.Contracts;

namespace Web.Backend.RestAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssignmentsController(IAssignmentsRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AssignmentReadDto>>> GetAssignmentAsync()
    {
        string reqType = Requests.GET;
        string methodName = nameof(GetAssignmentAsync);

        try
        {
            IEnumerable<AssignmentReadDto> data = await repository.GetAsync();

            Log.Information(LoggingMessage.Success(reqType, methodName));
            return Ok(data);
        }
        catch
        {
            Log.Error(LoggingMessage.Failure(reqType, methodName));
            return Problem(LoggingMessage.Failure(reqType, methodName), statusCode: 500);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AssignmentReadDto>> GetAssignmentAsync(string id)
    {
        string reqType = Requests.GET;
        string methodName = nameof(GetAssignmentAsync);

        if (string.IsNullOrWhiteSpace(id))
        {
            Log.Warning(LoggingMessage.BadRequest(reqType, methodName, id));
            return BadRequest();
        }

        AssignmentReadDto? data = await repository.GetAsync(id);

        if (data is null)
        {
            Log.Warning(LoggingMessage.NotFound(reqType, methodName, id));
            return NotFound();
        }

        Log.Information(LoggingMessage.Success(reqType, methodName, id));
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> PostAssignmentAsync(AssignmentCreateDto newModel)
    {
        string reqType = Requests.POST;
        string methodName = nameof(PostAssignmentAsync);

        if (newModel is null)
        {
            Log.Warning(LoggingMessage.BadRequest(reqType, methodName));
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            Log.Warning(LoggingMessage.BadRequest(reqType, methodName));
            return BadRequest();
        }

        if(await repository.AddAsync(newModel))
        {
            Log.Information(LoggingMessage.Success(reqType, methodName));
            return Ok();
        }
        else
        {
            Log.Error(LoggingMessage.Failure(reqType, methodName));
            return Problem(LoggingMessage.Failure(reqType, methodName), statusCode: 500);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAssignmentAsync(string id, [FromBody] AssignmentUpdateDto updateModel)
    {
        string reqType = Requests.PUT;
        string methodName = nameof(PutAssignmentAsync);

        if (string.IsNullOrWhiteSpace(id))
        {
            Log.Warning(LoggingMessage.BadRequest(reqType, methodName, id));
            return BadRequest();
        }

        if (id != updateModel.Id)
        {
            Log.Warning(LoggingMessage.BadRequest(reqType, methodName, id));
            return BadRequest();
        }

        if (await repository.UpdateAsync(id, updateModel))
        {
            Log.Information(LoggingMessage.Success(reqType, methodName, id));
            return Ok();
        }
        else
        {
            Log.Error(LoggingMessage.Failure(reqType, methodName));
            return Problem(LoggingMessage.Failure(reqType, methodName), statusCode: 500);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAssignmentAsync(string id)
    {
        string reqType = Requests.DELETE;
        string methodName = nameof(DeleteAssignmentAsync);

        if (string.IsNullOrWhiteSpace(id))
        {
            Log.Warning(LoggingMessage.BadRequest(reqType, methodName, id));
            return BadRequest();
        }

        if (await repository.DeleteAsync(id))
        {
            Log.Information(LoggingMessage.Success(reqType, methodName, id));
            return Ok();
        }
        else
        {
            Log.Warning(LoggingMessage.NotFound(reqType, methodName, id));
            return NotFound();
        }
    }
}
