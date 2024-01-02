using MediatR;
using Reactivities.Domain;
using Reactivities.Persistence;

namespace Reactivities.Application.Activities;

public class Delete
{
  public record Command(Guid Id) : IRequest;

  public class Handler : IRequestHandler<Command>
  {
    private DataContext DataContext { get; }

    public Handler(DataContext dataContext)
    {
      DataContext = dataContext;
    }

    public async Task Handle(Command request, CancellationToken cancellationToken)
    {
      Activity? activity = await DataContext.Activities.FindAsync(request.Id);

      _ = DataContext.Remove(activity);

      await DataContext.SaveChangesAsync();
    }
  }
}