using System;
using System.Collections.Generic;
using IdentityAccess.Application.Tenants;
using IdentityAccess.Application.Tenants.Commands;
using IdentityAccess.Domain.Tenants;
using IdentityAccess.Data;

namespace ConsoleApplication
{
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
