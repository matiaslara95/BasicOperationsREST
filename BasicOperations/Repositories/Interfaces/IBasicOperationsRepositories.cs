using BasicOperations.Domain.Entity;

namespace BasicOperations.Repositories.Interfaces
{
    public interface IBasicOperationsRepositories
    {
        public bool AddOperationHistory(OperationHistory operationHistory);
        public bool DeleteHistory();
        public List<OperationHistory> GetOperationHistory();
    }
}
