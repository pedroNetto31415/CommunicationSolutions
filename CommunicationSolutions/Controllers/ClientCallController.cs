using CommunicationSolutions.Domain.Model.Request;
using Microsoft.AspNetCore.Mvc;
using CommunicationSolutions.Domain.Interface.Service;

namespace CommunicationSolutions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientCallController : ControllerBase
    {
        private readonly IVoucherCardService _voucherCardService;

        public ClientCallController(IVoucherCardService voucherCardService)
        {
            _voucherCardService = voucherCardService;
        }
        [HttpPost]
        public IActionResult GetVoucherCardBalance([FromBody]ClientCallRequest clientCallRequest)
        {
            var response = _voucherCardService.GetBalance(clientCallRequest);

            if (response.ErrorId != 0)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
