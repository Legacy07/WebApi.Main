namespace WebApi.Main
{
    using AutoMapper;
    using AutoMapper.Configuration;

    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(GetAutoMapperConfiguration());
        }

        public static MapperConfigurationExpression GetAutoMapperConfiguration()
        {
            var config = new MapperConfigurationExpression();

            config.AddProfiles(new[] { typeof(AutoMapperConfig) });

            return config;
        }
    }
}