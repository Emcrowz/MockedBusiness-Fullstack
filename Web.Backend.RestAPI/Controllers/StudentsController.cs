using Microsoft.AspNetCore.Mvc;
using Serilog;
using Utilities.Constants;
using Web.Backend.Domain.DTO.Users;
using Web.Backend.Domain.Repositories.Contracts;

namespace Web.Backend.RestAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController(IStudentsRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentReadDto>>> GetStudentAsync()
    {
        string reqType = Requests.GET;
        string methodName = nameof(GetStudentAsync);

        try
        {
            IEnumerable<StudentReadDto> data = await repository.GetAsync();

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
    public async Task<ActionResult<StudentReadDto>> GetStudentAsync(string id)
    {
        string reqType = Requests.GET;
        string methodName = nameof(GetStudentAsync);

        if (string.IsNullOrWhiteSpace(id))
        {
            Log.Warning(LoggingMessage.BadRequest(reqType, methodName, id));
            return BadRequest();
        }

        StudentReadDto? data = await repository.GetAsync(id);

        if (data is null)
        {
            Log.Warning(LoggingMessage.NotFound(reqType, methodName, id));
            return NotFound();
        }

        Log.Information(LoggingMessage.Success(reqType, methodName, id));
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> PostStudentAsync([FromBody] StudentCreateDto newModel)
    {
        string reqType = Requests.POST;
        string methodName = nameof(PostStudentAsync);

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

        if (await repository.AddAsync(newModel))
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
    public async Task<IActionResult> PutStudentAsync(string id, [FromBody] StudentUpdateDto updateModel)
    {
        string reqType = Requests.PUT;
        string methodName = nameof(PutStudentAsync);

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
    public async Task<IActionResult> DeleteStudentAsync(string id)
    {
        string reqType = Requests.DELETE;
        string methodName = nameof(DeleteStudentAsync);

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
