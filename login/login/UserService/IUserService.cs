namespace login.UserService
{
    public interface IUserService
    {
        bool IsValidUser(string username, string password);
    }
}
