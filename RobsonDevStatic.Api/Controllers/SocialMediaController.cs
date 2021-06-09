using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobsonDevStatic.Api.Data;
using RobsonDevStatic.Api.Models;
using System.Threading.Tasks;

namespace RobsonDevStatic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ContextData _contextData;

        public SocialMediaController(ContextData contextData)
        {
            _contextData = contextData;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SocialMedia))]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(_contextData.SocialMedia);
        }
    }
}
