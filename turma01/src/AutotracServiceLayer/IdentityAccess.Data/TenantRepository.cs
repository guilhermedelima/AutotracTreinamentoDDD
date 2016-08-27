using System;
using System.Collections.Generic;
using IdentityAccess.Application.Tenants.Commands;
using IdentityAccess.Domain.Tenants;

namespace IdentityAccess.Data
{
    public class TenantRepository : ITenantRepository
    {
        public void Activate(ActiveAccountCommand command)
        {
            Console.WriteLine("Usuario Ativado");
        }

        public void Create(Tenant tenant)
        {
            Console.WriteLine("Tenant Criado");
        }

        public void Delete(Tenant tenant)
        {
            Console.WriteLine("Tenant Excluido");
        }

        public void Update(Tenant tenant)
        {
            Console.WriteLine("Tenant Atualizado");
        }
    }

    public class TentantQueryRepoisotry : ITentantQueryRepoisotry
    {
        public List<Tenant> All()
        {
            return null;
        }

        public Tenant FindById(Guid id)
        {
            return null;
        }

        public List<Tenant> FindByName(string name)
        {
            return null;
        }

        public Guid NextId()
        {
            return Guid.NewGuid();
        }
    }
}