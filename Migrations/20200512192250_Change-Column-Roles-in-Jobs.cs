using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentPortalApp.Migrations
{
    public partial class ChangeColumnRolesinJobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roles",
                table: "Jobs");

            migrationBuilder.AddColumn<string>(
                name: "JobRoles",
                table: "Jobs",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "28b0b7e8-e9d2-49b1-b056-275eb932abc5", "AQAAAAEAACcQAAAAEOy56r3heZSxKtBYAvIF+O6N8znQ8UFSZgaIdWnzM0FUXBxo0Gzmh76RdCge2u/2uQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobRoles",
                table: "Jobs");

            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "39649594-4ede-49c1-b56d-7a5c4070861a", "AQAAAAEAACcQAAAAEKV4Su7B1xz5CBAma4Gl1bXWVo0e52R8HEgjLhN4uXYLsP32N32wVOsY5Ua/b1n8+w==" });
        }
    }
}
