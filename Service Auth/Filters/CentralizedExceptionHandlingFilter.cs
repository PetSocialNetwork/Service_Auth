using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Service_Auth.Exceptions;
using Service_Auth.Contracts.Base;

namespace Service_Auth.Filters
{
    public class CentralizedExceptionHandlingFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var (message, statusCode) = TryGetUserMessageFromException(context);

            if (message != null && statusCode != 0)
            {
                context.Result = new ObjectResult(new ErrorResponse(message, statusCode))
                {
                    StatusCode = statusCode
                };
                context.ExceptionHandled = true;
            }
        }

        private (string?, int) TryGetUserMessageFromException(ExceptionContext context)
        {
            return context.Exception switch
            {
                EmailAlreadyExistsException => ("Аккаунт с таким email уже зарегистрирован", StatusCodes.Status409Conflict),
                AccountNotFoundException => ("Аккаунт с таким e-mail не найден", StatusCodes.Status400BadRequest),
                InvalidPasswordException => ("Неверный пароль", StatusCodes.Status400BadRequest),
                InvalidOperationException => ("Некорректный адрес e-mail адреса", StatusCodes.Status400BadRequest),
                Exception => ("Неизвестная ошибка!", StatusCodes.Status500InternalServerError),
                _ => (null, 0)
            };
        }
    }
}
