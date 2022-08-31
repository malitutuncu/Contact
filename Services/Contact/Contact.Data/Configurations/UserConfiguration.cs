using Contact.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Surname).HasColumnName("surname").IsRequired().HasMaxLength(50);
            builder.Property(x => x.CompanyName).HasColumnName("company_name").IsRequired().HasMaxLength(50);
            builder.ToTable("users");
        }
    }
}
