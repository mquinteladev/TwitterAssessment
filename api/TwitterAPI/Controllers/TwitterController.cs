using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace TwitterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TwitterController : Controller
    {
        private readonly ITwitterApiFacade _twitterApiFacade;
        public TwitterController(ITwitterApiFacade twitterApiFacade)
        {
            _twitterApiFacade = twitterApiFacade;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var response = _twitterApiFacade.GetTwitterDetail(id);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
