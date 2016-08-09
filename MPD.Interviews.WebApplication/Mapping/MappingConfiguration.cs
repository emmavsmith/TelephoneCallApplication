using AutoMapper;
using MPD.Interviews.WebApplication.Mapping.Profiles;

namespace MPD.Interviews.WebApplication.Mapping
{
    public static class MappingConfiguration
    {
        public static IMapper ConfigureMaps()
        {
            var mapperConfig = new MapperConfiguration(Configure);
            var mapper = mapperConfig.CreateMapper();
            Mapper.AssertConfigurationIsValid();
            return mapper;
        }

        private static void Configure(IConfiguration mapperConfiguration)
        {
            mapperConfiguration.AddProfile<DomainToViewModelMaps>();
            mapperConfiguration.AddProfile<ViewModelToDomainMaps>();   
        }
    }
}