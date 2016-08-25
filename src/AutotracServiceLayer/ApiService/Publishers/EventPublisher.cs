using System.Collections.Generic;
using IdentityAcces.Domain.Tenants.Events;
using SharedKernel.Events;

namespace ApiService.Publishers
{
    public static class EventPublisher
    {
        private static TenantSaga _tenantSaga = new TenantSaga();
        private static TenantSagaFinanceiro _tenantSagaFinanceiro = new TenantSagaFinanceiro();

        public static void Publish(List<IEvent> events)
        {
            foreach (var @event in events)
            {
                if (@event is TenantRegistered)
                    _tenantSaga.Handle((TenantRegistered)@event);
                if (@event is TenantActivated)
                {
                    _tenantSaga.Handle((TenantActivated)@event);
                    _tenantSagaFinanceiro.Handle((TenantActivated)@event);
                }
            }

            //TODO Seleção da Saga correspondente ao Event

        }
    }
}