using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Migration = Microsoft.EntityFrameworkCore.Migrations.Migration;

namespace Auto.Pay.Persistence.Data2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentReference",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentReferenceCode = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentReference", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentReferenceId = table.Column<long>(nullable: false),
                    OrderCredibancoId = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<long>(nullable: false),
                    AmountPaid = table.Column<long>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    ReturnUrl = table.Column<string>(nullable: true),
                    FailUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PageView = table.Column<string>(nullable: true),
                    ClientId = table.Column<string>(nullable: true),
                    MerchantLogin = table.Column<string>(nullable: true),
                    JsonParams = table.Column<string>(nullable: true),
                    SessionTimeoutSecs = table.Column<DateTime>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    Features = table.Column<string>(nullable: true),
                    PaymentFromUrlCredibanco = table.Column<string>(nullable: true),
                    PaymentStatus = table.Column<int>(nullable: false),
                    DescriptionPaymentStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ORDERS_PaymentReference_PaymentReferenceId",
                        column: x => x.PaymentReferenceId,
                        principalTable: "PaymentReference",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_PaymentReferenceId",
                table: "ORDERS",
                column: "PaymentReferenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ORDERS");

            migrationBuilder.DropTable(
                name: "PaymentReference");
        }
    }
}
