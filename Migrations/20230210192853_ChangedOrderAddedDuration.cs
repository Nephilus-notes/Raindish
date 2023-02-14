using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Raindish.Migrations
{
    /// <inheritdoc />
    public partial class ChangedOrderAddedDuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ProductionRecording",
                table: "Song",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Duration",
                table: "Song",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Song");

            migrationBuilder.AlterColumn<bool>(
                name: "ProductionRecording",
                table: "Song",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
