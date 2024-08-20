using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Repository.Data.Config
{
    public class ApplicationOrMuamalahConfiguration : IEntityTypeConfiguration<ApplicationOrMuamalah>
    {
        public void Configure(EntityTypeBuilder<ApplicationOrMuamalah> builder)
        {
            builder.HasKey(a => a.ApplicationId);
            builder.Property(a => a.Type).IsRequired();
            builder.Property(a => a.Cost).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasOne<Customer>().WithMany().HasForeignKey(a => a.CustomerId);
        }
    }
}
