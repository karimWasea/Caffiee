using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcessLayers.Migrations
{
    /// <inheritdoc />
    public partial class CustomerTypesnewdname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypesName",
                table: "CustomerTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypesName",
                table: "CustomerTypes");
        }
    }
}
