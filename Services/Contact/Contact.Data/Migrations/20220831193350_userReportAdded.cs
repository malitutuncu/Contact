using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contact.Data.Migrations
{
    public partial class userReportAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_reports",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    requested_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    report_status = table.Column<int>(type: "integer", nullable: false),
                    excel_path = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_reports", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_reports_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_reports_UserId",
                table: "user_reports",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_reports");
        }
    }
}
