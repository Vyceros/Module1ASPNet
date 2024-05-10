using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITStepRazorApp.Migrations
{
    /// <inheritdoc />
    public partial class createdNewPizzaModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PizzaModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IsLarge = table.Column<bool>(type: "bit", nullable: false),
                    IsSmall = table.Column<bool>(type: "bit", nullable: false),
                    Ham = table.Column<bool>(type: "bit", nullable: false),
                    Pepperoni = table.Column<bool>(type: "bit", nullable: false),
                    Pineapple = table.Column<bool>(type: "bit", nullable: false),
                    Mushroom = table.Column<bool>(type: "bit", nullable: false),
                    Chicken = table.Column<bool>(type: "bit", nullable: false),
                    ExtraSauce = table.Column<bool>(type: "bit", nullable: false),
                    ExtraCheese = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaModel");
        }
    }
}
