using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace universty_dental_clinical.Migrations
{
    public partial class intial8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Bookings",
                newName: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Bookings",
                newName: "StudentId");
        }
    }
}
