using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobsonDevStatic.Api.Data;
using RobsonDevStatic.Api.Models;
using System.Threading.Tasks;

namespace RobsonDevStatic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeoplesController : ControllerBase
    {
        private readonly ContextData _contextData;

        public PeoplesController(ContextData contextData)
        {
            _contextData = contextData;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(People))]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(_contextData.People);
        }
    }
}
