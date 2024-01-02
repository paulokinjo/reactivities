using AutoMapper;
using Reactivities.Domain;

namespace Application.Core;
public class MappingProfiles : Profile
{
  public MappingProfiles()
  {
    CreateMap<Activity, Activity>();
  }
}
