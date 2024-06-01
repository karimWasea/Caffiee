using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcessLayers.Migrations
{
    /// <inheritdoc />
    public partial class deletcustermar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CustomerTypes_CustomerTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceProductebytypes_CustomerTypes_CustomerTypeId",
                table: "PriceProductebytypes");

            migrationBuilder.DropTable(
                name: "CustomerTypes");

            migrationBuilder.DropIndex(
                name: "IX_PriceProductebytypes_CustomerTypeId",
                table: "PriceProductebytypes");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CustomerTypeId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerType",
                table: "PriceProductebytypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerType",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerType",
                table: "PriceProductebytypes");

            migrationBuilder.DropColumn(
                name: "CustomerType",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    SystemUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Types = table.Column<int>(type: "int", nullable: true),
                    TypesName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceProductebytypes_CustomerTypeId",
                table: "PriceProductebytypes",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomerTypeId",
                table: "AspNetUsers",
                column: "CustomerTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CustomerTypes_CustomerTypeId",
                table: "AspNetUsers",
                column: "CustomerTypeId",
                principalTable: "CustomerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceProductebytypes_CustomerTypes_CustomerTypeId",
                table: "PriceProductebytypes",
                column: "CustomerTypeId",
                principalTable: "CustomerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
