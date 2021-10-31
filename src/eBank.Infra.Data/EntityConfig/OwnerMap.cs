using eBank.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace eBank.Infra.Data.EntityConfig
{
    public class OwnerMap : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owner");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.OwnerName).IsRequired();
            builder.Property(p => p.OwnerDocument).IsRequired();
            builder.Property(p => p.Active).IsRequired();

            builder.HasData(
                new Owner
                {
                    Id = 1,
                    OwnerName = "Heitor Macêdo",
                    OwnerDocument = "10203040570",
                    Active = true,
                    RegistrationDate = DateTime.Now
                },
                new Owner
                {
                    Id = 2,
                    OwnerName = "João Santos",
                    OwnerDocument = "25337111019",
                    Active = true,
                    RegistrationDate = DateTime.Now
                },
                new Owner
                {
                    Id = 3,
                    OwnerName = "Maria Tavares",
                    OwnerDocument = "76788265089",
                    Active = true,
                    RegistrationDate = DateTime.Now
                }
            );
        }
    }
}
