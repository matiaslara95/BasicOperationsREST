using BasicOperations.Controllers;
using BasicOperations.Entity.Models;
using BasicOperations.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BasicOperations.Repositories
{
    public class BasicOperationsRepositories : IBasicOperationsRepositories
    {
        private readonly BasicOperationsContext _context;
        private readonly ILogger<BasicOperationsRepositories> _logger;

        public BasicOperationsRepositories(BasicOperationsContext context, ILogger<BasicOperationsRepositories> logger) {
            _context = context;
            _logger = logger;
        }
        public bool AddOperationHistory(OperationHistory operationHistory)
        {
            try
            {
                //_context.OperationHistories.Add(operationHistory);
                //_context.SaveChanges();
                return true;
            } 
            catch (Exception ex){
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public bool DeleteHistory()
        {
            try
            {
                //_context.OperationHistories.ExecuteDelete();
                //_context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public List<OperationHistory> GetOperationHistory()
        {
            try
            {
                //return _context.OperationHistories.ToList();
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
