using System;
using System.Collections.Generic;
using IdentityAccess.Application.Tenants;
using IdentityAccess.Application.Tenants.Commands;
using IdentityAccess.Domain.Tenants;
using IdentityAccess.Data;

namespace ConsoleApplication
{
    public class Program
    {
        private static ITentantQueryRepoisotry _tentantQueryRepoisotry =
        new TentantQueryRepoisotry();
        private static TenantServices _service =
        new TenantServices(
                new TenantRepository(),
                new UserRepository(),
                new ServiceExternal()
        );

        public static void Main(string[] args)
        {
            var newTenant = new NewTenantCommand
            {
                Name = "Yan Justino",
                Username = "yanjustino",
                Password = "master",
                Cnpj = "12345678901234"
            };

            var id = _tentantQueryRepoisotry.NextId();
            var events = _service.Register(id, newTenant);

            if (!_service.IsValid())
            {
                Console.WriteLine(_service.StringfyNotifications());
            }

            ApiService.Publishers.EventPublisher.Publish(events);

            events = _service.Activate(new ActiveAccountCommand{TenantId = Guid.NewGuid() });
            ApiService.Publishers.EventPublisher.Publish(events);

            Console.Read();
        }
    }

    public class ServiceExternal : IExternalService
    {
        public void Execute()
        {
            Console.Write("Serviço Externo");
        }

        public object Find()
        {
            return null;
        }
    }

}
