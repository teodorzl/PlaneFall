namespace Planefall.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddPilotName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PilotName",
                table: "Flights",
                maxLength: 35,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PilotName",
                table: "Flights");
        }
    }
}