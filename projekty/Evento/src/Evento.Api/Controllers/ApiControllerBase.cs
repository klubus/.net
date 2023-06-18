using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiControllerBase : Controller
    {
        protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
            Guid.Parse(User.Identity.Name) :
            Guid.Empty;
    }
}
