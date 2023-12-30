using AutoMapper;
using Football.Core.Domain;
using Football.Infrastructure.DTO;

namespace Football.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Team, TeamDTO>();
            })
            .CreateMapper();
    }
}
