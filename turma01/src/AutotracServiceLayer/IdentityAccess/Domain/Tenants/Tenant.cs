using System;
using System.Collections.Generic;
using IdentityAccess.Application.Tenants.Commands;
using IdentityAccess.Domain.Users;
using PassOn;

namespace IdentityAccess.Domain.Tenants
{
    public class Tenant : ValidatableEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime ActivateDate { get; private set; }
        public DateTime? DeactivateDate { get; private set; }

        public void Activete()
        {
            this.Active = true;
            this.ActivateDate = DateTime.Now;
        }

        public void Deactivete()
        {
            if (Active)
            {
                this.Active = false;
                this.DeactivateDate = DateTime.Now;
            }
        }

        public User RegisterUser(string username, string password)
        {
            return new User(Id, username, password);
        }

        protected override IEnumerable<Notification> Validations()
        {
            yield return Assert.NotEmpty(Cnpj, "Cnpj não pode ser vazio");
            yield return Assert.NotNull(Cnpj, "Cnpj não pode ser nulo");
            yield return Assert.Length(Cnpj, 14, 14, "Cnpj inválido");
            yield return Assert.NotEmpty(Name, "Nome não pode ser vazio");
            yield return Assert.NotNull(Name, "Nome não informado");
        }

        /// Fábrica do Tenant
        public class Factory
        {
            public static Tenant Build(Guid id, NewTenantCommand command)
            {
                return new Tenant
                {
                    Id = id,
                    Name = command.Name,
                    Cnpj = command.Cnpj
                };
            }
        }
    }
}