using System;
using IdentityAcces.Domain.Tenants.Events;
using SharedKernel.Events;

namespace ApiService.Publishers
{
    public class TenantSaga : 
    IEventHandler<TenantRegistered>,
    IEventHandler<TenantActivated>
    {
        public void Handle(TenantActivated @event)
        {
            Console.WriteLine("enviou o email de ativação da conta");
        }

        public void Handle(TenantRegistered @event)
        {
            Console.WriteLine("enviou o email de registro da conta");
        }
    }
}