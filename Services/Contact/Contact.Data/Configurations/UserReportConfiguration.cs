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
    public class UserReportConfiguration : IEntityTypeConfiguration<UserReport>
    {
        public void Configure(EntityTypeBuilder<UserReport> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.RequestedDate).HasColumnName("requested_date").IsRequired();
            builder.Property(x => x.ReportStatus).HasColumnName("report_status").IsRequired();
            builder.Property(x => x.ExcelPath).HasColumnName("excel_path").IsRequired();
            builder.ToTable("user_reports");

            builder.HasOne(x => x.User).WithMany(x => x.Reports).HasForeignKey(x => x.UserId);
        }
    }
}
