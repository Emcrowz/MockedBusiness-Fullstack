using Microsoft.AspNetCore.Mvc;
using Serilog;
using Utilities.Constants;
using Web.Backend.Domain.DTO.Education;
using Web.Backend.Domain.Repositories.Contracts;

namespace Web.Backend.RestAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(ICoursesRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseReadDto>>> GetCourseAsync()
    {
        string reqType = Requests.GET;
        string methodName = nameof(GetCourseAsync);

        try
        {
            IEnumerable<CourseReadDto> data = await repository.GetAsync();

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
    public async Task<ActionResult<CourseReadDto>> GetCourseAsync(string id)
    {
        string reqType = Requests.GET;
        string methodName = nameof(GetCourseAsync);

        if (string.IsNullOrWhiteSpace(id))
        {
            Log.Warning(LoggingMessage.BadRequest(reqType, methodName, id));
            return BadRequest();
        }

        CourseReadDto? data = await repository.GetAsync(id);

        if (data is null)
        {
            Log.Warning(LoggingMessage.NotFound(reqType, methodName, id));
            return NotFound();
        }

        Log.Information(LoggingMessage.Success(reqType, methodName, id));
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> PostCourseAsync([FromBody] CourseCreateDto newModel)
    {
        string reqType = Requests.POST;
        string methodName = nameof(PostCourseAsync);

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
    public async Task<IActionResult> PutCourseCourse(string id, [FromBody] CourseUpdateDto updateModel)
    {
        string reqType = Requests.PUT;
        string methodName = nameof(PutCourseCourse);

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

        if(await repository.UpdateAsync(id, updateModel))
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
    public async Task<IActionResult> DeleteCourseAsync(string id)
    {
        string reqType = Requests.DELETE;
        string methodName = nameof(DeleteCourseAsync);

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
