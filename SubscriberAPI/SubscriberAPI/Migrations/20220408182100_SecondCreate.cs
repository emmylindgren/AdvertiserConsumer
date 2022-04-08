using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubscriberAPI.Migrations
{
    public partial class SecondCreate : Migration
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
                    Su_PersonId = table.Column<long>(type: "bigint", nullable: false),
                    Su_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Su_PostalCode = table.Column<int>(type: "int", nullable: false),
                    Su_City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Subscribers", x => x.Su_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Subscribers");
        }
    }
}
