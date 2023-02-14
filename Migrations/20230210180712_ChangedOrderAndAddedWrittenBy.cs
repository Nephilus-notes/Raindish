using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Raindish.Migrations
{
    /// <inheritdoc />
    public partial class ChangedOrderAndAddedWrittenBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WRittenBy",
                table: "Song",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Charles McCall");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WrittenBy",
                table: "Song");
        }
    }
}
