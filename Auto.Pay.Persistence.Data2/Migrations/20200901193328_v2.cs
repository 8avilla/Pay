using Microsoft.EntityFrameworkCore.Migrations;

namespace Auto.Pay.Persistence.Data2.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentReferenceObject",
                table: "PaymentReference",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrdersObject",
                table: "Orders",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrdersStatusObject",
                table: "Orders",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentReferenceObject",
                table: "PaymentReference");

            migrationBuilder.DropColumn(
                name: "OrdersObject",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrdersStatusObject",
                table: "Orders");
        }
    }
}
