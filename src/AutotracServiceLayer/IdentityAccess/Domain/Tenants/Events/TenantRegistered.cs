using System;
using IdentityAccess.Domain.Tenants;
using SharedKernel.Events;

namespace IdentityAcces.Domain.Tenants.Events
{
    public class TenantRegistered : IEvent
    {
        public Tenant Registered { get; private set; }
        public DateTime OcurredOn { get; private set; }

        public TenantRegistered(Tenant registered)
        {
            Registered = registered;
            OcurredOn = DateTime.Now;
        }
    }
}