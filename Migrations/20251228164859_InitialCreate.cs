using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotekaProjekt.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zasoby",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tytul = table.Column<string>(type: "TEXT", nullable: false),
                    RokWydania = table.Column<int>(type: "INTEGER", nullable: false),
                    CzyWypozyczony = table.Column<bool>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    Rezyser = table.Column<string>(type: "TEXT", nullable: true),
                    CzasTrwaniaMinuty = table.Column<int>(type: "INTEGER", nullable: true),
                    Autor = table.Column<string>(type: "TEXT", nullable: true),
                    LiczbaStron = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zasoby", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zasoby");
        }
    }
}
