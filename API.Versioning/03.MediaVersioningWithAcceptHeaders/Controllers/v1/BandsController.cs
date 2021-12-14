using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace _03.MediaVersioningWithAcceptHeaders.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BandsController : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("1.0")]
        [Route("Get")]
        public ActionResult<IEnumerable<Band>> Get()
        {
            var bands = GenerateBands();
            return Ok(bands);
        }

        [HttpGet]
        [SwaggerOperation("GetBand")]
        [Route("{bandId}")]
        public ActionResult<Band> Get(int bandId)
        {
            var bands = GenerateBands();
            var band = bands.FirstOrDefault(band => band.Id == bandId);
            return Ok(band);
        }

        private IEnumerable<Band> GenerateBands()
        {
            return new List<Band>
            {
                new Band
                {
                    Id = 1,
                    Names = new List<string> { "ABC" },
                    FoundedYear = 5
                },
                new Band
                {
                    Id = 2,
                    Names = new List<string> { "DEF" },
                    FoundedYear = 6
                },
                new Band
                {
                    Id = 3,
                    Names = new List<string> { "XYZ" },
                    FoundedYear = 7
                }
            };
        }
    }
}
