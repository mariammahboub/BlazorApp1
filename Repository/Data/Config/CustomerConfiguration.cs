using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Core.Models;

namespace Repository.Data.Config
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerId);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Address).IsRequired().HasMaxLength(200);

            var telephoneNumbersComparer = new ValueComparer<List<string>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList()
            );

            builder.Property(c => c.TelephoneNumbers)
                   .HasConversion(
                       v => string.Join(',', v),
                       v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                   )
                   .Metadata.SetValueComparer(telephoneNumbersComparer);
        }
    }
}
