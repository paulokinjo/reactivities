using MediatR;
using Reactivities.Domain;
using Reactivities.Persistence;

namespace Reactivities.Application.Activities;

public class Details
{
  public record Query(Guid Id) : IRequest<Activity>;

  public class Handler : IRequestHandler<Query, Activity?>
  {
    private DataContext Context { get; }

    public Handler(DataContext context)
    {
      Context = context;
    }

    public async Task<Activity?> Handle(Query request, CancellationToken cancellationToken) =>
      await Context.Activities.FindAsync(request.Id, cancellationToken);
  }
}

