using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentPortalApp.Migrations
{
    public partial class ModifyDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobStages_Jobs_JobId",
                table: "JobStages");

            migrationBuilder.DropForeignKey(
                name: "FK_JobStages_Stages_StageId",
                table: "JobStages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobStages",
                table: "JobStages");

            migrationBuilder.DropIndex(
                name: "IX_JobStages_JobId",
                table: "JobStages");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "JobStages");

            migrationBuilder.AlterColumn<int>(
                name: "StageId",
                table: "JobStages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "JobStages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobStages",
                table: "JobStages",
                columns: new[] { "JobId", "StageId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "39649594-4ede-49c1-b56d-7a5c4070861a", "AQAAAAEAACcQAAAAEKV4Su7B1xz5CBAma4Gl1bXWVo0e52R8HEgjLhN4uXYLsP32N32wVOsY5Ua/b1n8+w==" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobStages_Jobs_JobId",
                table: "JobStages",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobStages_Stages_StageId",
                table: "JobStages",
                column: "StageId",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobStages_Jobs_JobId",
                table: "JobStages");

            migrationBuilder.DropForeignKey(
                name: "FK_JobStages_Stages_StageId",
                table: "JobStages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobStages",
                table: "JobStages");

            migrationBuilder.AlterColumn<int>(
                name: "StageId",
                table: "JobStages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "JobStages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "JobStages",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobStages",
                table: "JobStages",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7f5ab9d3-f782-4bf1-a1ec-f1064006053a", "AQAAAAEAACcQAAAAENyBA6qUXsc3o/riV6Vd/aiijhOsx3cmZJ/IgFijvUNfTk3Bkp4jIFK4eGQumfCFqA==" });

            migrationBuilder.CreateIndex(
                name: "IX_JobStages_JobId",
                table: "JobStages",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobStages_Jobs_JobId",
                table: "JobStages",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobStages_Stages_StageId",
                table: "JobStages",
                column: "StageId",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
