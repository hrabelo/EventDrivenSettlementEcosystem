using System.Threading.Tasks;
using ESDE.Custody.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ESDE.Custody.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustodyController : ControllerBase
    {
        private readonly ICustodyApplication _app;

        public CustodyController(ICustodyApplication app)
        {
            _app = app;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var custodies = await _app.GetAll();
           return Ok(custodies);
        }
    }
}
