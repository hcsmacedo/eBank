using eBank.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        }
    }
}
