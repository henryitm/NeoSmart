using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeoSmart.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddCapacitationEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Capacitations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capacitations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Capacitations_Name",
                table: "Capacitations",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Capacitations");
        }
    }
}
