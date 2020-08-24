using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PapugarniaOnline.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KindOfParrots",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KindOfParrots", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KindOfTickets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KindOfTickets", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(nullable: false),
                    Username = table.Column<string>(maxLength: 55, nullable: false),
                    TicketName = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    SurName = table.Column<string>(maxLength: 30, nullable: false),
                    City = table.Column<string>(maxLength: 30, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 30, nullable: false),
                    Street = table.Column<string>(maxLength: 30, nullable: false),
                    Number = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Parrots",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    TypeDescription = table.Column<string>(maxLength: 9999999, nullable: false),
                    KindID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parrots", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Parrots_KindOfParrots_KindID",
                        column: x => x.KindID,
                        principalTable: "KindOfParrots",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketName = table.Column<string>(maxLength: 30, nullable: false),
                    Price = table.Column<int>(nullable: false),
                    KindID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tickets_KindOfTickets_KindID",
                        column: x => x.KindID,
                        principalTable: "KindOfTickets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parrots_KindID",
                table: "Parrots",
                column: "KindID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_KindID",
                table: "Tickets",
                column: "KindID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Parrots");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "KindOfParrots");

            migrationBuilder.DropTable(
                name: "KindOfTickets");
        }
    }
}
