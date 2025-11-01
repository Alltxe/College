using Microsoft.AspNetCore.Mvc;
using MathServer.Services;

namespace MathServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MathController : ControllerBase
    {
        private readonly MathService _mathService;

        public MathController()
        {
            _mathService = new MathService();
        }

        /// <summary>
        /// GET api/math/integral?x=2&lowerLimit=0
        /// Вычислить определенный интеграл (задача 38)
        /// </summary>
        [HttpGet("integral")]
        public ActionResult<double> GetIntegral([FromQuery] double x, [FromQuery] double lowerLimit = 0)
        {
            try
            {
                var result = _mathService.CalculateIntegral(x, lowerLimit);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// POST api/math/integral
        /// Вычислить определенный интеграл (задача 38)
        /// </summary>
        [HttpPost("integral")]
        public ActionResult<double> PostIntegral([FromBody] IntegralRequest request)
        {
            try
            {
                var result = _mathService.CalculateIntegral(request.X, request.LowerLimit);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// GET api/math/diff-eq-43?x=1&c1=1&c2=0
        /// Решить дифференциальное уравнение 43
        /// </summary>
        [HttpGet("diff-eq-43")]
        public ActionResult<double> GetDifferentialEquation43(
            [FromQuery] double x, 
            [FromQuery] double c1, 
            [FromQuery] double c2)
        {
            try
            {
                var result = _mathService.SolveDifferentialEquation43(x, c1, c2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// POST api/math/diff-eq-43
        /// Решить дифференциальное уравнение 43
        /// </summary>
        [HttpPost("diff-eq-43")]
        public ActionResult<double> PostDifferentialEquation43([FromBody] DiffEqRequest request)
        {
            try
            {
                var result = _mathService.SolveDifferentialEquation43(request.X, request.C1, request.C2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// GET api/math/diff-eq-44?x=1&c1=1&c2=0
        /// Решить дифференциальное уравнение 44
        /// </summary>
        [HttpGet("diff-eq-44")]
        public ActionResult<double> GetDifferentialEquation44(
            [FromQuery] double x, 
            [FromQuery] double c1, 
            [FromQuery] double c2)
        {
            try
            {
                var result = _mathService.SolveDifferentialEquation44(x, c1, c2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// POST api/math/diff-eq-44
        /// Решить дифференциальное уравнение 44
        /// </summary>
        [HttpPost("diff-eq-44")]
        public ActionResult<double> PostDifferentialEquation44([FromBody] DiffEqRequest request)
        {
            try
            {
                var result = _mathService.SolveDifferentialEquation44(request.X, request.C1, request.C2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// POST api/math/verify-diff-eq-43
        /// Проверить корректность решения уравнения 43
        /// </summary>
        [HttpPost("verify-diff-eq-43")]
        public ActionResult<bool> VerifyDifferentialEquation43([FromBody] DiffEqRequest request)
        {
            try
            {
                var result = _mathService.VerifyDifferentialEquation43(request.X, request.C1, request.C2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// POST api/math/verify-diff-eq-44
        /// Проверить корректность решения уравнения 44
        /// </summary>
        [HttpPost("verify-diff-eq-44")]
        public ActionResult<bool> VerifyDifferentialEquation44([FromBody] DiffEqRequest request)
        {
            try
            {
                var result = _mathService.VerifyDifferentialEquation44(request.X, request.C1, request.C2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// GET api/math/integral-derivative?x=1
        /// Вычислить производную интеграла
        /// </summary>
        [HttpGet("integral-derivative")]
        public ActionResult<double> GetIntegralDerivative([FromQuery] double x)
        {
            try
            {
                var result = _mathService.CalculateIntegralDerivative(x);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// GET api/math/integral-numerical?upperLimit=2&lowerLimit=0
        /// Вычислить интеграл численным методом
        /// </summary>
        [HttpGet("integral-numerical")]
        public ActionResult<double> GetIntegralNumerical(
            [FromQuery] double upperLimit, 
            [FromQuery] double lowerLimit = 0,
            [FromQuery] int steps = 10000)
        {
            try
            {
                var result = _mathService.CalculateIntegralNumerical(upperLimit, lowerLimit, steps);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    // Модели запросов
    public class IntegralRequest
    {
        public double X { get; set; }
        public double LowerLimit { get; set; } = 0;
    }

    public class DiffEqRequest
    {
        public double X { get; set; }
        public double C1 { get; set; }
        public double C2 { get; set; }
    }
}
