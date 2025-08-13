using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace universty_dental_clinical.Migrations
{
    public partial class removestudentNamecolumntobooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Bookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
