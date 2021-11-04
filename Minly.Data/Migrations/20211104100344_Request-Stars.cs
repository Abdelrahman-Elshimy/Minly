using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Minly.Data.Migrations
{
    public partial class RequestStars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04ec90d2-f6d6-4424-8951-8d9ec8095bf3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41709c68-d55e-4429-b36d-1c783d54b772");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b694c30-fdc3-4140-b8d7-a7e492f708b3");

            migrationBuilder.CreateTable(
                name: "RequestStars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ApiUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestStars_AspNetUsers_ApiUserId",
                        column: x => x.ApiUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestStars_Stars_EventId",
                        column: x => x.EventId,
                        principalTable: "Stars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d30a5de8-5ad0-43bf-b0e6-08fb6eadef45", "082fdb34-3456-419d-8c40-44809fb1ab78", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "45f82841-d150-448a-be94-91dddeb82a79", "b2bd459e-a570-4d3a-a1a3-439247a1f61b", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5b30457-1a57-42af-8ecd-351fdd8c7646", "b1295b4b-770c-4897-ac16-7dc1468e2d94", "Star", "STAR" });

            migrationBuilder.CreateIndex(
                name: "IX_RequestStars_ApiUserId",
                table: "RequestStars",
                column: "ApiUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestStars_EventId",
                table: "RequestStars",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestStars");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45f82841-d150-448a-be94-91dddeb82a79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d30a5de8-5ad0-43bf-b0e6-08fb6eadef45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5b30457-1a57-42af-8ecd-351fdd8c7646");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8b694c30-fdc3-4140-b8d7-a7e492f708b3", "c34c22f7-a57c-4115-93c4-d6d998512179", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "04ec90d2-f6d6-4424-8951-8d9ec8095bf3", "7b21df6e-1ec0-4fde-9d07-fa9cccd34179", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "41709c68-d55e-4429-b36d-1c783d54b772", "2f173411-ab5e-4fe0-a40d-739b8eb75f0a", "Star", "STAR" });
        }
    }
}
