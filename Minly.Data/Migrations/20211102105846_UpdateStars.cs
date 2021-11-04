using Microsoft.EntityFrameworkCore.Migrations;

namespace Minly.Data.Migrations
{
    public partial class UpdateStars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0593a4bd-daf3-4523-a21d-06f03c5bf4ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6067050f-9853-47a7-a781-9539da3ad391");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a567cbfd-aac0-458a-9001-5b9d79cc92e6");

            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "Stars",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b662903-7d3c-4b0d-bd46-18f969300d54", "bd18f40b-04d3-465e-ab6e-e2f7b3f46e2c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf1946bf-4378-44d8-9a4f-d238063d2eb0", "bdddc97c-97d0-4b71-a31c-0f97629dc3f0", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a913eefe-8d5c-427c-a872-3974fbb15929", "ccaea54a-a6c9-4656-9cce-8b9d9597e997", "Star", "STAR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b662903-7d3c-4b0d-bd46-18f969300d54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a913eefe-8d5c-427c-a872-3974fbb15929");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf1946bf-4378-44d8-9a4f-d238063d2eb0");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Stars");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a567cbfd-aac0-458a-9001-5b9d79cc92e6", "88a8f814-ef1c-4add-944b-31f6e39c5eb7", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0593a4bd-daf3-4523-a21d-06f03c5bf4ba", "466d6e4f-1565-46c3-ae1b-08c260983c41", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6067050f-9853-47a7-a781-9539da3ad391", "525c6126-cd7a-4078-94b9-920b65a542fb", "Star", "STAR" });
        }
    }
}
