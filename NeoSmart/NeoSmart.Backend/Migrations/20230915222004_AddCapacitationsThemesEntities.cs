using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeoSmart.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddCapacitationsThemesEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CapacitationsThemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapacitationId = table.Column<int>(type: "int", nullable: false),
                    ThemeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacitationsThemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CapacitationsThemes_Capacitations_CapacitationId",
                        column: x => x.CapacitationId,
                        principalTable: "Capacitations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapacitationsThemes_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Themes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapacitationsThemes_CapacitationId",
                table: "CapacitationsThemes",
                column: "CapacitationId");

            migrationBuilder.CreateIndex(
                name: "IX_CapacitationsThemes_Id",
                table: "CapacitationsThemes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CapacitationsThemes_ThemeId",
                table: "CapacitationsThemes",
                column: "ThemeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapacitationsThemes");
        }
    }
}
