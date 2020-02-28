using Microsoft.EntityFrameworkCore.Migrations;

namespace Planefall.Data.Migrations
{
    public partial class AddTicketEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Tickets",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Tickets");
        }
    }
}
