using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcessLayers.Migrations
{
    /// <inheritdoc />
    public partial class ff3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialAdvanceHistories_FinancialAdvances_FinancialAdvanceId",
                table: "FinancialAdvanceHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialAdvances_AspNetUsers_ApplicaionuserId",
                table: "FinancialAdvances");

            migrationBuilder.DropTable(
                name: "UserProducts");

            migrationBuilder.DropTable(
                name: "SalseProductUserTyps");

            migrationBuilder.DropIndex(
                name: "IX_FinancialAdvances_ApplicaionuserId",
                table: "FinancialAdvances");

            migrationBuilder.DropIndex(
                name: "IX_FinancialAdvanceHistories_FinancialAdvanceId",
                table: "FinancialAdvanceHistories");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "FinancialAdvances");

            migrationBuilder.DropColumn(
                name: "ApplicaionuserId",
                table: "FinancialAdvances");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FinancialAdvances");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CustomerType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdentifierImge",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdentifierNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Job",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "FinancialAdvanceId",
                table: "FinancialAdvanceHistories",
                newName: "Stutes");

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PriceProductebytypesId",
                table: "FinancialAdvances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Qantity",
                table: "FinancialAdvances",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "price",
                table: "FinancialAdvances",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OldAmount",
                table: "FinancialAdvanceHistories",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "NewAmount",
                table: "FinancialAdvanceHistories",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FinancialAdvanceHistories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "FinancialAdvanceHistories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NotPayedmoneyId",
                table: "FinancialAdvanceHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    SalasDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Types = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicaionuserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerTypes_AspNetUsers_ApplicaionuserId",
                        column: x => x.ApplicaionuserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceProductebytypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: false),
                    Qantity = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<int>(type: "int", nullable: true),
                    FinancialUserCashId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceProductebytypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceProductebytypes_CustomerTypes_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriceProductebytypes_FinancialAdvances_FinancialUserCashId",
                        column: x => x.FinancialUserCashId,
                        principalTable: "FinancialAdvances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PriceProductebytypes_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotPayedmoney",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    SalasDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotpayedmoneyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNotPayedmoneyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PriceProductebytypesid = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    Stutes = table.Column<int>(type: "int", nullable: false),
                    QantityBuy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotPayedmoney", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotPayedmoney_AspNetUsers_UserNotPayedmoneyId",
                        column: x => x.UserNotPayedmoneyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotPayedmoney_PriceProductebytypes_PriceProductebytypesid",
                        column: x => x.PriceProductebytypesid,
                        principalTable: "PriceProductebytypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialAdvanceHistories_ApplicationUserId",
                table: "FinancialAdvanceHistories",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialAdvanceHistories_NotPayedmoneyId",
                table: "FinancialAdvanceHistories",
                column: "NotPayedmoneyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTypes_ApplicaionuserId",
                table: "CustomerTypes",
                column: "ApplicaionuserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotPayedmoney_PriceProductebytypesid",
                table: "NotPayedmoney",
                column: "PriceProductebytypesid");

            migrationBuilder.CreateIndex(
                name: "IX_NotPayedmoney_UserNotPayedmoneyId",
                table: "NotPayedmoney",
                column: "UserNotPayedmoneyId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceProductebytypes_CustomerTypeId",
                table: "PriceProductebytypes",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceProductebytypes_FinancialUserCashId",
                table: "PriceProductebytypes",
                column: "FinancialUserCashId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceProductebytypes_ProductId",
                table: "PriceProductebytypes",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialAdvanceHistories_AspNetUsers_ApplicationUserId",
                table: "FinancialAdvanceHistories",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialAdvanceHistories_NotPayedmoney_NotPayedmoneyId",
                table: "FinancialAdvanceHistories",
                column: "NotPayedmoneyId",
                principalTable: "NotPayedmoney",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialAdvanceHistories_AspNetUsers_ApplicationUserId",
                table: "FinancialAdvanceHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialAdvanceHistories_NotPayedmoney_NotPayedmoneyId",
                table: "FinancialAdvanceHistories");

            migrationBuilder.DropTable(
                name: "NotPayedmoney");

            migrationBuilder.DropTable(
                name: "PriceProductebytypes");

            migrationBuilder.DropTable(
                name: "CustomerTypes");

            migrationBuilder.DropIndex(
                name: "IX_FinancialAdvanceHistories_ApplicationUserId",
                table: "FinancialAdvanceHistories");

            migrationBuilder.DropIndex(
                name: "IX_FinancialAdvanceHistories_NotPayedmoneyId",
                table: "FinancialAdvanceHistories");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "products");

            migrationBuilder.DropColumn(
                name: "PriceProductebytypesId",
                table: "FinancialAdvances");

            migrationBuilder.DropColumn(
                name: "Qantity",
                table: "FinancialAdvances");

            migrationBuilder.DropColumn(
                name: "price",
                table: "FinancialAdvances");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "FinancialAdvanceHistories");

            migrationBuilder.DropColumn(
                name: "NotPayedmoneyId",
                table: "FinancialAdvanceHistories");

            migrationBuilder.RenameColumn(
                name: "Stutes",
                table: "FinancialAdvanceHistories",
                newName: "FinancialAdvanceId");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "FinancialAdvances",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ApplicaionuserId",
                table: "FinancialAdvances",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FinancialAdvances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OldAmount",
                table: "FinancialAdvanceHistories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "NewAmount",
                table: "FinancialAdvanceHistories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FinancialAdvanceHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerType",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentifierImge",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentifierNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Job",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SalseProductUserTyps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CustomerType = table.Column<int>(type: "int", nullable: false),
                    Qantity = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalseProductUserTyps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalseProductUserTyps_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicaionuserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SalseProductUserTypsId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    QantityBuy = table.Column<int>(type: "int", nullable: true),
                    SalasDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalseProductUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProducts_AspNetUsers_ApplicaionuserId",
                        column: x => x.ApplicaionuserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserProducts_SalseProductUserTyps_SalseProductUserTypsId",
                        column: x => x.SalseProductUserTypsId,
                        principalTable: "SalseProductUserTyps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProducts_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialAdvances_ApplicaionuserId",
                table: "FinancialAdvances",
                column: "ApplicaionuserId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialAdvanceHistories_FinancialAdvanceId",
                table: "FinancialAdvanceHistories",
                column: "FinancialAdvanceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalseProductUserTyps_ProductId",
                table: "SalseProductUserTyps",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_ApplicaionuserId",
                table: "UserProducts",
                column: "ApplicaionuserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_ProductId",
                table: "UserProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_SalseProductUserTypsId",
                table: "UserProducts",
                column: "SalseProductUserTypsId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialAdvanceHistories_FinancialAdvances_FinancialAdvanceId",
                table: "FinancialAdvanceHistories",
                column: "FinancialAdvanceId",
                principalTable: "FinancialAdvances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialAdvances_AspNetUsers_ApplicaionuserId",
                table: "FinancialAdvances",
                column: "ApplicaionuserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
