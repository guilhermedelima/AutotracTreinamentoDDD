using System;
using IdentityAccess.Application.Tenants;
using IdentityAccess.Application.Tenants.Commands;
using IdentityAccess.Data;

namespace ConsoleApplication
{
    public class Program
    {
        private static ITentantQueryRepoisotry _tentantQueryRepoisotry = new TentantQueryRepoisotry();
        private static TenantServices _service = new TenantServices(
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
                Console.WriteLine(_service.StringfyNotifications());
            else
                ApiService.Publishers.EventPublisher.Publish(events);

            Console.Read();
        }
    }
}
