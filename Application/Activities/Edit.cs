using AutoMapper;
using MediatR;
using Reactivities.Domain;
using Reactivities.Persistence;

namespace Reactivities.Application.Activities;

public class Edit
{
  public record Command(Activity Activity) : IRequest;

  public class Handler : IRequestHandler<Command>
  {
    private DataContext Context { get; }
    private IMapper Mapper { get; }

    public Handler(DataContext context, IMapper mapper)
    {
      Context = context;
      Mapper = mapper;
    }

    public async Task Handle(Command request, CancellationToken cancellationToken)
    {
      Activity? activity = await Context.Activities.FindAsync(request.Activity.Id);

      Mapper.Map(request.Activity, activity);

      await Context.SaveChangesAsync();
    }
  }
}
