using System.Threading.Tasks;
using DataConverter.Request;
using DataConverter.Response;
using DataConverter.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataConverter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private readonly IDataConverterService _dataConverterService;

        public ConverterController(IDataConverterService dataConverterService)
        {
            _dataConverterService = dataConverterService;
        }

        /// <summary>
        /// Inserts JSON into database
        /// </summary>
        /// <param name="dataConverterRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Convert")]
        [ProducesResponseType(typeof(DataConverterResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> DataConverter([FromBody] DataConverterRequest dataConverterRequest)
        {
            if (dataConverterRequest != null)
            {
                DataConverterResponse dataConverterResponse =
                    await _dataConverterService.ConvertData(dataConverterRequest);
                return new JsonResult(dataConverterResponse) { StatusCode = (int)dataConverterResponse.statusCode };
            }

            return BadRequest();
        }

    }
}