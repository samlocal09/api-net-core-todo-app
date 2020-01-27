using AutoMapper;

namespace TodoListApp.Service.Common.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModel());
                cfg.AddProfile(new ViewModelToDomain());
            });
        }
    }
}