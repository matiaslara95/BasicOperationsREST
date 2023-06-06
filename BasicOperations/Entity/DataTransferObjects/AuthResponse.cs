namespace BasicOperations.Entity.DataTransferObjects
{
    public class AuthResponse
    {
        public bool IsAuthSuccessful { get; set; }
        public bool IsTfaEnabled { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
    }
}
