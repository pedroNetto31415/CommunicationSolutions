using CommunicationSolutions.Domain.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationSolutions.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetBalance([FromBody]TWWebHookRequest twWebHookRequest)
        {
            return Ok();
        }
    }
}
