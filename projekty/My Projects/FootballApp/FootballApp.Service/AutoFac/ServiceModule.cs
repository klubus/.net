using Autofac;
using FootballApp.Service.Interface.Services;
using FootballApp.Service.Services;

namespace FootballApp.Service.AutoFac
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TeamService>().As<ITeamService>();
            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}
