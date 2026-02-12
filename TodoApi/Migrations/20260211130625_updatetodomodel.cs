using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class updatetodomodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Todos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "duedate",
                table: "Todos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "priority",
                table: "Todos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "Todos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Todos_userid",
                table: "Todos",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_users_userid",
                table: "Todos",
                column: "userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_users_userid",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_userid",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "duedate",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "priority",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Todos");
        }
    }
}
