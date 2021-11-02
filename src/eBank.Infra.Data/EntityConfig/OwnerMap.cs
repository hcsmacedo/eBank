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
                    OwnerDocument = "369.135.230-84",
                    Active = true,
                    RegistrationDate = DateTime.Now
                },
                new Owner
                {
                    Id = 2,
                    OwnerName = "ING8 Tecnologia da Informação",
                    OwnerDocument = "74.712.796/0001-41",
                    Active = true,
                    RegistrationDate = DateTime.Now
                }
            );
        }
    }
}
