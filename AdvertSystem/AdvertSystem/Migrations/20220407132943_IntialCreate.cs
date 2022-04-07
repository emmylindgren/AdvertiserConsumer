using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvertSystem.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Address",
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
                    table.PrimaryKey("PK_Tbl_Address", x => x.Ad_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Companies",
                columns: table => new
                {
                    Co_OrgId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Co_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Co_Telephone = table.Column<int>(type: "int", nullable: false),
                    Co_AddressAd_Id = table.Column<int>(type: "int", nullable: false),
                    Co_BillingAddressAd_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Companies", x => x.Co_OrgId);
                    table.ForeignKey(
                        name: "FK_Tbl_Companies_Tbl_Address_Co_AddressAd_Id",
                        column: x => x.Co_AddressAd_Id,
                        principalTable: "Tbl_Address",
                        principalColumn: "Ad_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Companies_Tbl_Address_Co_BillingAddressAd_Id",
                        column: x => x.Co_BillingAddressAd_Id,
                        principalTable: "Tbl_Address",
                        principalColumn: "Ad_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Annonsorer",
                columns: table => new
                {
                    An_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    An_SubId = table.Column<int>(type: "int", nullable: false),
                    An_CoIdCo_OrgId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Annonsorer", x => x.An_Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Annonsorer_Tbl_Companies_An_CoIdCo_OrgId",
                        column: x => x.An_CoIdCo_OrgId,
                        principalTable: "Tbl_Companies",
                        principalColumn: "Co_OrgId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Ads",
                columns: table => new
                {
                    Ads_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ads_Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ads_ProductPrice = table.Column<int>(type: "int", nullable: false),
                    Ads_Price = table.Column<int>(type: "int", nullable: false),
                    Ads_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "IX_Tbl_Annonsorer_An_CoIdCo_OrgId",
                table: "Tbl_Annonsorer",
                column: "An_CoIdCo_OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Companies_Co_AddressAd_Id",
                table: "Tbl_Companies",
                column: "Co_AddressAd_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Companies_Co_BillingAddressAd_Id",
                table: "Tbl_Companies",
                column: "Co_BillingAddressAd_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Ads");

            migrationBuilder.DropTable(
                name: "Tbl_Annonsorer");

            migrationBuilder.DropTable(
                name: "Tbl_Companies");

            migrationBuilder.DropTable(
                name: "Tbl_Address");
        }
    }
}
