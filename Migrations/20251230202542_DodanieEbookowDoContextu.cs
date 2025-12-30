using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotekaProjekt.Migrations
{
    /// <inheritdoc />
    public partial class DodanieEbookowDoContextu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ebook_Autor",
                table: "Zasoby",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ebook_LiczbaStron",
                table: "Zasoby",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ebook_Autor",
                table: "Zasoby");

            migrationBuilder.DropColumn(
                name: "Ebook_LiczbaStron",
                table: "Zasoby");
        }
    }
}
