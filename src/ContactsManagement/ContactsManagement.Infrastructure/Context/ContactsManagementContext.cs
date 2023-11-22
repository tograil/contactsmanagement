using Microsoft.EntityFrameworkCore;

namespace ContactsManagement.Infrastructure.Context;

public class ContactsManagementContext : DbContext
{
    public ContactsManagementContext(DbContextOptions<ContactsManagementContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContactsManagementContext).Assembly);
    }
}