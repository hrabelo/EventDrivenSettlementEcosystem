using System;
using System.Threading.Tasks;
using ESDE.AssetCheck.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ESDE.AssetCheck.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly IAssetCheckApplication _app;
        private readonly IEventBus _bus;

        public AssetController(IAssetCheckApplication app, IEventBus bus)
        {
            _app = app;
            _bus = bus;
        }

        [HttpGet("/getallpastduedate/{referenceDate}")]
        public async Task<IActionResult> GetAllPastDueDate(DateTime referenceDate)
        {
            return Ok(await _app.GetAssetPastDueDate(referenceDate));
        }

        [HttpPost("/processallpastduedate")]
        public async Task<IActionResult> Process(DateTime referenceDate)
        {
            var data = await _app.GetAssetPastDueDate(referenceDate);

            await _bus.Publish(data);

            return NoContent(); 
        }
    }
}
