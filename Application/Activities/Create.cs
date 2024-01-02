using MediatR;
using Reactivities.Domain;
using Reactivities.Persistence;

namespace Reactivities.Application.Activities;

public class Create
{
  public record Command(Activity Activity) : IRequest;

  public class Handler : IRequestHandler<Command>
  {
    private DataContext Context { get; }

    public Handler(DataContext context)
    {
      Context = context;
    }

    public async Task Handle(Command request, CancellationToken cancellationToken)
    {
      Context.Activities.Add(request.Activity);
      await Context.SaveChangesAsync();
    }
  }
}
