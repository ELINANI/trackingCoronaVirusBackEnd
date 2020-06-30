using Microsoft.EntityFrameworkCore.Migrations;

namespace trackingCoronaVirusBackEnd2.Migrations
{
    public partial class CreeatDfyyyssssfsfds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "age",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "age",
                table: "Clients",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
