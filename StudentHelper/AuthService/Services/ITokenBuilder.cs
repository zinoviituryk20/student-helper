namespace AuthService.Services
{
    public interface ITokenBuilder
    {
        string GenerateToken(string userName, string role);
    }
}
