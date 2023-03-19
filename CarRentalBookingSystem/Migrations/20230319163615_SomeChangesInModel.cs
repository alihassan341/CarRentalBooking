using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalBookingSystem.Migrations
{
    public partial class SomeChangesInModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FleetImage",
                table: "FleetMasters");

            migrationBuilder.AddColumn<string>(
                name: "FleetUrl",
                table: "FleetMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ForGotpaswords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForGotpaswords", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForGotpaswords");

            migrationBuilder.DropColumn(
                name: "FleetUrl",
                table: "FleetMasters");

            migrationBuilder.AddColumn<short>(
                name: "FleetImage",
                table: "FleetMasters",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
