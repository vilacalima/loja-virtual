using login.Model;
using Microsoft.EntityFrameworkCore;
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

        public bool GetUser(string email, string password)
        {
            var debug = _context.User
                .FirstOrDefault(u => u.Email == email && u.Password == password);

            if (debug != null) return true;

            return false;
        }

        public void Save(User user)
        {
            var debug = _context.User.Add(user);
            debug.Context.SaveChanges();
        }
    }
}
