using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITStepRazorApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PizzaModel",
                columns: new[] { "Id", "Chicken", "ExtraCheese", "ExtraSauce", "Ham", "IsLarge", "IsSmall", "Mushroom", "Name", "Pepperoni", "Pineapple", "Price" },
                values: new object[,]
                {
                    { 1, false, false, true, false, true, false, false, "Yuro Deluxe", true, false, 25f },
                    { 2, false, true, false, false, false, true, false, "Yuro Supreme", false, true, 30f },
                    { 3, true, false, true, false, true, false, true, "Yuro Deluxe", false, false, 25f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PizzaModel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PizzaModel",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PizzaModel",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
