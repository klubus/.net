using AutoMapper;
using FootballApp.Data.Entities;
using FootballApp.Dto.Dtos;
using FootballApp.Dto.Dtos.LeagueDtos;
using FootballApp.Dto.Dtos.TeamDtos;

namespace FootballApp.Service.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Team, TeamDto>();
                cfg.CreateMap<Team, TeamResponseDto>();
                cfg.CreateMap<CreateTeamDto, Team>();
                cfg.CreateMap<League, LeagueResponseDto>();
                cfg.CreateMap<CreateLeagueDto, League>();
            })
            .CreateMapper();

    }
}
