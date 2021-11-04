using Microsoft.EntityFrameworkCore.Migrations;

namespace Minly.Data.Migrations
{
    public partial class AddRatess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b3f474e-6f90-4a3b-9720-2c89b6aa0ad2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45627b9c-9e50-4dae-9943-1c11385ce130");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a33e3ba6-bdab-49b1-ae3c-f8f8e767f54c");

            migrationBuilder.CreateTable(
                name: "EventRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    ApiUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventRates_AspNetUsers_ApiUserId",
                        column: x => x.ApiUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventRates_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StarRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    StarId = table.Column<int>(type: "int", nullable: false),
                    ApiUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StarRates_AspNetUsers_ApiUserId",
                        column: x => x.ApiUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StarRates_Stars_StarId",
                        column: x => x.StarId,
                        principalTable: "Stars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8a0eb85-4068-4f94-bfb7-9905fd4d6d39", "3543eecd-7dfa-41c5-871f-d1480f39f49c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d99a464d-4d48-4a94-8564-0ed4df386072", "c24e544d-5a05-4431-9a98-cc3aaf1b0cab", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9d1be03e-3bfa-480d-aa71-5c54be869aab", "bb5204f7-fc69-41d0-9411-2fd21e487a67", "Star", "STAR" });

            migrationBuilder.CreateIndex(
                name: "IX_EventRates_ApiUserId",
                table: "EventRates",
                column: "ApiUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRates_EventId",
                table: "EventRates",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_StarRates_ApiUserId",
                table: "StarRates",
                column: "ApiUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StarRates_StarId",
                table: "StarRates",
                column: "StarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventRates");

            migrationBuilder.DropTable(
                name: "StarRates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d1be03e-3bfa-480d-aa71-5c54be869aab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d99a464d-4d48-4a94-8564-0ed4df386072");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8a0eb85-4068-4f94-bfb7-9905fd4d6d39");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a33e3ba6-bdab-49b1-ae3c-f8f8e767f54c", "9c561f8a-e628-4460-a210-5da205a9c21e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "45627b9c-9e50-4dae-9943-1c11385ce130", "ed68ee9a-e9d9-4a3a-ab34-babf8670978c", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b3f474e-6f90-4a3b-9720-2c89b6aa0ad2", "1d70f9c0-be6c-473c-a3e8-33f150cdc676", "Star", "STAR" });
        }
    }
}
