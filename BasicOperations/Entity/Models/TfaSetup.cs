namespace BasicOperations.Entity.Models
{
    public class TfaSetup
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public bool IsTfaEnabled { get; set; }
        public string? AuthenticatorKey { get; set; }
        public string? FormattedKey { get; set; }
    }
}
