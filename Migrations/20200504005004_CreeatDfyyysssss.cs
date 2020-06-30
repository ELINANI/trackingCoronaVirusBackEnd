using Microsoft.EntityFrameworkCore.Migrations;

namespace trackingCoronaVirusBackEnd2.Migrations
{
    public partial class CreeatDfyyysssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Niveaux",
                columns: table => new
                {
                    codeNiveau = table.Column<string>(type: "varchar(150)", nullable: false),
                    typeNiveau = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveaux", x => x.codeNiveau);
                });

            migrationBuilder.CreateTable(
                name: "Quartiers",
                columns: table => new
                {
                    codeQuartier = table.Column<string>(type: "varchar(150)", nullable: false),
                    nomQuartier = table.Column<string>(nullable: false),
                    lng = table.Column<double>(nullable: false),
                    lat = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quartiers", x => x.codeQuartier);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    codeClient = table.Column<string>(type: "varchar(150)", nullable: false),
                    nomClient = table.Column<string>(nullable: false),
                    prenomClient = table.Column<string>(nullable: false),
                    age = table.Column<int>(nullable: false),
                    sexeClient = table.Column<string>(nullable: false),
                    phoneClient = table.Column<string>(nullable: false),
                    codeQuartier = table.Column<string>(nullable: true),
                    codeNiveau = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.codeClient);
                    table.ForeignKey(
                        name: "FK_Clients_Niveaux_codeNiveau",
                        column: x => x.codeNiveau,
                        principalTable: "Niveaux",
                        principalColumn: "codeNiveau",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Quartiers_codeQuartier",
                        column: x => x.codeQuartier,
                        principalTable: "Quartiers",
                        principalColumn: "codeQuartier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hopitaux",
                columns: table => new
                {
                    codeHopitale = table.Column<string>(type: "varchar(150)", nullable: false),
                    loginHopitale = table.Column<string>(type: "varchar(150)", nullable: true),
                    nomHopitale = table.Column<string>(type: "varchar(150)", nullable: false),
                    phoneHopitale = table.Column<string>(type: "varchar(150)", nullable: false),
                    pwdHopitale = table.Column<string>(type: "varchar(150)", nullable: false),
                    codeQuartier = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hopitaux", x => x.codeHopitale);
                    table.ForeignKey(
                        name: "FK_Hopitaux_Quartiers_codeQuartier",
                        column: x => x.codeQuartier,
                        principalTable: "Quartiers",
                        principalColumn: "codeQuartier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contaminations",
                columns: table => new
                {
                    codeContamination = table.Column<string>(type: "varchar(150)", nullable: false),
                    dateContamination = table.Column<string>(type: "varchar(150)", nullable: true),
                    codeClient = table.Column<string>(nullable: true),
                    codeHopitale = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contaminations", x => x.codeContamination);
                    table.ForeignKey(
                        name: "FK_contaminations_Clients_codeClient",
                        column: x => x.codeClient,
                        principalTable: "Clients",
                        principalColumn: "codeClient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contaminations_Hopitaux_codeHopitale",
                        column: x => x.codeHopitale,
                        principalTable: "Hopitaux",
                        principalColumn: "codeHopitale",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_codeNiveau",
                table: "Clients",
                column: "codeNiveau");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_codeQuartier",
                table: "Clients",
                column: "codeQuartier");

            migrationBuilder.CreateIndex(
                name: "IX_contaminations_codeClient",
                table: "contaminations",
                column: "codeClient");

            migrationBuilder.CreateIndex(
                name: "IX_contaminations_codeHopitale",
                table: "contaminations",
                column: "codeHopitale");

            migrationBuilder.CreateIndex(
                name: "IX_Hopitaux_codeQuartier",
                table: "Hopitaux",
                column: "codeQuartier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contaminations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Hopitaux");

            migrationBuilder.DropTable(
                name: "Niveaux");

            migrationBuilder.DropTable(
                name: "Quartiers");
        }
    }
}
