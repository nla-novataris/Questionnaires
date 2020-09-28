using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class QuestionAnswersAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Answers");

            migrationBuilder.CreateTable(
                name: "QuestionAnswers",
                columns: table => new
                {
                    QuestionID = table.Column<Guid>(nullable: false),
                    AnswerID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswers", x => new { x.QuestionID, x.AnswerID });
                    table.ForeignKey(
                        name: "FK_QuestionAnswers_Answers_AnswerID",
                        column: x => x.AnswerID,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAnswers_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_AnswerID",
                table: "QuestionAnswers",
                column: "AnswerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionAnswers");

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionId",
                table: "Answers",
                type: "char(36)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Questionnaires",
                columns: new[] { "Id", "Answered", "CreatorId", "Description", "LastEdited", "Started", "Target", "Title" },
                values: new object[] { new Guid("cf631fe8-2c15-486d-a68b-39d98bccf20a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 17, 15, 2, 51, 57, DateTimeKind.Local).AddTicks(6757), 12, "Test Questionnaire" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Added", "FirstName", "IsAdmin", "LastName", "UserName" },
                values: new object[] { "1", new DateTime(2020, 9, 17, 15, 2, 51, 55, DateTimeKind.Local).AddTicks(3664), "Test", true, "User", "TestUser" });

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Value 101" },
                    { 2, "Value 102" },
                    { 3, "Value 103" }
                });

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
    }
}
