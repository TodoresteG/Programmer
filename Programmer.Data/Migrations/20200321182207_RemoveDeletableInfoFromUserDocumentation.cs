using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Programmer.Data.Migrations
{
    public partial class RemoveDeletableInfoFromUserDocumentation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UserDocumentations");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UserDocumentations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserDocumentations");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "UserDocumentations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UserDocumentations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UserDocumentations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserDocumentations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "UserDocumentations",
                type: "datetime2",
                nullable: true);
        }
    }
}
