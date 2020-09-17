using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ChangedAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Venue",
                table: "Answers");

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionId",
                table: "Answers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Questionnaires",
                columns: new[] { "Id", "Answered", "CreatorId", "Description", "LastEdited", "Started", "Target", "Title" },
                values: new object[] { new Guid("cf631fe8-2c15-486d-a68b-39d98bccf20a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 17, 15, 2, 51, 57, DateTimeKind.Local).AddTicks(6757), 12, "Test Questionnaire" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                column: "Added",
                value: new DateTime(2020, 9, 17, 15, 2, 51, 55, DateTimeKind.Local).AddTicks(3664));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers");

            migrationBuilder.DeleteData(
                table: "Questionnaires",
                keyColumn: "Id",
                keyValue: new Guid("cf631fe8-2c15-486d-a68b-39d98bccf20a"));

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Answers");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Answers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Answers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Answers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Answers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Venue",
                table: "Answers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                column: "Added",
                value: new DateTime(2020, 9, 14, 12, 54, 22, 795, DateTimeKind.Local).AddTicks(384));
        }
    }
}
