using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace universty_dental_clinical.Migrations
{
    public partial class addrelationbetweenstudentbooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Diagnose",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_StudentId",
                table: "Bookings",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Students_StudentId",
                table: "Bookings",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Students_StudentId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_StudentId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Diagnose",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Bookings");
        }
    }
}
