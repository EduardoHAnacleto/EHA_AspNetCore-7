using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EHA_AspNetCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialPurchaseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    BillModel = table.Column<int>(type: "int", nullable: false),
                    BillNumber = table.Column<int>(type: "int", nullable: false),
                    BillSeries = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    CancellationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancellationMotive = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentConditionId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FreightValue = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ExtraExpenses = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    InsuranceValue = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => new { x.BillModel, x.BillNumber, x.BillSeries, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_Purchases_PaymentConditions_PaymentConditionId",
                        column: x => x.PaymentConditionId,
                        principalTable: "PaymentConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Purchases_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ItemsPurchase",
                columns: table => new
                {
                    PurchaseBillModel = table.Column<int>(type: "int", nullable: false),
                    PurchaseBillNumber = table.Column<int>(type: "int", nullable: false),
                    PurchaseBillSeries = table.Column<int>(type: "int", nullable: false),
                    PurchaseSupplierId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ProductValue = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CancelledDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsPurchase", x => new { x.PurchaseBillModel, x.PurchaseBillNumber, x.PurchaseBillSeries, x.PurchaseSupplierId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ItemsPurchase_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsPurchase_Purchases_PurchaseBillModel_PurchaseBillNumber_PurchaseBillSeries_PurchaseSupplierId",
                        columns: x => new { x.PurchaseBillModel, x.PurchaseBillNumber, x.PurchaseBillSeries, x.PurchaseSupplierId },
                        principalTable: "Purchases",
                        principalColumns: new[] { "BillModel", "BillNumber", "BillSeries", "SupplierId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemsPurchase_ProductId",
                table: "ItemsPurchase",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PaymentConditionId",
                table: "Purchases",
                column: "PaymentConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SupplierId",
                table: "Purchases",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsPurchase");

            migrationBuilder.DropTable(
                name: "Purchases");
        }
    }
}
