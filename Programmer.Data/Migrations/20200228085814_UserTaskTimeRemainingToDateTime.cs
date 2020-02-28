using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Programmer.Data.Migrations
{
    public partial class UserTaskTimeRemainingToDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TaskTimeRemaining",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TaskTimeRemaining",
                table: "AspNetUsers",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
