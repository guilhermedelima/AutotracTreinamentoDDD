using System;
using System.Collections.Generic;
using IdentityAccess.Application.Tenants.Commands;
using IdentityAccess.Domain.Tenants;

public interface ITentantQueryRepoisotry
{
    Guid NextId();
    Tenant FindById(Guid id);
    List<Tenant> FindByName(string name);
    List<Tenant> All();
}


public interface ITenantRepository
{
 
    void Activate(ActiveAccountCommand command);
    
    void Create(Tenant tenant);
    void Update(Tenant tenant);
    void Delete(Tenant tenant);
}