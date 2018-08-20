using Microsoft.EntityFrameworkCore.Migrations;

namespace CarService.DataAccessLayer.Migrations
{
    public partial class RenamedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersDetail_CarTypes_SelectedCarTypeId",
                table: "OrdersDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersDetail_UsersDetail_UserDetailId",
                table: "OrdersDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersDetail",
                table: "UsersDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersDetail",
                table: "OrdersDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarTypes",
                table: "CarTypes");

            migrationBuilder.RenameTable(
                name: "UsersDetail",
                newName: "ag_UsersDetail");

            migrationBuilder.RenameTable(
                name: "OrdersDetail",
                newName: "ag_OrdersDetail");

            migrationBuilder.RenameTable(
                name: "CarTypes",
                newName: "ag_CarTypes");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersDetail_UserDetailId",
                table: "ag_OrdersDetail",
                newName: "IX_ag_OrdersDetail_UserDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersDetail_SelectedCarTypeId",
                table: "ag_OrdersDetail",
                newName: "IX_ag_OrdersDetail_SelectedCarTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ag_UsersDetail",
                table: "ag_UsersDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ag_OrdersDetail",
                table: "ag_OrdersDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ag_CarTypes",
                table: "ag_CarTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ag_OrdersDetail_ag_CarTypes_SelectedCarTypeId",
                table: "ag_OrdersDetail",
                column: "SelectedCarTypeId",
                principalTable: "ag_CarTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ag_OrdersDetail_ag_UsersDetail_UserDetailId",
                table: "ag_OrdersDetail",
                column: "UserDetailId",
                principalTable: "ag_UsersDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ag_OrdersDetail_ag_CarTypes_SelectedCarTypeId",
                table: "ag_OrdersDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ag_OrdersDetail_ag_UsersDetail_UserDetailId",
                table: "ag_OrdersDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ag_UsersDetail",
                table: "ag_UsersDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ag_OrdersDetail",
                table: "ag_OrdersDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ag_CarTypes",
                table: "ag_CarTypes");

            migrationBuilder.RenameTable(
                name: "ag_UsersDetail",
                newName: "UsersDetail");

            migrationBuilder.RenameTable(
                name: "ag_OrdersDetail",
                newName: "OrdersDetail");

            migrationBuilder.RenameTable(
                name: "ag_CarTypes",
                newName: "CarTypes");

            migrationBuilder.RenameIndex(
                name: "IX_ag_OrdersDetail_UserDetailId",
                table: "OrdersDetail",
                newName: "IX_OrdersDetail_UserDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_ag_OrdersDetail_SelectedCarTypeId",
                table: "OrdersDetail",
                newName: "IX_OrdersDetail_SelectedCarTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersDetail",
                table: "UsersDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersDetail",
                table: "OrdersDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarTypes",
                table: "CarTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersDetail_CarTypes_SelectedCarTypeId",
                table: "OrdersDetail",
                column: "SelectedCarTypeId",
                principalTable: "CarTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersDetail_UsersDetail_UserDetailId",
                table: "OrdersDetail",
                column: "UserDetailId",
                principalTable: "UsersDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
