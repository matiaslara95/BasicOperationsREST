using BasicOperations.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Runtime.CompilerServices;
using BasicOperations.Domain.Entity;

namespace BasicOperations.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class BasicOperationsController : Controller
    {
        private readonly ILogger<BasicOperationsController> _logger;
        private readonly IBasicOperationsRepositories _basicOperationsRepositories;

        public BasicOperationsController(ILogger<BasicOperationsController> logger, IBasicOperationsRepositories basicOperationsRepositories)
        {
            _logger = logger;
            _basicOperationsRepositories = basicOperationsRepositories;
        }

        [HttpPost(Name = "Addition")]        
        public decimal Addition(decimal numberOne, decimal numberTwo)
        {
            try
            {
                decimal result = numberOne + numberTwo;
                _basicOperationsRepositories.AddOperationHistory(new OperationHistory { Operation = $"{numberOne} + {numberTwo}", Result = result.ToString(), Date = DateTime.Now, Observations = "" });
                return result;
            }
            catch (ArithmeticException ex)
            {
                _logger.LogError(ex.Message);
                _basicOperationsRepositories.AddOperationHistory(new OperationHistory { Operation = $"{numberOne} + {numberTwo}", Result = "0", Date = DateTime.Now, Observations = ex.Message });
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

        [HttpGet]
        public void ObtenerHistorial()
        {

        }
    }
}
