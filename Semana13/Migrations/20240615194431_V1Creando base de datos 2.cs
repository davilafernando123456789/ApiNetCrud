﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Semana13.Migrations
{
    /// <inheritdoc />
    public partial class V1Creandobasededatos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Activo",
                table: "Enrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Activo",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Courses");
        }
    }
}
