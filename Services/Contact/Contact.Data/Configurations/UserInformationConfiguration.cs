using Contact.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Configurations
{
    public class UserInformationConfiguration : IEntityTypeConfiguration<UserInformation>
    {
        public void Configure(EntityTypeBuilder<UserInformation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.InformationType).HasColumnName("information_type").IsRequired().HasMaxLength(50);
            builder.Property(x => x.UserId).HasColumnName("user_id").IsRequired().HasMaxLength(50);
            builder.Property(x => x.InformationContent).HasColumnName("information_content").IsRequired().HasMaxLength(50);
            builder.ToTable("user_informations");

            builder.HasOne(x => x.User).WithMany(x => x.Informations).HasForeignKey(x => x.UserId);
        }
    }
}
