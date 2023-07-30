namespace login.UserService
{
    public class UserService : IUserService
    {
        public bool IsValidUser(string username, string password)
        {
            return username == "usuario" && password == "senha";
        }
    }
}
