using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentPortalApp.Migrations
{
    public partial class ModifyModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantResponses_Applications_ApplicationId",
                table: "ApplicantResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantResponses_Questions_QuestionId",
                table: "ApplicantResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Jobs_JobID",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobStages_Jobs_JobId",
                table: "JobStages");

            migrationBuilder.DropForeignKey(
                name: "FK_JobStages_Stages_StageId",
                table: "JobStages");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Stages_StageId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreBoards_Applications_ApplicationId",
                table: "ScoreBoards");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreBoards_Stages_StageId",
                table: "ScoreBoards");

            migrationBuilder.DropIndex(
                name: "IX_ScoreBoards_ApplicationId",
                table: "ScoreBoards");

            migrationBuilder.DropIndex(
                name: "IX_ScoreBoards_StageId",
                table: "ScoreBoards");

            migrationBuilder.DropIndex(
                name: "IX_Questions_StageId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobStages",
                table: "JobStages");

            migrationBuilder.DropIndex(
                name: "IX_Applications_JobID",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantResponses_ApplicationId",
                table: "ApplicantResponses");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantResponses_QuestionId",
                table: "ApplicantResponses");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "ScoreBoards");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "ScoreBoards");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "JobID",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "ApplicantResponses");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "ApplicantResponses");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Answers");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationsId",
                table: "ScoreBoards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StagesId",
                table: "ScoreBoards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StagesId",
                table: "Questions",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StageId",
                table: "JobStages",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "JobStages",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "JobsId",
                table: "JobStages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StagesId",
                table: "JobStages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobsID",
                table: "Applications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationsId",
                table: "ApplicantResponses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionsId",
                table: "ApplicantResponses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionsId",
                table: "Answers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobStages",
                table: "JobStages",
                columns: new[] { "JobsId", "StagesId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d4f93785-c4cb-428a-9367-d673c8db840a", "AQAAAAEAACcQAAAAEH2LGGQhgwP5JM4jvUwUOm24qmGGRjQOkFDCBKDw+Vzsb/svHa+LX+tVFMiNKbrJsA==" });

            migrationBuilder.CreateIndex(
                name: "IX_ScoreBoards_ApplicationsId",
                table: "ScoreBoards",
                column: "ApplicationsId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreBoards_StagesId",
                table: "ScoreBoards",
                column: "StagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_StagesId",
                table: "Questions",
                column: "StagesId");

            migrationBuilder.CreateIndex(
                name: "IX_JobStages_JobId",
                table: "JobStages",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobsID",
                table: "Applications",
                column: "JobsID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantResponses_ApplicationsId",
                table: "ApplicantResponses",
                column: "ApplicationsId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantResponses_QuestionsId",
                table: "ApplicantResponses",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionsId",
                table: "Answers",
                column: "QuestionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionsId",
                table: "Answers",
                column: "QuestionsId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantResponses_Applications_ApplicationsId",
                table: "ApplicantResponses",
                column: "ApplicationsId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantResponses_Questions_QuestionsId",
                table: "ApplicantResponses",
                column: "QuestionsId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Jobs_JobsID",
                table: "Applications",
                column: "JobsID",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Stages_StagesId",
                table: "Questions",
                column: "StagesId",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreBoards_Applications_ApplicationsId",
                table: "ScoreBoards",
                column: "ApplicationsId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreBoards_Stages_StagesId",
                table: "ScoreBoards",
                column: "StagesId",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionsId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantResponses_Applications_ApplicationsId",
                table: "ApplicantResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantResponses_Questions_QuestionsId",
                table: "ApplicantResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Jobs_JobsID",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobStages_Jobs_JobId",
                table: "JobStages");

            migrationBuilder.DropForeignKey(
                name: "FK_JobStages_Stages_StageId",
                table: "JobStages");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Stages_StagesId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreBoards_Applications_ApplicationsId",
                table: "ScoreBoards");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreBoards_Stages_StagesId",
                table: "ScoreBoards");

            migrationBuilder.DropIndex(
                name: "IX_ScoreBoards_ApplicationsId",
                table: "ScoreBoards");

            migrationBuilder.DropIndex(
                name: "IX_ScoreBoards_StagesId",
                table: "ScoreBoards");

            migrationBuilder.DropIndex(
                name: "IX_Questions_StagesId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobStages",
                table: "JobStages");

            migrationBuilder.DropIndex(
                name: "IX_JobStages_JobId",
                table: "JobStages");

            migrationBuilder.DropIndex(
                name: "IX_Applications_JobsID",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantResponses_ApplicationsId",
                table: "ApplicantResponses");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantResponses_QuestionsId",
                table: "ApplicantResponses");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuestionsId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "ApplicationsId",
                table: "ScoreBoards");

            migrationBuilder.DropColumn(
                name: "StagesId",
                table: "ScoreBoards");

            migrationBuilder.DropColumn(
                name: "StagesId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "JobsId",
                table: "JobStages");

            migrationBuilder.DropColumn(
                name: "StagesId",
                table: "JobStages");

            migrationBuilder.DropColumn(
                name: "JobsID",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ApplicationsId",
                table: "ApplicantResponses");

            migrationBuilder.DropColumn(
                name: "QuestionsId",
                table: "ApplicantResponses");

            migrationBuilder.DropColumn(
                name: "QuestionsId",
                table: "Answers");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "ScoreBoards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StageId",
                table: "ScoreBoards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StageId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StageId",
                table: "JobStages",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "JobStages",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobID",
                table: "Applications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "ApplicantResponses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "ApplicantResponses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Answers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobStages",
                table: "JobStages",
                columns: new[] { "JobId", "StageId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "28b0b7e8-e9d2-49b1-b056-275eb932abc5", "AQAAAAEAACcQAAAAEOy56r3heZSxKtBYAvIF+O6N8znQ8UFSZgaIdWnzM0FUXBxo0Gzmh76RdCge2u/2uQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_ScoreBoards_ApplicationId",
                table: "ScoreBoards",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreBoards_StageId",
                table: "ScoreBoards",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_StageId",
                table: "Questions",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobID",
                table: "Applications",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantResponses_ApplicationId",
                table: "ApplicantResponses",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantResponses_QuestionId",
                table: "ApplicantResponses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantResponses_Applications_ApplicationId",
                table: "ApplicantResponses",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantResponses_Questions_QuestionId",
                table: "ApplicantResponses",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Jobs_JobID",
                table: "Applications",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Stages_StageId",
                table: "Questions",
                column: "StageId",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreBoards_Applications_ApplicationId",
                table: "ScoreBoards",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreBoards_Stages_StageId",
                table: "ScoreBoards",
                column: "StageId",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
