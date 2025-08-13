using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace universty_dental_clinical.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "PassWord",
                table: "Students",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "PassWord",
                table: "Patients",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "PassWord",
                table: "Admins",
                newName: "Password");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Students",
                newName: "PassWord");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Patients",
                newName: "PassWord");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Admins",
                newName: "PassWord");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
