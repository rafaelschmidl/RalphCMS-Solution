using Microsoft.EntityFrameworkCore.Migrations;

namespace RalphCMS.Data.Migrations
{
    public partial class isInNavMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddToNavMenu",
                table: "Pages");

            migrationBuilder.AddColumn<bool>(
                name: "IsInNavMenu",
                table: "Pages",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInNavMenu",
                table: "Pages");

            migrationBuilder.AddColumn<bool>(
                name: "AddToNavMenu",
                table: "Pages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
