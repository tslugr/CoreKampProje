using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class migblogrvz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogStotus",
                table: "Blogs");

            migrationBuilder.AddColumn<bool>(
                name: "BlogStatus",
                table: "Blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogStatus",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "BlogStotus",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
