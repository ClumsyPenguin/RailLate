using Microsoft.AspNetCore.Mvc;
using RailLate.Worker.Services;

namespace RailLate.REST.Business.Background.Controllers;

[Route("[controller]")]
public class BackgroundController(ITaskService taskService) : ControllerBase
{
    public record PeriodicHostedServiceStateDto(bool IsEnabled);
    
    [HttpGet]
    public async Task<IActionResult> GetTaskStatuses(CancellationToken cancellationToken)
    {
        var taskStatuses = await taskService.GetAllTasksAsync(cancellationToken).ConfigureAwait(false);
        return Ok(taskStatuses);
    }
    
    [HttpPatch("{taskName}")]
    public async Task<IActionResult> Patch(string taskName, [FromBody] PeriodicHostedServiceStateDto stateDto, CancellationToken cancellationToken)
    {
        var taskStateUpdated = await taskService.SetStateTaskAsync(taskName, stateDto.IsEnabled, cancellationToken).ConfigureAwait(false);

        if (taskStateUpdated)
        {
            return Ok(new { message = $"Task {taskName} state updated.", stateDto.IsEnabled });
        }
        
        return NotFound(new { message = $"Task instance or type for {taskName} not found." });
    }
}
