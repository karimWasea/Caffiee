using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcessLayers.Migrations
{
    /// <inheritdoc />
    public partial class CustomerTypesnewd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalasDateTime",
                table: "CustomerTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SalasDateTime",
                table: "CustomerTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
