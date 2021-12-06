using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace _02.CustomRequestHeaders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class BandsController : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("1.0")]
        [Route("Get")]
        public ActionResult Get()
        {
            var bands = GenerateBands();
            return Ok(bands);
        }

        [HttpGet]
        [SwaggerOperation("GetBand")]
        [Route("{bandId}")]
        public ActionResult Get(int bandId)
        {
            var bands = GenerateBands();
            var band = bands.FirstOrDefault(band => band.Id == bandId);
            return Ok(band);
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        [Route("Get")]
        public ActionResult Getv2()
        {
            var bands = GenerateBandsv2();
            return Ok(bands);
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
