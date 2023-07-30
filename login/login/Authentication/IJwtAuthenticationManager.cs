namespace login.Authentication
{
    public interface IJwtAuthenticationManager
    {
        string GenerateToken(string username);
    }
}
