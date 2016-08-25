using System;
using IdentityAcces.Domain.Tenants.Events;
using SharedKernel.Events;

namespace ApiService.Publishers
{
    public class TenantSagaFinanceiro : 
    IEventHandler<TenantActivated>
    {
        public void Handle(TenantActivated @event)
        {
            Console.WriteLine("enviar o email para financeiro");
            Console.WriteLine("Solicitar ao contexto a geração da primeira Fatura");
        }
    }
}