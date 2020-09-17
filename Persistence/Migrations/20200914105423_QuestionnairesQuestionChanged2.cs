using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class QuestionnairesQuestionChanged2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                column: "Added",
                value: new DateTime(2020, 9, 14, 12, 54, 22, 795, DateTimeKind.Local).AddTicks(384));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                column: "Added",
                value: new DateTime(2020, 9, 14, 12, 48, 46, 632, DateTimeKind.Local).AddTicks(4238));
        }
    }
}
