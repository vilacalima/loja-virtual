﻿using login.Model;

namespace login.UserRepository
{
    public interface IUserRepository
    {
        void Save(User user);
    }
}
