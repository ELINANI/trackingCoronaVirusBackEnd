using Microsoft.EntityFrameworkCore.Migrations;

namespace trackingCoronaVirusBackEnd2.Migrations
{
    public partial class creatsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "codeNiveau",
                table: "contaminations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_contaminations_codeNiveau",
                table: "contaminations",
                column: "codeNiveau");

            migrationBuilder.AddForeignKey(
                name: "FK_contaminations_Niveaux_codeNiveau",
                table: "contaminations",
                column: "codeNiveau",
                principalTable: "Niveaux",
                principalColumn: "codeNiveau",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contaminations_Niveaux_codeNiveau",
                table: "contaminations");

            migrationBuilder.DropIndex(
                name: "IX_contaminations_codeNiveau",
                table: "contaminations");

            migrationBuilder.DropColumn(
                name: "codeNiveau",
                table: "contaminations");
        }
    }
}
