using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PontoTuristicoApp.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarIndiceBusca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PontosTuristicos_Cidade",
                table: "PontosTuristicos",
                column: "Cidade");

            migrationBuilder.CreateIndex(
                name: "IX_PontosTuristicos_Nome",
                table: "PontosTuristicos",
                column: "Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PontosTuristicos_Cidade",
                table: "PontosTuristicos");

            migrationBuilder.DropIndex(
                name: "IX_PontosTuristicos_Nome",
                table: "PontosTuristicos");
        }
    }
}
