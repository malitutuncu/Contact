// <auto-generated />
using System;
using Contact.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Contact.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220831194106_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Contact.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("company_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("surname");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Contact.Data.Entities.UserInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("InformationContent")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("information_content");

                    b.Property<int>("InformationType")
                        .HasMaxLength(50)
                        .HasColumnType("integer")
                        .HasColumnName("information_type");

                    b.Property<Guid>("UserId")
                        .HasMaxLength(50)
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_informations", (string)null);
                });

            modelBuilder.Entity("Contact.Data.Entities.UserReport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ExcelPath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("excel_path");

                    b.Property<int>("ReportStatus")
                        .HasColumnType("integer")
                        .HasColumnName("report_status");

                    b.Property<DateTime>("RequestedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("requested_date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_reports", (string)null);
                });

            modelBuilder.Entity("Contact.Data.Entities.UserInformation", b =>
                {
                    b.HasOne("Contact.Data.Entities.User", "User")
                        .WithMany("Informations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Contact.Data.Entities.UserReport", b =>
                {
                    b.HasOne("Contact.Data.Entities.User", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Contact.Data.Entities.User", b =>
                {
                    b.Navigation("Informations");

                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
