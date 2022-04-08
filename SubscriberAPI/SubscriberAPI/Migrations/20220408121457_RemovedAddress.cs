using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubscriberAPI.Migrations
{
    public partial class RemovedAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Subscribers_Tbl_Address_Su_AdressAd_Id",
                table: "Tbl_Subscribers");

            migrationBuilder.DropTable(
                name: "Tbl_Address");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Subscribers_Su_AdressAd_Id",
                table: "Tbl_Subscribers");

            migrationBuilder.RenameColumn(
                name: "Su_AdressAd_Id",
                table: "Tbl_Subscribers",
                newName: "Su_PostalCode");

            migrationBuilder.AddColumn<string>(
                name: "Su_City",
                table: "Tbl_Subscribers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Su_Street",
                table: "Tbl_Subscribers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Su_City",
                table: "Tbl_Subscribers");

            migrationBuilder.DropColumn(
                name: "Su_Street",
                table: "Tbl_Subscribers");

            migrationBuilder.RenameColumn(
                name: "Su_PostalCode",
                table: "Tbl_Subscribers",
                newName: "Su_AdressAd_Id");

            migrationBuilder.CreateTable(
                name: "Tbl_Address",
                columns: table => new
                {
                    Ad_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ad_PostalCode = table.Column<int>(type: "int", nullable: false),
                    Ad_Street = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Address", x => x.Ad_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Subscribers_Su_AdressAd_Id",
                table: "Tbl_Subscribers",
                column: "Su_AdressAd_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Subscribers_Tbl_Address_Su_AdressAd_Id",
                table: "Tbl_Subscribers",
                column: "Su_AdressAd_Id",
                principalTable: "Tbl_Address",
                principalColumn: "Ad_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
