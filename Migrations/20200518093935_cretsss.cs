using Microsoft.EntityFrameworkCore.Migrations;

namespace trackingCoronaVirusBackEnd2.Migrations
{
    public partial class cretsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Niveaux_codeNiveau",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_codeNiveau",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "codeNiveau",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "photoHopitale",
                table: "Hopitaux",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photoHopitale",
                table: "Hopitaux");

            migrationBuilder.AddColumn<string>(
                name: "codeNiveau",
                table: "Clients",
                type: "varchar(150)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_codeNiveau",
                table: "Clients",
                column: "codeNiveau");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Niveaux_codeNiveau",
                table: "Clients",
                column: "codeNiveau",
                principalTable: "Niveaux",
                principalColumn: "codeNiveau",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
