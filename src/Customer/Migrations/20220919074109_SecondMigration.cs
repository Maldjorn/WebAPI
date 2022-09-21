using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM.Customers.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "totalPurchaseAmount",
                table: "Customers",
                newName: "TotalPurchaseAmount");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Customers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "notes",
                table: "Customers",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Customers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "customerID",
                table: "Customers",
                newName: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerID",
                table: "Addresses",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Customers_CustomerID",
                table: "Addresses",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customers_CustomerID",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CustomerID",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "TotalPurchaseAmount",
                table: "Customers",
                newName: "totalPurchaseAmount");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Customers",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Customers",
                newName: "notes");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Customers",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Customers",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Customers",
                newName: "customerID");
        }
    }
}
