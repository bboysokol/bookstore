using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Migrations
{
    public partial class bookfix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_Title_PublishmentYear",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "PublishmentYear",
                table: "Books",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Books_Title",
                table: "Books",
                column: "Title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_Title",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "PublishmentYear",
                table: "Books",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Books_Title_PublishmentYear",
                table: "Books",
                columns: new[] { "Title", "PublishmentYear" },
                unique: true);
        }
    }
}
