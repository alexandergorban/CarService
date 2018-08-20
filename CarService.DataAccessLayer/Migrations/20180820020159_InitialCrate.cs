using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarService.DataAccessLayer.Migrations
{
    public partial class InitialCrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModelId = table.Column<int>(nullable: false),
                    Model = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    SecondName = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdersDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataFirst = table.Column<DateTime>(nullable: false),
                    TimeFirst = table.Column<DateTime>(nullable: false),
                    DataSecond = table.Column<DateTime>(nullable: false),
                    TimeSecond = table.Column<DateTime>(nullable: false),
                    Transmission = table.Column<bool>(nullable: false),
                    VehicleMaintenance = table.Column<bool>(nullable: false),
                    VehicleRapair = table.Column<bool>(nullable: false),
                    Other = table.Column<bool>(nullable: false),
                    YearOfCar = table.Column<string>(nullable: true),
                    SelectedCarTypeId = table.Column<Guid>(nullable: true),
                    OrderMessage = table.Column<string>(nullable: true),
                    UserDetailId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdersDetail_CarTypes_SelectedCarTypeId",
                        column: x => x.SelectedCarTypeId,
                        principalTable: "CarTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdersDetail_UsersDetail_UserDetailId",
                        column: x => x.UserDetailId,
                        principalTable: "UsersDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDetail_SelectedCarTypeId",
                table: "OrdersDetail",
                column: "SelectedCarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDetail_UserDetailId",
                table: "OrdersDetail",
                column: "UserDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersDetail");

            migrationBuilder.DropTable(
                name: "CarTypes");

            migrationBuilder.DropTable(
                name: "UsersDetail");
        }
    }
}
