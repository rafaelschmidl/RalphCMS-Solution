using Microsoft.EntityFrameworkCore.Migrations;

namespace RalphCMS.Data.Migrations
{
    public partial class addToNavMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AddToNavMenu",
                table: "Pages",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddToNavMenu",
                table: "Pages");
        }
    }
}
