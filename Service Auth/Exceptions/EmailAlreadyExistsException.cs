﻿using Service_Auth.Contracts.Base;

namespace Service_Auth.Exceptions
{
    public class EmailAlreadyExistsException : DomainException
    {
        public EmailAlreadyExistsException()
        {
        }

        public EmailAlreadyExistsException(string? message) : base(message)
        {
        }

        public EmailAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
