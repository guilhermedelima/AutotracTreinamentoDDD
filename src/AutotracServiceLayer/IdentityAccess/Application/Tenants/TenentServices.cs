using System;
using System.Collections.Generic;
using IdentityAcces.Domain.Tenants.Events;
using IdentityAccess.Application.Tenants.Commands;
using IdentityAccess.Domain.Tenants;
using IdentityAccess.Domain.Users.Repositories;
using PassOn;
using SharedKernel.Events;

namespace IdentityAccess.Application.Tenants
{
    public class TenantServices : ValidatableService
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IExternalService _externalService;
        private readonly IUserRepository _userRepository;

        public TenantServices(
            ITenantRepository tenantRepository,
            IUserRepository userRepository,
            IExternalService externalService
            )
        {
            _tenantRepository = tenantRepository;
            _userRepository = userRepository;
            _externalService = externalService;
        }

        public List<IEvent> Register(Guid id, NewTenantCommand command)
        {
            var tenant = Tenant.Factory.Build(id, command);

            if (!tenant.IsValid())
            {
                this.Notify(tenant.Notifications);
                return null;
            }

            var user = tenant.RegisterUser(command.Username, command.Password);

            //TODO : Criar mecanismo de transação
            _tenantRepository.Create(tenant);
            _userRepository.Create(user);

            return new List<IEvent>
            {
                new TenantRegistered(tenant)
            };
        }

        public List<IEvent> Activate(ActiveAccountCommand command)
        {
            //TODO: Recuperar o Tenent
            var tenant = new Tenant();
            tenant.Activete();

            _tenantRepository.Update(tenant);

            return new List<IEvent>
            {   
                new TenantActivated(tenant)
            };            
            //TODO: Enviar email de ativação da conta
        }

        public void Deactivate(ActiveAccountCommand command)
        {
            //TODO: Recuperar o Tenent
            var tenant = new Tenant();
            tenant.Deactivete();

            _tenantRepository.Update(tenant);
            //TODO: Enviar email informando a desativação da conta
        }
    }
}