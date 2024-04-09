using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingSystemSematec.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddShemaAndConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.EnsureSchema(
                name: "BASE");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "BASE");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brands",
                newSchema: "BASE");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "BASE",
                table: "Brands",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BASE_Brand",
                schema: "BASE",
                table: "Brands",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BASE_Brand",
                schema: "BASE",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "BASE",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Brands",
                schema: "BASE",
                newName: "Brands");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");
        }
    }
}
