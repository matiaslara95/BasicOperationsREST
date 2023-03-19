using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Runtime.CompilerServices;

namespace BasicOperations.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class BasicOperationsController : Controller
    {
        private readonly ILogger<BasicOperationsController> _logger;

        public BasicOperationsController(ILogger<BasicOperationsController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Addition")]
        
        public decimal Addition(decimal numberOne, decimal numberTwo)
        {
            try
            {
                return numberOne + numberTwo;
            }
            catch (ArithmeticException ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
        }

        [HttpPost(Name = "Subtraction")]
        public decimal Subtraction(decimal numberOne, decimal numberTwo)
        {
            try
            {
                return numberOne - numberTwo;
            }
            catch (ArithmeticException ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
        }

        [HttpPost(Name = "Multiplication")]
        public decimal Multiplication(decimal numberOne, decimal numberTwo)
        {
            try
            {
                return numberOne * numberTwo;
            }
            catch (ArithmeticException ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
        }

        [HttpPost(Name = "Division")]
        public decimal Division(decimal numberOne, decimal numberTwo)
        {
            try
            {
                return numberOne / numberTwo;
            }
            catch (ArithmeticException ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
        }
    }
}
