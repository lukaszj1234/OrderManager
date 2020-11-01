using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManager.DataAccess.Migrations
{
    public partial class ChangeInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BuildingId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuildingId",
                table: "Orders",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Buildings_BuildingId",
                table: "Orders",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Buildings_BuildingId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BuildingId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
