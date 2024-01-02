using MediatR;
using Microsoft.EntityFrameworkCore;
using Reactivities.Domain;
using Reactivities.Persistence;

namespace Reactivities.Application.Activities;
public class List
{
  public record Query : IRequest<List<Activity>>;

  public class Handler : IRequestHandler<Query, List<Activity>>
  {
    private DataContext Context { get; }

    public Handler(DataContext context)
    {
      Context = context;
    }

    public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken) =>
      await Context.Activities.ToListAsync(cancellationToken);
  }
}
