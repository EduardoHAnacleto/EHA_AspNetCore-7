using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EHA_AspNetCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialBillsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "BillToReceiveSequence");

            migrationBuilder.CreateTable(
                name: "BillsToPay",
                columns: table => new
                {
                    BillNumber = table.Column<int>(type: "int", nullable: false),
                    BillModel = table.Column<int>(type: "int", nullable: false),
                    BillSeries = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    InstalmentNumber = table.Column<int>(type: "int", nullable: false),
                    EmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancelledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancellationMotive = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValuePaid = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillsToPay", x => new { x.BillModel, x.BillNumber, x.BillSeries, x.SupplierId, x.InstalmentNumber });
                    table.ForeignKey(
                        name: "FK_BillsToPay_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillsToPay_Purchases_BillModel_BillNumber_BillSeries_SupplierId",
                        columns: x => new { x.BillModel, x.BillNumber, x.BillSeries, x.SupplierId },
                        principalTable: "Purchases",
                        principalColumns: new[] { "BillModel", "BillNumber", "BillSeries", "SupplierId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillsToPay_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillsToReceive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [BillToReceiveSequence]"),
                    InstalmentNumber = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancellationMotive = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValuePaid = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillsToReceive", x => new { x.InstalmentNumber, x.Id });
                    table.ForeignKey(
                        name: "FK_BillsToReceive_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillsToReceive_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillsToReceive_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillsToPay_PaymentMethodId",
                table: "BillsToPay",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_BillsToPay_SupplierId",
                table: "BillsToPay",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_BillsToReceive_CustomerId",
                table: "BillsToReceive",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BillsToReceive_PaymentMethodId",
                table: "BillsToReceive",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_BillsToReceive_SaleId",
                table: "BillsToReceive",
                column: "SaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillsToPay");

            migrationBuilder.DropTable(
                name: "BillsToReceive");

            migrationBuilder.DropSequence(
                name: "BillToReceiveSequence");
        }
    }
}
