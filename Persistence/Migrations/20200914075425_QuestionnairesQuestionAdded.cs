using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class QuestionnairesQuestionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Venue",
                table: "Questions");

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionnaireId",
                table: "Questions",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                column: "Added",
                value: new DateTime(2020, 9, 14, 9, 54, 24, 799, DateTimeKind.Local).AddTicks(6425));

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionnaireId",
                table: "Questions",
                column: "QuestionnaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Questionnaires_QuestionnaireId",
                table: "Questions",
                column: "QuestionnaireId",
                principalTable: "Questionnaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Questionnaires_QuestionnaireId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionnaireId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionnaireId",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Questions",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Questions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Venue",
                table: "Questions",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                column: "Added",
                value: new DateTime(2020, 9, 13, 20, 2, 50, 619, DateTimeKind.Local).AddTicks(2127));
        }
    }
}
