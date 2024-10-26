using Service_Auth.Contracts.Base;

namespace Service_Auth.Exceptions
{
    public class InvalidPasswordException : DomainException
    {
        public InvalidPasswordException()
        {
        }

        public InvalidPasswordException(string? message) : base(message)
        {
        }

        public InvalidPasswordException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
