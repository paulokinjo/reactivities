using System.Formats.Asn1;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reactivities.Application.Activities;
using Reactivities.Domain;
using Reactivities.Persistence;

namespace API.Controllers;

public class ActivitiesController : BaseApiController<ActivitiesController>
{
  public ActivitiesController(IMediator mediator, ILogger<ActivitiesController> logger)
      : base(mediator, logger)
  {
  }

  [HttpGet]
  public async Task<IActionResult> GetActivities(CancellationToken cancellationToken)
  {
    Logger.LogInformation($"Calling {nameof(GetActivities)}");
    return Ok(await Mediator.Send(new List.Query(), cancellationToken));
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetActivity(Guid id)
  {
    Logger.LogInformation($"Calling {nameof(GetActivity)} with id {id}");
    Activity activity = await Mediator.Send(new Details.Query(id));
    if (activity is null)
    {
      return NotFound();
    }

    return Ok(await Mediator.Send(new Details.Query(id)));
  }

  [HttpPost]
  public async Task<IActionResult> CreateActivity(Activity activity)
  {
    await Mediator.Send(new Create.Command(activity));
    var routeValues = new { id = activity.Id };
    return CreatedAtAction(nameof(GetActivity), routeValues, activity);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> EditActivity(Guid id, [FromBody] Activity activity)
  {
    activity.Id = id;
    await Mediator.Send(new Edit.Command(activity));
    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteActivity(Guid id)
  {
    await Mediator.Send(new Delete.Command(id));
    return NoContent();
  }
}
