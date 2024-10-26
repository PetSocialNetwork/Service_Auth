using Service_Auth.Contracts.Base;

namespace Service_Auth.Exceptions
{
    public class AccountNotFoundException : DomainException
    {
        public AccountNotFoundException()
        {
        }

        public AccountNotFoundException(string? message) : base(message)
        {
        }

        public AccountNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
