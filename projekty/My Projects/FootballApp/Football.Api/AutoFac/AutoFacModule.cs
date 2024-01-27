using Autofac;
using FootballApp.Service.AutoFac;

namespace Football.Api.AutoFac
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ServiceModule>();
        }
    }
}
