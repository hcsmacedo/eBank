using eBank.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace eBank.Infra.Data.EntityConfig
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.BankId);
            builder.Property(p => p.BranchNumber).IsRequired();
            builder.Property(p => p.AccountNumber).IsRequired();
            builder.Property(p => p.Active).IsRequired();

            builder.HasOne(typeof(Bank)).WithMany().HasForeignKey("BankId").OnDelete(DeleteBehavior.Cascade).IsRequired();
            builder.HasOne(typeof(Owner)).WithMany().HasForeignKey("OwnerId").OnDelete(DeleteBehavior.Cascade).IsRequired();

            builder.HasData(
                new Account
                {
                    Id = 1,
                    BankId = 1,
                    BranchNumber = "3361-8",
                    AccountNumber = "11.507-x",
                    OwnerId = 1,
                    Active = true,
                    RegistrationDate = DateTime.Now
                },
                new Account
                {
                    Id = 2,
                    BankId = 3,
                    BranchNumber = "0KY01",
                    AccountNumber = "9799975-0",
                    OwnerId = 2,
                    Active = false,
                    RegistrationDate = DateTime.Now
                }
            );
        }
    }
}
