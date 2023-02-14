﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Raindish.Migrations
{
    /// <inheritdoc />
    public partial class AddedLyricURLField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lyrics",
                table: "Song",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lyrics",
                table: "Song");
        }
    }
}
