using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace universty_dental_clinical.Migrations
{
    public partial class addsignaturefieldtobookingtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Signature",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Signature",
                table: "Bookings");
        }
    }
}
