using login.Model;

namespace login.UserService
{
    public interface IUserService
    {
        bool IsValidUser(string username, string password);
        Task<bool> RegisterNewUser(User user);
    }
}
