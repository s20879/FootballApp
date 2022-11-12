using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballApp.Migrations
{
    public partial class AddedCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCoutry",
                table: "Footballers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    IdCountry = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.IdCountry);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Footballers_IdCoutry",
                table: "Footballers",
                column: "IdCoutry");

            migrationBuilder.AddForeignKey(
                name: "FK_Footballers_Countries_IdCoutry",
                table: "Footballers",
                column: "IdCoutry",
                principalTable: "Countries",
                principalColumn: "IdCountry");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Footballers_Countries_IdCoutry",
                table: "Footballers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Footballers_IdCoutry",
                table: "Footballers");

            migrationBuilder.DropColumn(
                name: "IdCoutry",
                table: "Footballers");
        }
    }
}
