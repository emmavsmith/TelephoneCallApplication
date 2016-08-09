using AutoMapper;
using MPD.Interviews.Domain;
using MPD.Interviews.WebApplication.ViewModels;

namespace MPD.Interviews.WebApplication.Mapping.Profiles
{
    public class DomainToViewModelMaps : Profile
    {
        protected override void Configure()
        {
            CreateMap<CallDetails, CallDetailViewModel>();
            CreateMap<User, UserViewModel>()
                .ForMember(d => d.FullName, opt => opt.Ignore());
        }
    }
}