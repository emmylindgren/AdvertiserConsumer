using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubscriberAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Ad_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ad_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ad_PostalCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Ad_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Subscribers",
                columns: table => new
                {
                    Su_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Su_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Su_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Su_PersonId = table.Column<int>(type: "int", nullable: false),
                    Su_AdressAd_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Subscribers", x => x.Su_Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Subscribers_Address_Su_AdressAd_Id",
                        column: x => x.Su_AdressAd_Id,
                        principalTable: "Address",
                        principalColumn: "Ad_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Subscribers_Su_AdressAd_Id",
                table: "Tbl_Subscribers",
                column: "Su_AdressAd_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Subscribers");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
