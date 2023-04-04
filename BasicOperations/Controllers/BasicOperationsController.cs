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
            OperationHistory operationHistory = new OperationHistory();

            try
            {
                decimal result = numberOne + numberTwo;
                operationHistory.Operation = $"{numberOne} + {numberTwo}";
                operationHistory.Result = result.ToString();
                operationHistory.Date = DateTime.Now;
                _basicOperationsRepositories.AddOperationHistory(operationHistory);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
            finally
            {
                operationHistory = null;
            }
        }

        [HttpPost(Name = "Subtraction")]
        public decimal Subtraction(decimal numberOne, decimal numberTwo)
        {
            OperationHistory operationHistory = new OperationHistory();

            try
            {
                decimal result = numberOne - numberTwo;
                operationHistory.Operation = $"{numberOne} - {numberTwo}";
                operationHistory.Result = result.ToString();
                operationHistory.Date = DateTime.Now;
                _basicOperationsRepositories.AddOperationHistory(operationHistory);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
            finally
            {
                operationHistory = null;
            }
        }

        [HttpPost(Name = "Multiplication")]
        public decimal Multiplication(decimal numberOne, decimal numberTwo)
        {
            OperationHistory operationHistory = new OperationHistory();
            try
            {
                decimal result = numberOne * numberTwo;
                operationHistory.Operation = $"{numberOne} * {numberTwo}";
                operationHistory.Result = result.ToString();
                operationHistory.Date = DateTime.Now;
                _basicOperationsRepositories.AddOperationHistory(operationHistory);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
        }

        [HttpPost(Name = "Division")]
        public decimal Division(decimal numberOne, decimal numberTwo)
        {
            OperationHistory operationHistory = new OperationHistory();
            try
            {
                decimal result = numberOne / numberTwo;
                operationHistory.Operation = $"{numberOne} / {numberTwo}";
                operationHistory.Result = result.ToString();
                operationHistory.Date = DateTime.Now;
                _basicOperationsRepositories.AddOperationHistory(operationHistory);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
        }

        [HttpGet]
        public List<OperationHistory> GetHistory()
        {
            return _basicOperationsRepositories.GetOperationHistory();
        }

        [HttpDelete]
        public bool DeleteHistory()
        {
            return _basicOperationsRepositories.DeleteHistory();
        }
    }
}
