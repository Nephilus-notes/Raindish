using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Raindish.Migrations
{
    /// <inheritdoc />
    public partial class TempoAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tempo",
                table: "Song",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tempo",
                table: "Song");
        }
    }
}
