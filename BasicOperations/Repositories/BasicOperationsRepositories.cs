using BasicOperations.Domain.Entity;
using BasicOperations.Repositories.Interfaces;
using System.Runtime.CompilerServices;

namespace BasicOperations.Repositories
{
    public class BasicOperationsRepositories : IBasicOperationsRepositories
    {
        private readonly MatiasContext _context;
        public BasicOperationsRepositories(MatiasContext context) {
            _context = context;
        }
        public bool AddOperationHistory(OperationHistory operationHistory)
        {
            try
            {
                _context.OperationHistories.Add(operationHistory);
                _context.SaveChanges();
                return true;
            } 
            catch (Exception ex){ 
                return false;
            }
        }

        public bool DeleteHistory()
        {
            throw new NotImplementedException();
        }

        public List<OperationHistory> GetOperationHistory()
        {
            throw new NotImplementedException();
        }
    }
}
