using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Assignment_Webshop.Migrations
{
    public partial class Is_Dbinitilazer_working : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Out_of_Order",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Out_of_Order",
                table: "Products");
        }
    }
}
