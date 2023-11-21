using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ammount",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Services",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Services",
                newName: "Type");

            migrationBuilder.AddColumn<int>(
                name: "Ammount",
                table: "Services",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
