using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcessLayers.Migrations
{
    /// <inheritdoc />
    public partial class sysuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SystemUserId",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SystemUserName",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SystemUserId",
                table: "PriceProductebytypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SystemUserName",
                table: "PriceProductebytypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SystemUserId",
                table: "NotPayedmoney",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SystemUserName",
                table: "NotPayedmoney",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SystemUserId",
                table: "FinancialAdvances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SystemUserName",
                table: "FinancialAdvances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SystemUserId",
                table: "FinancialAdvanceHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SystemUserName",
                table: "FinancialAdvanceHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TypesName",
                table: "CustomerTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Types",
                table: "CustomerTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "SystemUserId",
                table: "CustomerTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SystemUserName",
                table: "CustomerTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SystemUserId",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SystemUserName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SystemUserId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SystemUserName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CategoryAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SystemUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryAttachments_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    SystemUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemUserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttachments_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAttachments_CategoryId",
                table: "CategoryAttachments",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttachments_ProductId",
                table: "ProductAttachments",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryAttachments");

            migrationBuilder.DropTable(
                name: "ProductAttachments");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "SystemUserName",
                table: "products");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "PriceProductebytypes");

            migrationBuilder.DropColumn(
                name: "SystemUserName",
                table: "PriceProductebytypes");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "NotPayedmoney");

            migrationBuilder.DropColumn(
                name: "SystemUserName",
                table: "NotPayedmoney");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "FinancialAdvances");

            migrationBuilder.DropColumn(
                name: "SystemUserName",
                table: "FinancialAdvances");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "FinancialAdvanceHistories");

            migrationBuilder.DropColumn(
                name: "SystemUserName",
                table: "FinancialAdvanceHistories");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "SystemUserName",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SystemUserName",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SystemUserName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "TypesName",
                table: "CustomerTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Types",
                table: "CustomerTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
