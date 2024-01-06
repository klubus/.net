using AutoMapper;
using FootballApp.Data.Entities;
using FootballApp.Dto.Dtos;

namespace FootballApp.Service.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Team, TeamDto>();
            })
            .CreateMapper();

    }
}
