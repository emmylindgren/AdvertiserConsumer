using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvertSystem.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Companies",
                columns: table => new
                {
                    Co_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Co_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Co_Telephone = table.Column<int>(type: "int", nullable: false),
                    Co_OrgId = table.Column<int>(type: "int", nullable: false),
                    Co_BillStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Co_BillPostalCode = table.Column<int>(type: "int", nullable: false),
                    Co_BillCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Co_Steet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Co_PostalCode = table.Column<int>(type: "int", nullable: false),
                    Co_City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Companies", x => x.Co_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Annonsorer",
                columns: table => new
                {
                    An_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    An_SubId = table.Column<int>(type: "int", nullable: true),
                    An_CoIdCo_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Annonsorer", x => x.An_Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Annonsorer_Tbl_Companies_An_CoIdCo_Id",
                        column: x => x.An_CoIdCo_Id,
                        principalTable: "Tbl_Companies",
                        principalColumn: "Co_Id");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Ads",
                columns: table => new
                {
                    Ads_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ads_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ads_Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ads_ProductPrice = table.Column<int>(type: "int", nullable: false),
                    Ads_Price = table.Column<int>(type: "int", nullable: false),
                    Ads_AnnonsorAn_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Ads", x => x.Ads_Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Ads_Tbl_Annonsorer_Ads_AnnonsorAn_Id",
                        column: x => x.Ads_AnnonsorAn_Id,
                        principalTable: "Tbl_Annonsorer",
                        principalColumn: "An_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Ads_Ads_AnnonsorAn_Id",
                table: "Tbl_Ads",
                column: "Ads_AnnonsorAn_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Annonsorer_An_CoIdCo_Id",
                table: "Tbl_Annonsorer",
                column: "An_CoIdCo_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Ads");

            migrationBuilder.DropTable(
                name: "Tbl_Annonsorer");

            migrationBuilder.DropTable(
                name: "Tbl_Companies");
        }
    }
}
