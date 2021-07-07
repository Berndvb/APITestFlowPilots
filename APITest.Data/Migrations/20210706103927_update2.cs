using Microsoft.EntityFrameworkCore.Migrations;

namespace APITest.Data.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokémonType_Pokémons_PokémonId",
                table: "PokémonType");

            migrationBuilder.DropIndex(
                name: "IX_PokémonType_PokémonId",
                table: "PokémonType");

            migrationBuilder.DropColumn(
                name: "PokémonId",
                table: "PokémonType");

            migrationBuilder.CreateTable(
                name: "PokémonPokémonType",
                columns: table => new
                {
                    PokémonsId = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokémonPokémonType", x => new { x.PokémonsId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_PokémonPokémonType_Pokémons_PokémonsId",
                        column: x => x.PokémonsId,
                        principalTable: "Pokémons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokémonPokémonType_PokémonType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "PokémonType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokémonPokémonType_TypeId",
                table: "PokémonPokémonType",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokémonPokémonType");

            migrationBuilder.AddColumn<long>(
                name: "PokémonId",
                table: "PokémonType",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PokémonType_PokémonId",
                table: "PokémonType",
                column: "PokémonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PokémonType_Pokémons_PokémonId",
                table: "PokémonType",
                column: "PokémonId",
                principalTable: "Pokémons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
