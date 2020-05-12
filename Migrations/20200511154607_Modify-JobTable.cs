using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentPortalApp.Migrations
{
    public partial class ModifyJobTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7f5ab9d3-f782-4bf1-a1ec-f1064006053a", "AQAAAAEAACcQAAAAENyBA6qUXsc3o/riV6Vd/aiijhOsx3cmZJ/IgFijvUNfTk3Bkp4jIFK4eGQumfCFqA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "10a12f53-af30-42f2-b7bb-686c971458be", "AQAAAAEAACcQAAAAEOWlSmumgOn0wsb0VZQOQSKU9/EDrP37V0Cmvn9svlnHYiZKzs3wqq32v+AIIa8rJA==" });
        }
    }
}
