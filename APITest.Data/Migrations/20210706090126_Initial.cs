using Microsoft.EntityFrameworkCore.Migrations;

namespace APITest.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllBaseStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hp = table.Column<long>(type: "bigint", nullable: false),
                    Attack = table.Column<long>(type: "bigint", nullable: false),
                    Defense = table.Column<long>(type: "bigint", nullable: false),
                    SpAttack = table.Column<long>(type: "bigint", nullable: false),
                    SpDefense = table.Column<long>(type: "bigint", nullable: false),
                    Speed = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllBaseStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Names",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    English = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Japanese = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chinese = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    French = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Names", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pokémons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameId = table.Column<int>(type: "int", nullable: true),
                    StatsId = table.Column<int>(type: "int", nullable: true),
                    SpriteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokémons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokémons_AllBaseStats_StatsId",
                        column: x => x.StatsId,
                        principalTable: "AllBaseStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pokémons_Names_NameId",
                        column: x => x.NameId,
                        principalTable: "Names",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PokémonType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PokémonId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokémonType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokémonType_Pokémons_PokémonId",
                        column: x => x.PokémonId,
                        principalTable: "Pokémons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokémons_NameId",
                table: "Pokémons",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokémons_StatsId",
                table: "Pokémons",
                column: "StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_PokémonType_PokémonId",
                table: "PokémonType",
                column: "PokémonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokémonType");

            migrationBuilder.DropTable(
                name: "Pokémons");

            migrationBuilder.DropTable(
                name: "AllBaseStats");

            migrationBuilder.DropTable(
                name: "Names");
        }
    }
}
