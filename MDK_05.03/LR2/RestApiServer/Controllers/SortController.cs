using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LabsShareLibrary;

namespace RestApiServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SortController : ControllerBase
    {
        [HttpPost]
        public ActionResult<List<Dictionary<string, string>>> Post([FromBody] List<Dictionary<string, string>> data)
        {
            if (data == null)
            {
                return BadRequest("Input data cannot be null.");
            }

            Lab2.Sort(data);
            return Ok(data);
        }
    }
}
