using System.Net;

namespace Service_Auth.Contracts.Base
{
    public record ErrorResponse(string Message, int? HttpStatusCode = null);
}
