using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Todo.ClientApp.Migrations
{
    public partial class ModifyTodoItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ArchivedDateTime",
                table: "TodoItems",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "TodoItems",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDateTime",
                table: "TodoItems",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TodoItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArchivedDateTime",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "Colour",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TodoItems");
        }
    }
}
