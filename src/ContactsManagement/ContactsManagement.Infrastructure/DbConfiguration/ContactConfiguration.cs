using ContactsManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactsManagement.Infrastructure.DbConfiguration;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.FirstName)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(c => c.LastName)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(c => c.Email)
            .HasMaxLength(50)
            .IsRequired();
    }
}