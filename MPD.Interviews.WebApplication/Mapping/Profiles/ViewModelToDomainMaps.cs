using AutoMapper;
using MPD.Interviews.Domain;
using MPD.Interviews.WebApplication.ViewModels;

namespace MPD.Interviews.WebApplication.Mapping.Profiles
{
    public class ViewModelToDomainMaps : Profile
    {
        protected override void Configure()
        {
            CreateMap<CallDetailViewModel, CallDetails>();
            CreateMap<UserViewModel, User>();
            CreateMap<CallSearchTermsViewModel, CallSearchTerms>();
        }
    }
}