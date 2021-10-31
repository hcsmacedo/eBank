using eBank.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace eBank.Infra.Data.EntityConfig
{
    public class BankMap : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.ToTable("Bank");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.BankCode).IsRequired();
            builder.Property(p => p.BankCode).HasMaxLength(3).IsFixedLength();
            builder.Property(p => p.Active).IsRequired();

            builder.HasData(
                new Bank
                {
                    Id = 1,
                    BankCode = "001",
                    Name = "Banco do Brasil",                    
                    Active = true,
                    RegistrationDate = DateTime.Now
                },
                new Bank
                {
                    Id = 2,
                    BankCode = "237",
                    Name = "Bradesco",
                    Active = true,
                    RegistrationDate = DateTime.Now
                },
                new Bank
                {
                    Id = 3,
                    BankCode = "077",
                    Name = "Inter",
                    Active = true,
                    RegistrationDate = DateTime.Now
                }
                );
        }
    }
}
