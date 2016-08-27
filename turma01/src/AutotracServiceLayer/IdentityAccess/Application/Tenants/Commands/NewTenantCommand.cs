namespace IdentityAccess.Application.Tenants.Commands
{
    public class NewTenantCommand
    {
        public string Name { get; set; }
        public string Username { get; set; }  
        public string Password { get; set; } 
        public string Cnpj { get; set; } 
    }
}