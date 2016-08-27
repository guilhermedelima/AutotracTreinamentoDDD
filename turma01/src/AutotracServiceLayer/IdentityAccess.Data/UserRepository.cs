using System;
using IdentityAccess.Domain.Users;
using IdentityAccess.Domain.Users.Repositories;

namespace IdentityAccess.Data
{
    public class UserRepository : IUserRepository
    {
        void IUserRepository.Create(User user)
        {
            Console.WriteLine("Usuario adicionado");
        }
    }
}