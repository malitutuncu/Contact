using Contact.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Contracts.Report;

namespace Contact.Data.Configurations
{
    public class ReportOutboxMessageConfiguration : IEntityTypeConfiguration<ReportOutboxMessage>
    {
        public void Configure(EntityTypeBuilder<ReportOutboxMessage> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.OccuredOn).HasColumnName("occured_on").IsRequired();
            builder.Property(x => x.Type).HasColumnName("type").IsRequired();
            builder.Property(x => x.Payload).HasColumnName("payload").IsRequired();
            builder.ToTable("report_outbox_table");
        }
    }


}
