using Halevi.API.Helpers.Constants;

using Microsoft.AspNetCore.Mvc;

namespace Halevi.API.Controllers.v1.Base
{
    /// <summary>
    /// Base Controller Implementation.
    /// </summary>
    [Route($"api/{ApiConstants.API_V1}/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class BaseController : ControllerBase
    {
    }
}
