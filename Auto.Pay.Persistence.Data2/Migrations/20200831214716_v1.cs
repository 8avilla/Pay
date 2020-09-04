using Microsoft.EntityFrameworkCore.Migrations;

namespace Auto.Pay.Persistence.Data2.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORDERS_PaymentReference_PaymentReferenceId",
                table: "ORDERS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ORDERS",
                table: "ORDERS");

            migrationBuilder.RenameTable(
                name: "ORDERS",
                newName: "Orders");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PaymentReference",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ORDERS_PaymentReferenceId",
                table: "Orders",
                newName: "IX_Orders_PaymentReferenceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentReference_PaymentReferenceId",
                table: "Orders",
                column: "PaymentReferenceId",
                principalTable: "PaymentReference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentReference_PaymentReferenceId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "ORDERS");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PaymentReference",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ORDERS",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PaymentReferenceId",
                table: "ORDERS",
                newName: "IX_ORDERS_PaymentReferenceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ORDERS",
                table: "ORDERS",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERS_PaymentReference_PaymentReferenceId",
                table: "ORDERS",
                column: "PaymentReferenceId",
                principalTable: "PaymentReference",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
