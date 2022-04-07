using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubscriberAPI.Migrations
{
    public partial class ChangedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Subscribers_Address_Su_AdressAd_Id",
                table: "Tbl_Subscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Tbl_Address");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Address",
                table: "Tbl_Address",
                column: "Ad_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Subscribers_Tbl_Address_Su_AdressAd_Id",
                table: "Tbl_Subscribers",
                column: "Su_AdressAd_Id",
                principalTable: "Tbl_Address",
                principalColumn: "Ad_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Subscribers_Tbl_Address_Su_AdressAd_Id",
                table: "Tbl_Subscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Address",
                table: "Tbl_Address");

            migrationBuilder.RenameTable(
                name: "Tbl_Address",
                newName: "Address");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Ad_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Subscribers_Address_Su_AdressAd_Id",
                table: "Tbl_Subscribers",
                column: "Su_AdressAd_Id",
                principalTable: "Address",
                principalColumn: "Ad_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
