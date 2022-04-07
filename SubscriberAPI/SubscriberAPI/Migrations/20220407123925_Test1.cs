using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubscriberAPI.Migrations
{
    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Su_Id",
                table: "Tbl_Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Su_Id",
                table: "Tbl_Address",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
