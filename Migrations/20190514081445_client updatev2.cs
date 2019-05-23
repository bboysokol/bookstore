using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Migrations
{
    public partial class clientupdatev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "AspNetUsers",
                newName: "PostCode");

            migrationBuilder.AlterColumn<string>(
                name: "ApartamentNumber",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostCode",
                table: "AspNetUsers",
                newName: "City");

            migrationBuilder.AlterColumn<string>(
                name: "ApartamentNumber",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
