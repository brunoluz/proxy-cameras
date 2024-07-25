using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace proxy_cameras.Controllers
{
    [ApiController]
    [Route("[controller]/{camera}.jpg")]
    public class CamerasController : ControllerBase
    {
        private readonly ILogger<CamerasController> _logger;
        private readonly ICamerasConfiguration _camerasConfiguration;

        public CamerasController(ILogger<CamerasController> logger, ICamerasConfiguration camerasConfiguration)
        {
            _logger = logger;
            _camerasConfiguration = camerasConfiguration;
        }
       

        [HttpGet]
        public IActionResult Get(string camera)
        {
            var camerasetting = _camerasConfiguration.CameraSettings
                .Where(camerasetting => camerasetting.Name == camera)
                .FirstOrDefault();

            if (camerasetting == null)
                return NotFound("Not found.");

            var request = new AuthenticatedRequest(_camerasConfiguration);
            var image = request.GetImage(camerasetting);

            return Content(image);

        }
    }
}
