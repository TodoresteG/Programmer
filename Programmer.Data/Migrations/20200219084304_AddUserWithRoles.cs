using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgrammerDemo.Data.Migrations
{
    public partial class AddUserWithRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<double>(
                name: "AbstractThinking",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Algorithms",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AspNetCore",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Bitcoins",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "CSharp",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Coding",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Creativity",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Css",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Curiosity",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DataStructures",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DatabasesAndSQL",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "EfCore",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Energy",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Html",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Money",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "NodeJs",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ProblemSolving",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "React",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TaskTimeRemaining",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Teamwork",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Testing",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VanillaJavaScript",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Xp",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "ProgrammerUserId",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgrammerUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_AspNetUsers_ProgrammerUserId",
                        column: x => x.ProgrammerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documentation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgrammerUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentation_AspNetUsers_ProgrammerUserId",
                        column: x => x.ProgrammerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgrammerUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_AspNetUsers_ProgrammerUserId",
                        column: x => x.ProgrammerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobTask",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgrammerUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobTask_AspNetUsers_ProgrammerUserId",
                        column: x => x.ProgrammerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_ProgrammerUserId",
                table: "AspNetRoles",
                column: "ProgrammerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_ProgrammerUserId",
                table: "Course",
                column: "ProgrammerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentation_ProgrammerUserId",
                table: "Documentation",
                column: "ProgrammerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_ProgrammerUserId",
                table: "Event",
                column: "ProgrammerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTask_ProgrammerUserId",
                table: "JobTask",
                column: "ProgrammerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_ProgrammerUserId",
                table: "AspNetRoles",
                column: "ProgrammerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_ProgrammerUserId",
                table: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Documentation");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "JobTask");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_ProgrammerUserId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "AbstractThinking",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Algorithms",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AspNetCore",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Bitcoins",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CSharp",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Coding",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Creativity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Css",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Curiosity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DataStructures",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DatabasesAndSQL",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EfCore",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Energy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Html",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Money",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NodeJs",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProblemSolving",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "React",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TaskTimeRemaining",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Teamwork",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Testing",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VanillaJavaScript",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Xp",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProgrammerUserId",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
