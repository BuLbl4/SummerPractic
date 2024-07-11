using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrafficLaws.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: new Guid("75ebab1b-9b8a-4b23-b31d-cf31d08a4a7d"));

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: new Guid("fc15d212-3eaa-4537-8fc4-0694025ce15c"));

            migrationBuilder.RenameColumn(
                name: "AnswerId",
                table: "UserResultAnswers",
                newName: "QuestionId");

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("5d4cb94a-9bec-427b-a19b-c1abef4abcbc"), "Тест на знание продвинутых правил дорожного движения", "Тест 2" },
                    { new Guid("8f7cfca6-24d3-458a-99a0-6711ce3203e1"), "Тест на знание основных правил дорожного движения", "Тест 1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: new Guid("5d4cb94a-9bec-427b-a19b-c1abef4abcbc"));

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: new Guid("8f7cfca6-24d3-458a-99a0-6711ce3203e1"));

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "UserResultAnswers",
                newName: "AnswerId");

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("75ebab1b-9b8a-4b23-b31d-cf31d08a4a7d"), "Тест на знание продвинутых правил дорожного движения", "Тест 2" },
                    { new Guid("fc15d212-3eaa-4537-8fc4-0694025ce15c"), "Тест на знание основных правил дорожного движения", "Тест 1" }
                });
        }
    }
}
