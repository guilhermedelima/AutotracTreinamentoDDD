using System;

namespace IdentityAccess.Application.Tenants.Commands
{
    public class ActiveAccountCommand
    {
        public Guid TenantId { get; set;}
    }
}