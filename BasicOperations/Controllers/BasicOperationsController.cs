using BasicOperations.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Runtime.CompilerServices;
using BasicOperations.Entity.Models;
using Microsoft.AspNetCore.Authorization;

namespace BasicOperations.Controllers
{
    [Route("api/operations")]
    [ApiController]
    public class BasicOperationsController : Controller
    {
        private readonly ILogger<BasicOperationsController> _logger;
        //private readonly IBasicOperationsRepositories _basicOperationsRepositories;

        public BasicOperationsController(ILogger<BasicOperationsController> logger)
        {
            _logger = logger;
            //_basicOperationsRepositories = basicOperationsRepositories;
        }

        [HttpPost("addition")]
        [Authorize]
        public decimal Addition(Operations numbers)
        {
            OperationHistory operationHistory = new OperationHistory();

            try
            {
                decimal result = numbers.NumberOne + numbers.NumberTwo;
                operationHistory.Operation = $"{numbers.NumberOne} + {numbers.NumberTwo}";
                operationHistory.Result = result.ToString();
                operationHistory.Date = DateTime.Now;
                //_basicOperationsRepositories.AddOperationHistory(operationHistory);

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

        [HttpPost("Subtraction")]
        public decimal Subtraction(decimal numberOne, decimal numberTwo)
        {
            OperationHistory operationHistory = new OperationHistory();

            try
            {
                decimal result = numberOne - numberTwo;
                operationHistory.Operation = $"{numberOne} - {numberTwo}";
                operationHistory.Result = result.ToString();
                operationHistory.Date = DateTime.Now;
                //_basicOperationsRepositories.AddOperationHistory(operationHistory);

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

        [HttpPost("Multiplication")]
        public decimal Multiplication(decimal numberOne, decimal numberTwo)
        {
            OperationHistory operationHistory = new OperationHistory();
            try
            {
                decimal result = numberOne * numberTwo;
                operationHistory.Operation = $"{numberOne} * {numberTwo}";
                operationHistory.Result = result.ToString();
                operationHistory.Date = DateTime.Now;
                //_basicOperationsRepositories.AddOperationHistory(operationHistory);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
        }

        [HttpPost("Division")]
        public decimal Division(decimal numberOne, decimal numberTwo)
        {
            OperationHistory operationHistory = new OperationHistory();
            try
            {
                decimal result = numberOne / numberTwo;
                operationHistory.Operation = $"{numberOne} / {numberTwo}";
                operationHistory.Result = result.ToString();
                operationHistory.Date = DateTime.Now;
                //_basicOperationsRepositories.AddOperationHistory(operationHistory);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
        }

        //[HttpGet]
        //public List<OperationHistory> GetHistory()
        //{
        //    //return _basicOperationsRepositories.GetOperationHistory();
        //}

        //[HttpDelete]
        //public bool DeleteHistory()
        //{
        //    //return _basicOperationsRepositories.DeleteHistory();
        //}
    }
}
