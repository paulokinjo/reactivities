
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
public class BaseApiController<T> : ControllerBase
{
  protected ILogger<ActivitiesController> Logger { get; }
  protected IMediator Mediator { get; }

  public BaseApiController(IMediator mediator, ILogger<ActivitiesController> logger)
  {
    Mediator = mediator;
    Logger = logger;
  }
}