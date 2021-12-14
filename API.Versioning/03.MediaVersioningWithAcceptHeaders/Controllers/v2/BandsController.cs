using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _03.MediaVersioningWithAcceptHeaders.Controllers.v2
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class BandsController : ControllerBase
    {
        [HttpGet]
        [Route("Get")]
        [MapToApiVersion("2.0")]
        public ActionResult Getv2()
        {
            var bands = GenerateBandsv2();
            return Ok(bands);
        }

        private IEnumerable<Band> GenerateBandsv2()
        {
            return new List<Band>
            {
                new Band
                {
                    Id = 1,
                    Names = new List<string> { "GHI" },
                    FoundedYear = 5
                },
                new Band
                {
                    Id = 2,
                    Names = new List<string> { "JKL" },
                    FoundedYear = 6
                },
            };
        }
    }
}
