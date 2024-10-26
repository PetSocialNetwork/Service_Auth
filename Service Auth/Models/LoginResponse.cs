namespace Service_Auth.Models
{
    public record LoginResponse(Guid Id, string Email, string Token);
}
