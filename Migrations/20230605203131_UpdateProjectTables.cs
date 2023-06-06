﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagmentApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProjectTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Teams",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teams",
                newName: "TeamId");
        }
    }
}
