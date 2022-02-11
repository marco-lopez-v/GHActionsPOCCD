using GHActionsPOCCD.Service;
using Microsoft.AspNetCore.Mvc;

namespace GHActionsPOCCD.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class GHActionsPOCController : ControllerBase
    {
        private GHActionsService _gHActionsService;
        public GHActionsPOCController()
        {
            _gHActionsService = new GHActionsService();
        }
        [HttpPost("checkAmigos")]
        public string HealthCheck()
        {
            return _gHActionsService.Amigos();
        }
    }
}
