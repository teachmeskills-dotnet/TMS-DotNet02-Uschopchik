using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Uschopchik.Web.Contract;
using Uschopchik.Web.Interfaces;

namespace Uschopchik.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public MusicController(IRequestService requestService)
        {
            _requestService = requestService ?? throw new System.ArgumentNullException(nameof(requestService));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRequest request)
        {
            if (string.IsNullOrEmpty(request.UserInput))
            {
                return BadRequest();
            }

            var result = await _requestService.GetDataAsync(request.UserInput);
            return Ok(result);
        }
    }
}
