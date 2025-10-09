using Microsoft.AspNetCore.Mvc;
using System;

namespace Proizv2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DerivativesController : ControllerBase
    {
        // Модель для запроса, чтобы принимать 'x' из тела POST-запроса
        public class DerivativeRequest
        {
            public double X { get; set; }
        }

        // Модель для ответа
        public class DerivativeResponse
        {
            public double Result { get; set; }
        }

        // POST api/derivatives/a
        [HttpPost("a")]
        public ActionResult<DerivativeResponse> CalculateVariantA([FromBody] DerivativeRequest request)
        {
            try
            {
                if (request.X <= 0)
                {
                    return BadRequest(new { message = "Input x must be > 0 for ln(x)." });
                }
                // y'' = ln(x)
                double result = Math.Log(request.X);
                return Ok(new DerivativeResponse { Result = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // POST api/derivatives/v
        [HttpPost("v")]
        public ActionResult<DerivativeResponse> CalculateVariantV([FromBody] DerivativeRequest request)
        {
            try
            {
                // y'' = x*sin(3x)
                double result = request.X * Math.Sin(3 * request.X);
                return Ok(new DerivativeResponse { Result = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
