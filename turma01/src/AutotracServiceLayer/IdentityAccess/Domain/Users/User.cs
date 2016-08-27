

using System;

namespace IdentityAccess.Domain.Users
{
    public class User
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public Guid TenantId { get; private set; }

        public User(Guid teantId, string username, string password)
        {
            TenantId = teantId;
            Username = username;
            Password = Services.PasswordServices.CryptographyPassword(password);
        }
    }
}