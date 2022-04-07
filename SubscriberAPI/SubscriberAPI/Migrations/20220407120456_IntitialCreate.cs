using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubscriberAPI.Migrations
{
    public partial class IntitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Subscribers",
                columns: table => new
                {
                    Su_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Su_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Su_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Su_PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Subscribers", x => x.Su_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Address",
                columns: table => new
                {
                    Ad_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Su_Id = table.Column<int>(type: "int", nullable: false),
                    Ad_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ad_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ad_PostalCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Address", x => x.Ad_Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Address_Tbl_Subscribers_Su_Id",
                        column: x => x.Su_Id,
                        principalTable: "Tbl_Subscribers",
                        principalColumn: "Su_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Address_Su_Id",
                table: "Tbl_Address",
                column: "Su_Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Address");

            migrationBuilder.DropTable(
                name: "Tbl_Subscribers");
        }
    }
}
