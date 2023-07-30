using login.Model;
using System;

namespace login.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Save(User user)
        {
            var debug = _context.User.Add(user);
            debug.Context.SaveChanges();
        }
    }
}
